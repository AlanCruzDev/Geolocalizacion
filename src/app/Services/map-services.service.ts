import { Injectable } from '@angular/core';
import { LngLatBounds, LngLatLike, Map, Marker, Popup } from 'mapbox-gl';
import { IPlacesResponse, Feature } from '../Interfaces/IPlaces';
import { PlacesApiClient } from '../api';
import PackageOrigen from '../Acciones/PackageOrigen';
import PackageDestiny from '../Acciones/PackageDestiny';
@Injectable({
  providedIn: 'root'
})
export class MapServicesService {

  public useLocation!: [number, number];
  private map!: Map;
  public isLoadingPlaces: boolean = false;
  public places: Feature[] = [];
  private markers: Marker[] = [];
  private packaorigen:PackageOrigen;
  private packagedestiny:PackageDestiny;
  private cunter:number=0;

  constructor(private placesApi: PlacesApiClient) {
    this.getUserLocation();
    this.packaorigen = new PackageOrigen();
    this.packagedestiny = new PackageDestiny();
  }

  public async getUserLocation(): Promise<[number, number]> {
    return new Promise((resolve, reject) => {
      navigator.geolocation.getCurrentPosition(
        ({ coords }) => {
          this.useLocation = [coords.longitude, coords.latitude];
          resolve([coords.longitude, coords.latitude])
        },
        (
          error => {
            console.log(error)
            reject();
          }
        )
      );
    });
  }

  get isMapReady() {
    return !!this.map;
  }
  get isUserLocationReady(): boolean {
    return !!this.useLocation;
  }

  setMap(map: Map) {
    this.map = map;
  }

  flyTo(lng: number, lat: number) {

    this.map?.flyTo({
      zoom: 14,
      center: {
        lat: lat,
        lng: lng
      }
    });
  }
  getPlacesByQuery(query: string = '') {
    if (query.length === 0) {
      this.places = [];
      this.isLoadingPlaces = false;
      return;
    }
    this.isLoadingPlaces = true;
    this.placesApi.get<IPlacesResponse>(`/${query}.json`, {
      params: {
        proximity: this.useLocation!.join(',')

      }
    })
      .subscribe(res => {
        this.isLoadingPlaces = false;
        this.places = res.features;
        this.createMarkersFromPlaces(this.places);
      });

  }
  createMarkersFromPlaces(places: Feature[]) {

    this.markers.forEach(market => market.remove());
    const newmarkert = [];
    for (const place of places) {
      const [lng, lat] = place.center;
      const popup = new Popup()
      .on('open',()=>{
        // aqui vamos a verificar si es origen o destiny
        this.verifyCoordenates(lng, lat);
        this.cunter+=1;
      })  
      .setHTML(`
          <h6>${place.text}</h6>
          <span>${place.place_name}</span>
        `)
      const newMarker = new Marker()
        .setLngLat([lng, lat])
        .setPopup(popup)
        .addTo(this.map);
      newmarkert.push(newMarker);
    }
    this.markers = newmarkert;
    if(places.length === 0) return;
    // limites de mapo
    const bounds = new LngLatBounds();
    newmarkert.forEach(marker => bounds.extend(marker.getLngLat()));
     
    this.map.fitBounds(bounds,{
      padding:200
    })

  }
  public verifyCoordenates(lng:number,lat:number):void{
    if(this.cunter === 0){
        this.packaorigen.set(lat,lng);
    }else{
      this.packagedestiny.set(lat,lng);
      this.cunter = 0;
    }
    
  }
}
