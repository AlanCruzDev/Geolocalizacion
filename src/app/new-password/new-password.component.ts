import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';
import { putEmployeDTO } from '../Models/putEmployeDTO';
import { NewpassSericesService } from './Services/newpass-serices.service';
import { IResponse } from '../Interfaces/IResponse';

@Component({
  selector: 'app-new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.css']
})
export class NewPasswordComponent implements OnInit {

  private _employe!:putEmployeDTO

  constructor(private router:Router, private api:NewpassSericesService) { }

  ngOnInit(): void {
    var code = this.GetCode();
    if(code.length < 0){
      this.router.navigate(['/login']);
    }
  }

  public SavaPassword():void{
    let pass =(document.getElementById('passwordtxt') as HTMLInputElement).value;
    if(pass !== null && pass !== undefined){
      var code = this.GetCode();
      this._employe={
        Id:0,
        email:'',
        password:pass,
        CodeVerify:code
      }

      this.api.PutPassNew(this._employe).subscribe((res:IResponse)=>{
        if(res.ok){
          alert('Password Actualizada');
          this.router.navigate(['/login']);
        }else{
          alert('Error');
        }
      })
    
    }
  }
  public GetCode(): string {
    let valor:string = JSON.parse(localStorage.getItem('code') || '');
    return valor;
  }
}
