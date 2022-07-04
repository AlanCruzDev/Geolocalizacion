import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITruck } from '../../Interfaces/ITruck';
import { CreateTruckDTO } from 'src/app/Models/CreateTruckDTO';

@Injectable({
  providedIn: 'root'
})
export class ServiceIngueService {

  private URL:string = environment.baseURLTruck;

  constructor(private http:HttpClient) { }


  public GetTruck():Observable<[ITruck]>{
    return this.http.get<[ITruck]>(`${this.URL}/v1/camion/all`,{
      responseType:'json'
    });
  }
  public PostTruck(data:CreateTruckDTO):Observable<any>{
    return this.http.post(`${this.URL}/v1/encargado`,data);
  }
} 
