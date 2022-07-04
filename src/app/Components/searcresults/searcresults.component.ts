import { Component, OnInit } from '@angular/core';
import { MapServicesService } from 'src/app/Services/map-services.service';
import { Feature } from '../../Interfaces/IPlaces';

@Component({
  selector: 'app-searcresults',
  templateUrl: './searcresults.component.html',
  styleUrls: ['./searcresults.component.css']
})
export class SearcresultsComponent {

  constructor(private mapservices:MapServicesService) { }

  get inLoadingPlaces(){
    return this.mapservices.isLoadingPlaces;
  }
  get places():Feature[]{
    return this.mapservices.places;
  }
  public FlyTo(place:Feature){
    const [lng,lat]=place.center;
    this.mapservices.flyTo(lng,lat)
  }
}
