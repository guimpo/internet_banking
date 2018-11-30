import { Component } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../../web.service';

export interface PeriodicElement {
    id:number;
    id_tipo_transacao: string;
    data: Date;
    hora: Date;
    valor: number;
  }

@Component({
    selector: 'emprestimo-pagar',
    templateUrl: '../../views/emprestimo/emprestimo-pagar.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],
})

export class EmprestimoPagarComponent {

    constructor(private webService : WebService){}

    displayedColumns: string[] = ['id', 'tipo_transacao', 'data', 'hora','valor','botao'];
    dataSource = new MatTableDataSource();

    async ngOnInit() {

        var response = await this.webService.getTransacao();
        console.log(response.json());
    
        this.dataSource = response.json(); 
    } 
}