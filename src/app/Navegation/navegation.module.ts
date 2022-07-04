import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// incorporamos los controladores
import {NavegationComponent} from './navegation.component';
import { NavegationRoutingModule } from './navegation-routing.module';



//Importamos el HTTP
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [NavegationComponent],
  imports: [
    CommonModule,
    NavegationRoutingModule,
    HttpClientModule
  ]
})
export class NavegationModule { }
