import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEmploye } from 'src/app/Interfaces/IEmploye';

import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class ListemployeServiceService {

  private URL:string = environment.baseURLPackage;

  constructor(private http:HttpClient) { }

  
  public GetPackagesNumber():Observable<[IEmploye]>{
    return this.http.get<[IEmploye]>(`${this.URL}/v1/employe`,{
      responseType:'json'
    });
  }

  public DeleteEmploye(id:number):Observable<boolean>{
    return this.http.delete<boolean>(`${this.URL}/v1/employe/${id}`);
  }
}
