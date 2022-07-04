import { Component, OnInit } from '@angular/core';
import { MapServicesService } from 'src/app/Services/map-services.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {

  private debounceTimer?:NodeJS.Timeout;

  constructor(private mapservices:MapServicesService) { }

  ngOnInit(): void {
  }
  onQueryChanged(query:string = ''){

    if(this.debounceTimer) clearTimeout(this.debounceTimer);

    this.debounceTimer = setTimeout(()=>{
      this.mapservices.getPlacesByQuery(query);
    },350);
  }

}
