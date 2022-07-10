import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { Observable } from 'rxjs';
import { CreateEmploye } from 'src/app/Models/CreateEmploye';
@Injectable({
  providedIn: 'root'
})
export class ServiceEmployeService {

  private URL:string = environment.baseURLPackage;

  constructor(private http:HttpClient) { }


  public PostEmploye(employe:CreateEmploye):Observable<any>{
    return this.http.post(`${this.URL}/v1/employe`,employe);
  }
}
