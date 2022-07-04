import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import {AppRoutingModule} from './app-routing.module';
import {HttpClientModule} from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PackageFollowUpComponent } from './package-follow-up/package-follow-up.component';
import { RecoverypasswordComponent } from './recoverypassword/recoverypassword.component';
import {ComponentsModule} from '../app/Components/components.module';



// IMPORTAMOS LOS FORMULARIOS
import {ReactiveFormsModule} from '@angular/forms';
import { NewPasswordComponent } from './new-password/new-password.component';



@NgModule({
  declarations: [
    AppComponent,
    PackageFollowUpComponent,
    RecoverypasswordComponent,
    NewPasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ComponentsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
