import { Component, OnInit } from '@angular/core';
import { ServicesService } from './services.service';
import { IPackage } from '../../Models/IPackage';

@Component({
  selector: 'app-packa-list',
  templateUrl: './packa-list.component.html',
  styleUrls: ['./packa-list.component.css']
})
export class PackaListComponent implements OnInit {

  public _package:IPackage[]=[];

  constructor(private api:ServicesService) { }

  ngOnInit(): void {
    this.GetPackageAll();
  }

  public GetPackageAll(){
    this.api.GetPackagesNumber().subscribe((res:IPackage[])=>{
      this._package=res;
      console.log(res);
    })
  }

}
