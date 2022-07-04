import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IResponse } from '../Interfaces/IResponse';
import { putEmployeDTO } from '../Models/putEmployeDTO';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  private URL:string = environment.baseURLPackage;

  constructor(private http:HttpClient) { }


  public PutCodeNew(employe:putEmployeDTO):Observable<IResponse>{
    return this.http.put<IResponse>(`${this.URL}/v1/employe/generate/code`,employe);
  }

  public SaveCode(code:string):boolean{
    if(code === ""){
      return false;
    }
    localStorage.setItem('code', JSON.stringify(code));
    return true;

  }
}
