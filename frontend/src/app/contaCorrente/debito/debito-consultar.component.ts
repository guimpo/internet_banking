import { Component } from '@angular/core'
import {Sort} from '@angular/material';
import { Data } from '@angular/router'; 
import { WebService } from '../../web.service';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';

export interface PeriodicElement {
    id: number ;
    descricao: string;
    codigo: string;
}

@Component({
    selector: 'debito-consultar',
    templateUrl: '../../views/debito/debito-consultar.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],
})
export class DebitoConsultarComponent {
    
    constructor(private webService : WebService) {}
    displayedColumns: string[] = ['id', 'descricao', 'codigo'];
    dataSource = new MatTableDataSource();

    async ngOnInit(){

        //recebe do servidor
        var response = await this.webService.getContaCadastrada();
        console.log(response.json());
       
        this.dataSource = response.json(); 
        
        
    }
    

  

    
        
  
}