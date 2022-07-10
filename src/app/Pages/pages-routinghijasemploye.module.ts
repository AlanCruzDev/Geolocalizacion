import { Routes } from '@angular/router';
import { ListEmployesComponent } from './list-employes/list-employes.component';
import {NewEmployeComponent} from './new-employe/new-employe.component';

export const routesemploye:Routes=[
  {path:'new/employe', component:NewEmployeComponent},
  {path:'list/employe', component:ListEmployesComponent},
  {path:'**', redirectTo:'new/employe'}
];