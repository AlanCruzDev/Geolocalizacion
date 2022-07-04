import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {CreateNewPackageDTO} from '../../../Models/CreateNewPackageDTO';
import { environment } from '../../../../environments/environment.prod';
import {ICuestomers} from '../../../Models/Cuestomers';


@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  private url:string = environment.baseURL;
  private urlcuestomers:string = environment.baseURLCuestomers;

  constructor(private api: HttpClient) { }

  public GetUsers():Observable<[ICuestomers]>{
    return this.api.get<[ICuestomers]>(`${this.urlcuestomers}/v1/user/everyone`,{
      responseType:'json'
    });
  }



  public insertPackage(createnewpackage:CreateNewPackageDTO):Observable<any>{
    return this.api.post(`${this.url}/v1/coordenates`,createnewpackage,{
      headers: this.getHeader()
    });
  }
  public getHeader():HttpHeaders{
    let token = JSON.parse(localStorage.getItem('0')!);
    let Auth: HttpHeaders = new HttpHeaders({
      'content-type': 'application/json',
      Authorization: "Bearer "+token
    });
    return Auth;

  }
}
