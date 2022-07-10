import { Component, OnInit } from '@angular/core';
import { IEmploye } from '../../Interfaces/IEmploye';
import { ListemployeServiceService } from './Service/listemploye-service.service';

@Component({
  selector: 'app-list-employes',
  templateUrl: './list-employes.component.html',
  styleUrls: ['./list-employes.component.css']
})
export class ListEmployesComponent implements OnInit {

  public _employe:IEmploye[]=[];

  constructor(private api:ListemployeServiceService) { }

  ngOnInit(): void {
    this.GetEmployesAll();
  }
  private GetEmployesAll(){
    this.api.GetPackagesNumber().subscribe((res:IEmploye[])=>{
      this._employe=res;
    })
  }
  public DeleteEmploye(id:string){
    this.api.DeleteEmploye(Number(id)).subscribe((res:boolean)=>{
      if(res){
        alert('Dato Eleminado');
        this.GetEmployesAll();
      }
    })

  }





}
