import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { ServiceAuthService } from './Services/service-auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  public formulario!:FormGroup;

  constructor(private router:Router, private fb:FormBuilder, private api:ServiceAuthService) { }

  ngOnInit(): void {
    this.CrearFormulario();
  }

  public CrearFormulario(){
    this.formulario=this.fb.group({
      Correo:['',[Validators.required,Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$')]],
      Pass1:['',[Validators.required,Validators.minLength(4)]]  
    });
  }
  public get VerifiCorreo():Boolean{
    return this.formulario.get('Correo')!.invalid && this.formulario.get('Correo')!.touched;
  }
  public get VerifiContra():Boolean{
    return this.formulario.get('Pass1')!.invalid && this.formulario.get('Pass1')!.touched;
  }
  
  public IniciarLogin():void{
    const {Correo, Pass1} = this.formulario.value;

    if(!this.VerifiCorreo && !this.VerifiContra){
      this.api.GetLogin(Correo,Pass1).subscribe((res)=>{
        if(res?.ok){
          this.router.navigate(['/Sidebar/sidebar']);
        }else{
          alert('Usuario no Existe');
        }
      });
    }else{
      alert('Datos Incorrectos');
    }
  }

  public RecuperarCredenciales(){
    this.router.navigate(['/recovery']);
  }
}
