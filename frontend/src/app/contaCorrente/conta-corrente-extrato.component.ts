import {Component, OnInit, ViewChild, Output, EventEmitter} from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../web.service';

export interface PeriodicElement {
  id:number;
  id_tipo_transacao: string;
  data: Date;
  hora: Date;
  valor: number;
}
// const ELEMENT_DATA: PeriodicElement[] = [
//   {id : 1, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 1.5 },
//   {id : 2, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 2.5 },
//   {id : 3, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 3.5 },
//   {id : 4, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 4.5 },
//   {id : 5, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 5.5 },
//   {id : 6, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 6.5 },
//   {id : 7, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 7.5 },
//   {id : 8, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 8.5 },
//   {id : 9, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 9.5 },
//   {id : 1, tipo_transacao: 'Hydrogen', data:new Date, hora: new Date, valor: 1.5 },

// ];
@Component({
  selector: 'conta-corrente-extrato',
  templateUrl: '../views/conta-corrente-extrato.html',
  styleUrls: ['../views/css/sort-overview-example.css'],
})
export class ContaCorrenteExtratoComponent  {

  constructor(private webService : WebService){}

  displayedColumns: string[] = ['id', 'tipo_transacao', 'data', 'hora','valor'];
  dataSource = new MatTableDataSource();

  async ngOnInit() {

    var response = await this.webService.getTransacao();
    console.log(response.json());

    this.dataSource = response.json(); 
  } 

}

