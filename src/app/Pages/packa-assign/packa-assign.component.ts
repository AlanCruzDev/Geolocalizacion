import { Component, OnInit } from '@angular/core';
import {IPackage} from '../../Models/IPackage';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ServicePackaassignService } from './Services/service-packaassign.service';
import { ITypeTransport,Transport } from '../../Interfaces/ITypeTransport';
import {ICreatePackage} from '../../Interfaces/ICreatePackage';
import { IResult } from '../../Interfaces/IResult';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-packa-assign',
  templateUrl: './packa-assign.component.html',
  styleUrls: ['./packa-assign.component.css']
})
export class PackaAssignComponent implements OnInit {

  public fmGrupo!: FormGroup;
  public _numberpackages:IPackage[]=[];
  public _type:ITypeTransport[]=[];
  public _typetransport:Transport[]=[];
  public _cretepackage!:ICreatePackage;
 
  constructor(
    private fb: FormBuilder,
    private api: ServicePackaassignService) { }

  ngOnInit(): void {
    this.GetNumnberPackages();
    this.GetTypeTransport();
    this.InizialiceForm();
  }

  public GetNumnberPackages(){
    this.api.GetPackagesNumber().subscribe((res:IPackage[]) =>{
        this._numberpackages = res;
    });
  }
  public GetTypeTransport(){
    this.api.GetTypeTransport().subscribe((res:ITypeTransport[])=>{
      this._type =res;
    });
  }

  public onChange(event:Event) {
    const idpackage= (event.target as HTMLInputElement).value;
    console.log(idpackage);
    const resp = this._numberpackages.find(res => res.id === Number(idpackage));
    this.fmGrupo.controls['nameroute'].setValue(resp?.idRuta);
    this.fmGrupo.controls['originpackage'].setValue(resp?.origenPaquete);
    this.fmGrupo.controls['destinypackage'].setValue(resp?.destinoPaquete);
  }
  public OnChange(event:Event){
    const idtrack =(event.target as HTMLInputElement).value;
    this.api.GetOneTypeTransport(Number(idtrack)).subscribe((res:ITypeTransport[])=>{
      res.map((valor,index)=>{
        this._typetransport= valor.transports;
      })
    });

  }

  public savePackage(){
    const {originpackage,destinypackage,idtypetransport,idtransport,txtstock}= this.fmGrupo.value;
    const idroute = this.fmGrupo.controls['nameroute'].value;
    
    if(txtstock !== null && txtstock !== undefined){

      this._cretepackage={
        Id:idtransport,
        Stock:txtstock
      }
      
      this.api.PutOneCamion(idroute,this._cretepackage).subscribe((res:IResult)=>{
        if(res.ok){
          Swal.fire({
            icon: 'success',
            title: 'Actualizacion',
            text: 'Se Guardaron los Cambios Correctamente'
          });

        }else{
          Swal.fire({
            icon: 'error',
            title: 'Actualizacion',
            text: 'Error en la Actualizacion'
          });
        }

      });
      
    }


  }

  public InizialiceForm(){
    this.fmGrupo = this.fb.group({
      nameroute:['', [Validators.required]],
      originpackage:['', Validators.required],
      destinypackage:['',Validators.required],
      idtypetransport:['',Validators.required],
      idtransport:['',Validators.required],
      txtstock:['',Validators.required]
    });
    this.fmGrupo.get("nameroute")?.disable();
    this.fmGrupo.get("originpackage")?.disable();
    this.fmGrupo.get("destinypackage")?.disable();
  }
}
