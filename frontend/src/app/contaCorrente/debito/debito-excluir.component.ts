import { Component } from '@angular/core'
import { WebService } from '../../web.service';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';


export interface PeriodicElement {
    id: number ;
    descricao: string;
    codigo: string;
}

@Component({
    selector: 'debito-excluir',
    templateUrl: '../../views/debito/debito-excluir.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],
})
export class DebitoExcluirComponent {

    constructor(private webService : WebService) {}
    displayedColumns: string[] = ['id', 'descricao', 'codigo','botao'];
    dataSource = new MatTableDataSource();
   

    async ngOnInit(){

        //recebe do servidor
        var response = await this.webService.getContaCadastrada();
        console.log(response.json());
       
        this.dataSource = response.json();   
    }
    delete(id){
       
        this.webService.deleteContaCadastrada(id);
    }
}