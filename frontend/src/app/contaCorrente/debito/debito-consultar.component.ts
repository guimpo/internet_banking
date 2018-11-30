import { Component } from '@angular/core'
import { WebService } from '../../web.service';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import {MatSnackBar} from '@angular/material';

@Component({
    selector: 'debito-excluir',
    templateUrl: '../../views/debito/debito-consultar.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],
})
export class DebitoConsultarComponent {

    constructor(private webService : WebService, public snackBar: MatSnackBar) {}
    displayedColumns: string[] = ['id', 'descricao', 'codigo','botao'];
    dataSource = new MatTableDataSource();
   

    async ngOnInit(){

        //recebe do servidor
        var response = await this.webService.getContaCadastrada();
        console.log(response.json());
       
        this.dataSource = response.json();   
    }
    async delete(id){
       
        var response = await this.webService.deleteContaCadastrada(id);
        var aux = response.json();
        
        if(aux.boolean) {
            this.snackBar.open("Conta removida com sucesso!", "Ok", {
                duration:3000,
            });   
        } else {
            this.snackBar.open("Falhou", "Ok", {
                duration:3000,
            });
        }
    }
}