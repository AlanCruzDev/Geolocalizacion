import { Component, AfterViewInit, ViewChild, ElementRef, OnInit } from '@angular/core';
import { Map } from 'mapbox-gl';
import { FeatureCollection, Geometry, Point } from 'geojson';
@Component({
  selector: 'app-map-page',
  templateUrl: './map-page.component.html',
  styleUrls: ['./map-page.component.css']
})
export class MapPageComponent implements AfterViewInit {

  public staticBreadcrumbs!: FeatureCollection<Geometry>;

  constructor() { }

  @ViewChild('mapDiv')
  mapDivElement!: ElementRef;

  ngAfterViewInit(): void {

    const map = new Map({
      container: this.mapDivElement.nativeElement, // container ID
      style: 'mapbox://styles/mapbox/streets-v11', // style URL
      zoom: 0 // starting zoom
    });



    map.on('load', async () => {

      const geojson = await this.GetLocation(map);
      map.addSource('iss', {
        type: 'geojson',
        data: geojson
      });

      map.loadImage('../../../assets/img/icons8-elige-el-frontal-48.png',(error,image:any)=>{
        if (error) throw error;
        map.addImage('cat', image);

      });

      map.addLayer({
        'id': 'iss',
        'type': 'symbol',
        'source': 'iss',
        'layout': {
          'icon-image': 'cat',
          'icon-size': 1
        }
        
      });

      const updateSource = setInterval(async () => {
        const geojson = await this.GetLocation(map, updateSource);
        const source: mapboxgl.GeoJSONSource = map.getSource('iss') as mapboxgl.GeoJSONSource;
        source.setData(geojson);
      }, 2000);

    });

  }

  public async GetLocation(map: Map, updateSource?: any) {
    try {
      const response = await fetch(
        'https://api.wheretheiss.at/v1/satellites/25544',
        { method: 'GET' }
      );
      const { latitude, longitude } = await response.json();
      // Fly the map to the location.
      map.flyTo({
        bearing:0,
        speed: 0.5,
        curve:1
      });
      return this.staticBreadcrumbs = {
        type: 'FeatureCollection',
        features: [
          {
            type: 'Feature',
            properties: {},
            geometry: {
              type: 'Point',
              coordinates: [longitude, latitude]
            }
          },
          {
            type: 'Feature',
            properties: {},
            geometry: {
              type: 'Point',
              coordinates: [longitude*2,latitude]
            }
          },
          {
            type: 'Feature',
            properties: {},
            geometry: {
              type: 'Point',
              coordinates: [longitude+20,latitude]
            }
          }
        ]
      }
    } catch (err: any) {
      if (updateSource) clearInterval(updateSource);
      throw new Error(err);
    }
  }

}

