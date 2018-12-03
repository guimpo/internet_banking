import { Component } from '@angular/core'
import { WebService } from '../../web.service';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import {MatSnackBar} from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';


@Component({
    selector: 'debito-excluir',
    templateUrl: '../../views/debito/debito-consultar.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],
})
export class DebitoConsultarComponent {

    constructor(private webService : WebService, public snackBar: MatSnackBar) {}
    displayedColumns: string[] = ['id', 'descricao', 'codigo','botao'];
    dataSource = new MatTableDataSource();
    selection = new SelectionModel(true, []);
    async ngOnInit(){

        //consultar banco
        var response = await this.webService.getContaCadastrada();
        console.log(response.json());
       
        //passa dado para table
        this.dataSource.data = response.json();   
    }
    async delete(id, row){
     
        //deletar item no banco
        var response = await this.webService.deleteContaCadastrada(id);
        var aux = response.json();
    
      
        if(aux.boolean) {
            this.snackBar.open("Conta removida com sucesso!", "Ok", {
                duration:3000,
            }); 

            //deletar linha selecionado
            const index: number = this.dataSource.data.indexOf(row);    
            if (index !== -1) {
                this.dataSource.data.splice(index,1);
            } 
            //reimprimir table
            this.dataSource = new MatTableDataSource(this.dataSource.data);     

        } else {
            this.snackBar.open("Falhou", "Ok", {
                duration:3000,
            });
        }
    }
}