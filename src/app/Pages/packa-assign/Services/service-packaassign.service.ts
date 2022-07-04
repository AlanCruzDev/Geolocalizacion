import { Injectable } from '@angular/core';
import {IPackage} from '../../../Models/IPackage';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.prod';
import {ITypeTransport} from '../../../Interfaces/ITypeTransport';
import {ICreatePackage} from '../../../Interfaces/ICreatePackage';
import { IResult } from 'src/app/Interfaces/IResult';
@Injectable({
  providedIn: 'root'
})
export class ServicePackaassignService {

  private url:string = environment.baseURLPackage;
  private _urltruck= environment.baseURLTruck;


  constructor(private http:HttpClient) { }

  public GetPackagesNumber():Observable<[IPackage]>{
    return this.http.get<[IPackage]>(`${this.url}/v1/package`,{
      responseType:'json'
    });
  }
  public GetTypeTransport():Observable<[ITypeTransport]>{
    return this.http.get<[ITypeTransport]>(`${this._urltruck}/v1/type/list/type`,{
      responseType:'json'
    });
  }
  public GetOneTypeTransport(id:number):Observable<[ITypeTransport]>{
    return this.http.get<[ITypeTransport]>(`${this._urltruck}/v1/type/type/${id}`,{
      responseType:'json'
    });
  }
  public PutOneCamion(idruta:number, createpackage:ICreatePackage):Observable<IResult>{
    return this.http.put<IResult>(`${this._urltruck}/v1/camion/update/${idruta}`,createpackage);
  }
}
