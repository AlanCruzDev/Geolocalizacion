import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { GuardGuard } from './guard.guard';
import {PackageFollowUpComponent} from './package-follow-up/package-follow-up.component';
import {RecoverypasswordComponent} from './recoverypassword/recoverypassword.component';
import {NewPasswordComponent} from './new-password/new-password.component';


const routes:Routes =[
  {path:'login', loadChildren:()=>import('./auth/auth.module').then(m=> m.AuthModule)},
  {path:'recovery', component:RecoverypasswordComponent},
  {path:'Sidebar', loadChildren:()=> import('./Navegation/navegation.module').then(m=>m.NavegationModule)},
  {path:'new/password', component:NewPasswordComponent},
  {path:'follow-up/:idruta', component:PackageFollowUpComponent},
  {path:'**', redirectTo:'login'}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }