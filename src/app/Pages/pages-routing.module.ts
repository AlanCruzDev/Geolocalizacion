import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MapPageComponent} from './map-page/map-page.component';
import {PackageComponent} from './Package/package.component';
import {AssignPackagesComponent} from '../Pages/assign-packages/assign-packages.component';
import {TruckComponent} from './truck/truck.component';
import {routingtruck} from './pages-routingchildren-truck.module';




/*Importamos la rutas Hijas */
import {routespackages} from './pages-routinghijas.module';
import { GuardGuard } from '../guard.guard';



const routes: Routes = [
  {path:'map', component:MapPageComponent, canActivate:[GuardGuard]},
  {path:'packages', component:PackageComponent},
  {path:'assign/packages', component:AssignPackagesComponent, children:routespackages},
  {path:'create', component:TruckComponent, children:routingtruck},
  {path:'**', redirectTo:'map'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
