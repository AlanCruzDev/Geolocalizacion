import {Routes} from '@angular/router';
import {RegisterTruckComponent} from './register-truck/register-truck.component';
import {RegisterInchargeComponent} from './register-incharge/register-incharge.component';

export const routingtruck:Routes=[
  {path:'new/truck', component:RegisterTruckComponent},
  {path:'new/inchage', component:RegisterInchargeComponent},
  {path:'**', redirectTo:'new/truck'}
];



