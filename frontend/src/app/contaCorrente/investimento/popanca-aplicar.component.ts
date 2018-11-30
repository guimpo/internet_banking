import { Component } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';


export interface PeriodicElement {
    id:number;
    id_tipo_transacao: string;
    data: Date;
    hora: Date;
    valor: number;
}


@Component({
    selector: 'investimento-popanca-aplicar',
    templateUrl: '../../views/investimento/popanca-aplicar.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],

})

export class PopancaAplicarComponent {

    constructor() { }

    displayedColumns: string[] = ['id', 'tipo_transacao', 'data', 'hora','valor','botao'];
    dataSource = new MatTableDataSource();

    async ngOnInit() {

       
    } 
    Torendimento(){
        document.getElementById("rendimento").style.display= "block";
    }
}