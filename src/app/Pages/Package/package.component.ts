import { Component,ViewChild, AfterViewInit,ElementRef, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Map, Marker, Popup } from 'mapbox-gl';
import Swal from 'sweetalert2'
import { MapServicesService } from 'src/app/Services/map-services.service';
import PackageOrigen from '../../Acciones/PackageOrigen';
import PackageDestiny from '../../Acciones/PackageDestiny';
import {CreateNewPackageDTO} from '../../Models/CreateNewPackageDTO';
import {ServicesService} from './Services/services.service';
import {MenssageExitoConfirm,MessageNotConfirm,MessageError} from '../../Middleware/MessageConfir';
import {ICuestomers} from '../../Models/Cuestomers';

@Component({
  selector: 'app-package',
  templateUrl: './package.component.html',
  styleUrls: ['./package.component.css']
})

export class PackageComponent implements AfterViewInit,OnInit,OnDestroy {

  public fmGrupo!: FormGroup;
  private packageorigyn:PackageOrigen;
  private packagedestiny:PackageDestiny;
  public _cuestomers:ICuestomers[]=[];
  private useeffect:any;
  private createnewpackage!:CreateNewPackageDTO;
  private _lntorigen:number = 0;
  private _lngorigen:number = 0;
  private _lntdestiny:number = 0;
  private _lngdestiny:number = 0;
  
  constructor(
      private mapservices:MapServicesService,
      private fb: FormBuilder,
      private api:ServicesService
      
      ) { 
    this.packageorigyn = new PackageOrigen();
    this.packagedestiny = new PackageDestiny();
  }
  ngOnDestroy(): void {
    clearInterval(this.useeffect);
    this.packageorigyn.clearCoordenas();
  }
  ngOnInit(): void {
    this.InizialiceForm();
    this.GetUsers();
    // verficamos todo lo demas
      this.useeffect = setInterval(()=>{

        this._lntorigen = PackageOrigen._latitude;
        this._lngorigen = PackageOrigen._longitude;
        this._lntdestiny = PackageDestiny._latitudestiny;
        this._lngdestiny = PackageDestiny._longitudedestiny;
      },2000);
  }

  @ViewChild('mapDirections')
  mapDivElement!: ElementRef;
  ngAfterViewInit(): void {
    const map = new Map({
      container: this.mapDivElement.nativeElement, // container ID
      style: 'mapbox://styles/mapbox/streets-v11', // style URL
      center: this.mapservices.useLocation,
      zoom: 0 // starting zoom
    });

    const popup = new Popup()
    .setHTML(`
        <h6>Aqui estoy</h6>
        <span>Estoy en este lugar del mundo</span>
        `);
    new Marker({color:'red'})
    .setLngLat({
      lat:19.4956451,
      lng:-99.0681776
    })
    .setPopup(popup)
    .addTo(map)
    this.mapservices.setMap(map);
  }
  public GetUsers(){
    this.api.GetUsers().subscribe((res:ICuestomers[])=>{
      this._cuestomers =res;
    });
  }
  public savePackage(){
    const {
        txtorigin,
        txtdestino,
        txtfechaenvio,
        txtfechaentrega,
        txtcodigopaquete,
        txtprecio,
        selectpackage,
        txtdescription,
        txtsubtotalpaquete,
        txtiva,
        txttotalpagar,
        idcuestomers
    }=this.fmGrupo.value;
  
    // DEBEMOS DE PONER EL ID USER

    this.createnewpackage ={
      EstadoEntrega:false,
      SubtotalPaquete:txtsubtotalpaquete,
      IvaPaquete:txtiva,
      TotalPaquete:txttotalpagar,
      OrigenPaquete:txtorigin,
      DestinoPaquete:txtdestino,
      TypePackage:selectpackage,
      Description:txtdescription,
      PrecioPackage:txtprecio,
      CodePackage:txtcodigopaquete,
      LatOrigen:this._lntorigen,
      LogOrigen:this._lngorigen,
      LatDestination:this._lntdestiny,
      LogDestination:this._lngdestiny,
      IdUser:idcuestomers
    }
    this.WindowsMengente();
  }

  public WindowsMengente(){
    Swal.fire({
      title: 'Estas Seguro?',
      text: "Desea guardar el Paquete!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, Guardar!'
    }).then((result) => {
      if(result.isConfirmed){
        this.api.insertPackage(this.createnewpackage).subscribe(res=>{
          MenssageExitoConfirm();
        });
      }else if(result.dismiss === Swal.DismissReason.cancel){
        MessageNotConfirm();
      }
    })
  }
  public messageconfir(){

  }

  public InizialiceForm(){
    this.fmGrupo = this.fb.group({
      txtorigin:['',Validators.required],
      txtdestino:['', Validators.required],
      txtfechaenvio:['',Validators.required],
      txtfechaentrega:['',Validators.required],
      txtcodigopaquete:['',Validators.required],
      txtprecio:[0,Validators.required],
      selectpackage:['', Validators.required],
      txtdescription:['',Validators.required],
      txtsubtotalpaquete:[0,Validators.required],
      txtiva:[0,Validators.required],
      txttotalpagar:[0,Validators.required],
      idcuestomers:['',Validators.required]

    })
  }

}
