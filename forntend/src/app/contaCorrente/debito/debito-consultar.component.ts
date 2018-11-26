import { Component } from '@angular/core'
import {Sort} from '@angular/material';
import { Data } from '@angular/router'; 

export interface Conta {
    data: string ;
    historico: string;
    valor: number;
  }

@Component({
    selector: 'debito-consultar',
    templateUrl: '../../views/debito/debito-consultar.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],
})
export class DebitoConsultarComponent {

    desserts: Conta[] = [
        {data: '6/15/15', historico: 'deposito de usuario', valor: 24 },
        {data: '6/15/15', historico: 'deposito de usuario9', valor: 37},
        {data: '6/15/15', historico: 'deposito de usuario24',valor: 6},
        {data: '6/15/15', historico: 'deposito de usuario67', valor: 4},
        {data: '6/15/15', historico: 'deposito de usuario49', valor: 4},
        ];

    sortedData: Conta[];

    constructor() {
    this.sortedData = this.desserts.slice();
    }
        
  
}