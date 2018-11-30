import { Component, OnInit } from '@angular/core';
import { ContaSalarioService } from './conta-salario.service';

import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';

import { WebService } from '../web.service';


export interface PeriodicElement {
    id:number;
    id_tipo_transacao: string;
    data: Date;
    hora: Date;
    valor: number;
  }

@Component({
    selector: 'app-conta-salario',
    templateUrl: './views/conta-salario-extrato.component.html',
    styleUrls: ['./css/conta-salario.component.css']
  })
  export class ContaSalarioExtratoComponent {
    // constructor(private service: ContaSalarioService) {}

    constructor(private webService : WebService){}

    displayedColumns: string[] = ['id', 'tipo_transacao', 'data', 'hora','valor'];
    dataSource = new MatTableDataSource();

    async ngOnInit() {

        var response = await this.webService.getTransacao();
        console.log(response.json());

        this.dataSource = response.json(); 
    } 

  }