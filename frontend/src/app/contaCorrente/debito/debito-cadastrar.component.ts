import { Component } from '@angular/core'
import { WebService } from '../../web.service';
import {MatSnackBar} from '@angular/material';

export interface contaCadastrado {
    id_conta: 1,
    descricao: string,
    numeroConta: string
}   
@Component({
    selector: 'debito-cadastrar',
    templateUrl: '../../views/debito/debito-cadastrar.html',
    styleUrls: ['../../views/css/debito-cadastrar.css'],
})
export class DebitoCadastrarComponent {

    constructor(private webService : WebService,  public snackBar: MatSnackBar){}

    servicos: string [] = [ 'Gás'  , 'luz' , 'água' , 'telefone' ]; 
    contaCadastrado = {
        id_conta: 1,
        descricao: "",
        codigo: ""

    }
    async post(){
        
        var response = await this.webService.postCadastrarConta(this.contaCadastrado);
        var aux = response.json();
        
        if(aux.boolean) {
            this.snackBar.open("Conta cadastrada com sucesso!", "Ok", {
                duration:3000,
            });   
        } else {
            this.snackBar.open("Falhou", "", {
                duration:3000,
            });
        }
       
    }
    
    

}
