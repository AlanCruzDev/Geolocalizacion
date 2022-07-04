import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPackage } from 'src/app/Models/IPackage';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  private urlpackage:string = environment.baseURLPackage;

  constructor(private http:HttpClient) { }

  
  public GetPackagesNumber():Observable<[IPackage]>{
    return this.http.get<[IPackage]>(`${this.urlpackage}/v1/package`,{
      responseType:'json'
    });
  }
}
