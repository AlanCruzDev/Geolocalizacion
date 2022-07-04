import { AfterViewInit, Component, ElementRef, OnInit, ViewChild, OnDestroy } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { Map, Marker, Popup  } from 'mapbox-gl';
import { ICoordenates } from '../Models/ICoordenatesRoutes';
import {ServiceFollowService} from './Services/service-follow.service';
import { FeatureCollection, Geometry, Point } from 'geojson';

@Component({
  selector: 'app-package-follow-up',
  templateUrl: './package-follow-up.component.html',
  styleUrls: ['./package-follow-up.component.css']
})

export class PackageFollowUpComponent implements OnInit, AfterViewInit, OnDestroy {

  private _coodenates!:ICoordenates;
  private useeffect:any;
  public staticBreadcrumbs!: FeatureCollection<Geometry>;

  @ViewChild('mapDivRutas')
  mapDivElement!: ElementRef;

  constructor(private _route:ActivatedRoute, private api:ServiceFollowService) {
    console.log(this._route.snapshot.paramMap.get('idruta'));
  }
  ngOnDestroy(): void {
    clearInterval(this.useeffect);
  }
  ngOnInit(): void {
    
  }
  
  ngAfterViewInit(): void {
    const map = new Map({
      container: this.mapDivElement.nativeElement, // container ID
      style: 'mapbox://styles/mapbox/streets-v11', // style URL
      zoom: 0 // starting zoom
    });

    map.on('load', async ()=>{
      
      
      const geojson = await this.GetLocation(map);
      map.addSource('iss', {
        type: 'geojson',
        data: geojson
      });

      map.loadImage('../../assets/img/icons8-elige-el-frontal-48.png',(error,image:any)=>{
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
  public  async GetLocation(map:Map, updateSource?: any){
    try{
      
      const response = await fetch('https://localhost:7005/v1/coordenates/1',
      {
        method:'GET'
      });
      const{latOrigen,logOrigen}:ICoordenates= await response.json();
      console.log(latOrigen,logOrigen)

      map.flyTo({
        bearing:0,
        speed:0.5,
        curve:1
      });
      return  this.staticBreadcrumbs ={
        type:'FeatureCollection',
        features:[{
          type:'Feature',
          properties:{},
          geometry:{
            type:'Point',
            coordinates:[logOrigen,latOrigen]
          }
        }]
      }
    }catch(err:any){
      if (updateSource) clearInterval(updateSource);
      throw new Error(err);

    }
  }
}

