import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

declare var $: any;

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit, OnDestroy {

  public _mensajecode: boolean;
  private useeffect: any;



  constructor(private router:Router) {
    this._mensajecode = false;
  }
  ngOnDestroy(): void {
    clearInterval(this.useeffect);
  }

  ngOnInit(): void {
    this.Abrir();
  }
  public Abrir(): void {
    console.log('webolas');
    ($('#exampleModal') as any).modal('show');
  }
  private Cerrar_Modal(): void {
    ($('#exampleModal') as any).modal('toggle');
  }


  public VerificarCode(): void {
    var valor = (document.getElementById('codetxt') as HTMLInputElement).value;
    if (valor.toString() !== "") {
      if (valor === this.GetCode()) {
        this.router.navigate(['/new/password']);
        this.Cerrar_Modal();
      }
      else {
        this.useeffect = setInterval(async () => {
          this._mensajecode = false;
          clearInterval(this.useeffect);
        }, 3000);
        this._mensajecode = true;
      }
    }
  }
  public GetCode(): string {
    let valor = JSON.parse(localStorage.getItem('code') || '');
    return valor;
  }



}
