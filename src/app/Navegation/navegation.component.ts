import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
declare var $:any;

@Component({
  selector: 'app-navegation',
  templateUrl: './navegation.component.html',
  styleUrls: ['./navegation.component.css']
})
export class NavegationComponent implements OnInit {

  public rol:boolean;

  constructor(private ruta:Router) { 
    this.rol = this.GetRol();
  }

  ngOnInit(): void {
    $('#menu-toggle').click(function(e:any) {
      e.preventDefault();
      $('#wrapper').toggleClass('toggled'); 
    });
  }
  logout(){
    localStorage.setItem('0','');
    localStorage.setItem('1','');
    this.ruta.navigate(['/login']);
  }

  private GetRol():boolean{
    const res:number = JSON.parse(localStorage.getItem('1') || '');
    if(res === 1){return true;}
    return false;
  }
}
