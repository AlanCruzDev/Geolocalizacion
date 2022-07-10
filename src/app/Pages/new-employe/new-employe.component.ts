import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreateEmploye } from '../../Models/CreateEmploye';
import { ServiceEmployeService } from './Services/service-employe.service';

@Component({
  selector: 'app-new-employe',
  templateUrl: './new-employe.component.html',
  styleUrls: ['./new-employe.component.css']
})
export class NewEmployeComponent implements OnInit {

  public _fmGrupo!:FormGroup;
  public _employe!:CreateEmploye;

  constructor(
    private fb: FormBuilder,
    private api:ServiceEmployeService
  ) { 
    this.InitialForm();
  }

  ngOnInit(): void {
  }


  public SaveEmploye():void{
    const {
      txtnombre,
      txtapellidos,
      txtNumeroEmpleado,
      idrol,
      txtcorreo,
      txtcontra
    } = this._fmGrupo.value;
    if(txtcorreo != "" && txtcontra != ""){
      this._employe={
        Nombre:txtnombre,
        Apellidos:txtapellidos,
        NumEmpleado:txtNumeroEmpleado,
        Usuario:txtcorreo,
        password:txtcontra,
        rol:idrol,
        CodeVerify:"",
        Activo:true
      }
      this.api.PostEmploye(this._employe).subscribe(res=>{
          alert("Se Inserto Correctamente");
      });


    }
  }

  private InitialForm(){
    this._fmGrupo = this.fb.group({
      txtnombre:    ['', Validators.required],
      txtapellidos:   ['',Validators.required],
      txtNumeroEmpleado:   ['',Validators.required],
      idrol:  ['', Validators.required],
      txtcorreo:   ['', Validators.required],
      txtcontra:  ['', Validators.required]
    });
  }

}
