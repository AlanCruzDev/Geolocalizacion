import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceIngueService } from './service-ingue.service';
import { ITruck } from '../../Interfaces/ITruck';
import { CreateTruckDTO } from 'src/app/Models/CreateTruckDTO';

@Component({
  selector: 'app-register-incharge',
  templateUrl: './register-incharge.component.html',
  styleUrls: ['./register-incharge.component.css']
})
export class RegisterInchargeComponent implements OnInit {

  public _fmGrupo!:FormGroup;
  public _truck:ITruck[]=[];
  public _createtruck!:CreateTruckDTO;

  constructor(
    private fb: FormBuilder,
    private api:ServiceIngueService
  ) { 
    this.GetTruckPackages();
    this.InitialForm();
  }

  ngOnInit(): void {
  }

  public saveTruck(){
    const {
      txtNombre, 
      txtPaterno,
      txtMaterno,
      txtTelefono,
      txtUsuario,
      txtPassword,
      txtCamion
    }=this._fmGrupo.value;

    if(txtUsuario !== "" && txtPassword !== ""){
      this._createtruck ={
        Nombre:txtNombre,
        Apellidos:txtPaterno+txtMaterno,
        Direccion:'',
        Telefono:txtTelefono,
        Cargo:'SIN',
        Usuario:txtUsuario,
        Password:txtPassword,
        CamionId:[txtCamion]
      }
      this.api.PostTruck(this._createtruck).subscribe((res)=>{
        if(res.usuario){
          alert('se guardo Correctamente');
        }
      })
    }

  }

  private InitialForm(){
    this._fmGrupo = this.fb.group({
      txtNombre:    ['', Validators.required],
      txtPaterno:   ['',Validators.required],
      txtMaterno:   ['',Validators.required],
      txtTelefono:  ['', Validators.required],
      txtUsuario:   ['', Validators.required],
      txtPassword:  ['', Validators.required],
      txtCamion:    ['', Validators.required]
    })
  }
  public GetTruckPackages(){
    this.api.GetTruck().subscribe((res:ITruck[])=>{
      this._truck = res;
    });
  }

}
