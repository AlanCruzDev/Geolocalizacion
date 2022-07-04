import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'
import { putEmployeDTO } from 'src/app/Models/putEmployeDTO';
import { IResponse } from 'src/app/Interfaces/IResponse';
@Injectable({
  providedIn: 'root'
})
export class NewpassSericesService {

  private URL:string = environment.baseURLPackage;

  constructor(private http:HttpClient) { }

  
  public PutPassNew(employe:putEmployeDTO):Observable<IResponse>{
    return this.http.put<IResponse>(`${this.URL}/v1/employe/new/credenciales`,employe);
  }

  public GetCode(): string {
    let valor = JSON.parse(localStorage.getItem('code') || '');
    return valor;
  }



}
