import { Component } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../../web.service';

export interface PeriodicElement {
    id:number;
    datavencimento: Date;
    status: boolean;
    valor: number;
  }

@Component({
    selector: 'emprestimo-pagar',
    templateUrl: '../../views/emprestimo/emprestimo-pagar.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],
})

export class EmprestimoPagarComponent {

    constructor(private webService : WebService){}
    loadcomp = false;

    parcela = {
        id: 1,
        dataVencimento: null,
        status: false,
        valor: 200
    }
    codigo = 0;
    i;
    displayedColumns: string[] = ['id', 'dataVencimento', 'status','valor','botao'];
    dataSource = new MatTableDataSource();

    async ngOnInit() {

        var response = await this.webService.getParcelas();
        console.log(response.json());
    
        this.dataSource = response.json(); 
    } 

    async get(parcela) {
        this.parcela = parcela;
        var response = await this.webService.boleto(this.parcela);
    
        this.i = response.json();

        var res = await this.webService.codigo(this.parcela);

        this.codigo = res.json();
        this.loadcomp = true;
        
    }

    async fecha() {
        this.loadcomp = false;
       
   }
}