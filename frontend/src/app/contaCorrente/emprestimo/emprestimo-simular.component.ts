import { Component, Input } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../../web.service';

export interface Parcela {
    dataVencimento: Date;
    valor: number;
  }

@Component({
    selector: 'emprestimo-simular',
    templateUrl: '../../views/emprestimo/emprestimo-simular.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],

})

export class EmprestimoSimularComponent {
    constructor(private webService : WebService){}

    @Input() emprestimo; 
    aux;

    displayedColumns: string[] = ['dataVencimento', 'valor'];
    dataSource = new MatTableDataSource();
  
    async ngOnInit() {  
        this.aux = this.emprestimo;     
        var response = await this.webService.simular(this.emprestimo);
        this.dataSource = response.json();
    }
    
    post() {
        this.webService.postEmprestimo(this.aux)
    }
   
}