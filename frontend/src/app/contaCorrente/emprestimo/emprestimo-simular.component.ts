import { Component } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../../web.service';



@Component({
    selector: 'emprestimo-simular',
    templateUrl: '../../views/emprestimo/emprestimo-simular.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],

})

export class EmprestimoSimularComponent {
    constructor(private webService : WebService){}


    displayedColumns: string[] = ['id', 'tipo_transacao', 'data', 'hora','valor'];
    dataSource = new MatTableDataSource();
  
    async ngOnInit() {
  
      var response = await this.webService.getTransacao();
      console.log(response.json());
  
      this.dataSource = response.json(); 
    } 
   
}