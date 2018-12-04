import { Component, Input } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../../web.service';

export interface Parcela {
    dataVencimento: Date;
    valor: number;
  }

@Component({
    selector: 'emprestimo-boleto',
    templateUrl: '../../views/emprestimo/emprestimo-boleto.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],

})

export class EmprestimoBoletoComponent {
    constructor(private webService : WebService){}

    @Input() parcela; 
    aux;
    loadcomp = true;
    i;
    codigo;
  
    async ngOnInit() {  
        this.aux = this.parcela;     
        var response = await this.webService.boleto(this.parcela);
    
        this.i = response.json();

        var res = await this.webService.codigo(this.parcela);

        this.codigo = res.json();

         
    }

    async get() {
         this.loadcomp = false;
        
    }
   
}