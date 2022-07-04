import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {NavegationComponent} from './navegation.component';

const routes: Routes = [
  {path:'', component:NavegationComponent, loadChildren:()=> import('../Pages/pages.module').then(e=> e.PagesModule)},
  {path:'**', redirectTo:''}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NavegationRoutingModule { }
