import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { ServicesService } from './services.service';
import { IResponse } from '../Interfaces/IResponse';
import { putEmployeDTO } from '../Models/putEmployeDTO';


@Component({
  selector: 'app-recoverypassword',
  templateUrl: './recoverypassword.component.html',
  styleUrls: ['./recoverypassword.component.css']
})
export class RecoverypasswordComponent implements OnInit {

  public formulario!:FormGroup;
  public openModal:boolean;
  public _employe!:putEmployeDTO


  constructor(private router:Router, private fb:FormBuilder, private api:ServicesService) {
    this.openModal = false;
   }

  ngOnInit(): void {
    this.CrearFormulario();

  }

  public CrearFormulario(){
    this.formulario=this.fb.group({
      Correo:['',[Validators.required,Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$')]]
    })
  }
  public VerificarCode():void{
    this.openModal = false;
    const {Correo} = this.formulario.value;
    this._employe ={
      Id:0,
      email:Correo,
      CodeVerify:'',
      password:''
    }

    if(Correo !== null && Correo !== ""){
      this.api.PutCodeNew(this._employe).subscribe((res:IResponse)=>{
        console.log(res);
        if(res.ok){
          if(this.api.SaveCode(res.msg)){
            this.AbirModal()
          }
          else{
            alert('Error de servidor');
          }
        }else{
            alert('Correo no Encontrado');
        }

      });
    
    }else{
      alert('Error de Correo');
    }
  }
  public AbirModal():void{
    this.openModal = true;
  }

}
