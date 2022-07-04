import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICoordenates } from 'src/app/Models/ICoordenatesRoutes';
import { environment } from '../../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ServiceFollowService {

  private _URLROUTE:string = environment.baseURL;

  constructor(private http: HttpClient) { }


  public GetCoordenates(id:number):Observable<ICoordenates>{
    return this.http.get<ICoordenates>(`${this._URLROUTE}/v1/coordenates/${id}`,{
      responseType:'json'
    });
  }
}
