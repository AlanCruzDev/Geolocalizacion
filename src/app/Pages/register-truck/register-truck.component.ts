import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ITypeTransport } from 'src/app/Interfaces/ITypeTransport';
import { ITruck } from '../../Models/Track';
import {ServiceRegistertrunkService} from './Services/service-registertrunk.service';


@Component({
  selector: 'app-register-truck',
  templateUrl: './register-truck.component.html',
  styleUrls: ['./register-truck.component.css']
})
export class RegisterTruckComponent implements OnInit {

  public fmGrupo!: FormGroup;
  public _track!: ITruck;
  public _type:ITypeTransport[]=[];

  constructor(private fb: FormBuilder,
    private api:ServiceRegistertrunkService
    
    ) { }

  ngOnInit(): void {
    this.InizialiteForm();
    this.GetTypeTransport();
  }

  public savePackage() {
    const {
      txtplaca,      
      txtserie,      
      txtcolor,      
      txtmarca,      
      txtmodelo,     
      txtplazas,     
      idtypetransport
    } = this.fmGrupo.value;
    this._track={
      Placa:txtplaca,
      Serie:txtserie,
      Colour:txtcolor,
      Marca:txtmarca,
      Modelo:txtmodelo,
      Plazas:Number(txtplazas),
      Status:false,
      Stock:0,
      TypeTransportId:idtypetransport,
      RoutesId:0
    }
    this.api.PostInCharge(this._track).subscribe((res)=>{
      console.log(res);
    })
  }

  public GetTypeTransport(){
    this.api.GetTypeTransport().subscribe((res:ITypeTransport[])=>{
      this._type =res;
    });
  }

  public InizialiteForm() {
    this.fmGrupo = this.fb.group({
      txtplaca:        ['', Validators.required],
      txtserie:        ['', Validators.required],
      txtcolor:        ['', Validators.required],
      txtmarca:        ['', Validators.required],
      txtmodelo:       ['', Validators.required],
      txtplazas:       ['', Validators.required],
      idtypetransport: [0, Validators.required]
    });

  }

}
