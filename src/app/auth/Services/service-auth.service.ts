import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { IResponseAuth } from '../../Interfaces/IResponseAuth';

@Injectable({
  providedIn: 'root'
})
export class ServiceAuthService {

  private URL:string = environment.baseURLPackage;

  constructor(private http:HttpClient) { }

  public GetLogin(user:String,password:String):Observable<IResponseAuth | undefined>{
    return this.http.get<IResponseAuth>(`${this.URL}/v1/employe/${user}/${password}`).pipe(
      map((res:IResponseAuth) =>{
        if(res.ok){
          this.SaveToke(res.msg.token, res.msg.rol)
          return res;
        }
       return null;
      }), catchError(err => of(err))
    );
  }

  private SaveToke(data:string, rol:number){
    localStorage.setItem('0', JSON.stringify(data));
    localStorage.setItem('1',JSON.stringify(rol));
  }
  public CheckToken(): boolean{
    let data = JSON.parse(localStorage.getItem('0') || '');
    if(data){
      return true;
    }
    return false;
  }
}
