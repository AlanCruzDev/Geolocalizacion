import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {SearchBarComponent} from './search-bar/search-bar.component';
import { SearcresultsComponent } from './searcresults/searcresults.component';
import { ModalComponent } from './modal/modal.component';



@NgModule({
  declarations: [SearchBarComponent, SearcresultsComponent, ModalComponent],
  imports: [
    CommonModule
  ],
  exports:[
    SearchBarComponent,
    ModalComponent
  ]
})
export class ComponentsModule { }
