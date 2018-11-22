import { Component } from '@angular/core';
import {Sort} from '@angular/material';
import { Data } from '@angular/router';

export interface Extrato {
    data: string ;
    historico: string;
    valor: number;
  }

@Component({
    selector: 'conta-corrente-extrato',
    templateUrl: '../views/conta-corrente-extrato.html',
    styleUrls: ['../views/css/sort-overview-example.css'],
})


export class ContaCorrenteExtratoComponent {

    desserts: Extrato[] = [
        {data: '6/15/15', historico: 'deposito de usuario', valor: 24 },
        {data: '6/15/15', historico: 'deposito de usuario9', valor: 37},
        {data: '6/15/15', historico: 'deposito de usuario24',valor: 6},
        {data: '6/15/15', historico: 'deposito de usuario67', valor: 4},
        {data: '6/15/15', historico: 'deposito de usuario49', valor: 4},
      ];

      sortedData: Extrato[];

      constructor() {
        this.sortedData = this.desserts.slice();
      }
    
      
}