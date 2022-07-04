import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITypeTransport } from 'src/app/Interfaces/ITypeTransport';
import { environment } from '../../../../environments/environment.prod';
import {ITruck} from '../../../Models/Track';


@Injectable({
  providedIn: 'root'
})
export class ServiceRegistertrunkService {

  private url:string = environment.baseURLTruck;

  constructor(private http: HttpClient) { }

  public PostInCharge(data:ITruck):Observable<any>{
    return this.http.post(`${this.url}/v1/camion`,data);
  }
  public GetTypeTransport():Observable<[ITypeTransport]>{
    return this.http.get<[ITypeTransport]>(`${this.url}/v1/type/list/type`,{
      responseType:'json'
    });
  }
}
