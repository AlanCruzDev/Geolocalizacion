import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import Mapboxgl from 'mapbox-gl';
 
Mapboxgl.accessToken = 'pk.eyJ1IjoiYWxhbmNydXoiLCJhIjoiY2wyODE0ZmJ1MDR0azNkcjQ0ZWpvcTdwMCJ9.UBWkZPVV-e0SNBAC-D7NSw';


if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
