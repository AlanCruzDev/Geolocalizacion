import { Routes } from '@angular/router';
import {PackaAssignComponent} from '../Pages/packa-assign/packa-assign.component';
import {PackaListComponent} from '../Pages/packa-list/packa-list.component';

export const routespackages:Routes=[
  {path:'new/package', component:PackaAssignComponent},
  {path:'list/package', component:PackaListComponent},
  {path:'**', redirectTo:'new/package'}
];