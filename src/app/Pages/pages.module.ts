import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { MapPageComponent } from './map-page/map-page.component';
import { PackageComponent } from './Package/package.component';
import {ComponentsModule} from '../Components/components.module';
import {ReactiveFormsModule} from '@angular/forms';
import { AssignPackagesComponent } from './assign-packages/assign-packages.component';
import {PackaAssignComponent} from './packa-assign/packa-assign.component';
import {PackaListComponent} from './packa-list/packa-list.component';
import {RegisterTruckComponent} from './register-truck/register-truck.component';
import {TruckComponent} from './truck/truck.component';
import {RegisterInchargeComponent} from './register-incharge/register-incharge.component';
import {CreateemployesComponent} from './createemployes/createemployes.component';
import {NewEmployeComponent} from './new-employe/new-employe.component';
import {ListEmployesComponent} from './list-employes/list-employes.component';




@NgModule({
  declarations: [
    MapPageComponent,
    PackageComponent,
    AssignPackagesComponent,
    PackaAssignComponent,
    PackaListComponent,
    RegisterTruckComponent,
    TruckComponent,
    RegisterInchargeComponent,
    CreateemployesComponent,
    NewEmployeComponent,
    ListEmployesComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    ComponentsModule,
    ReactiveFormsModule
  ]
})
export class PagesModule { }
