import { Component } from '@angular/core'
import { WebService } from '../../web.service';

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

    constructor(private webService : WebService){}

    servicos: string [] = [ 'Gás'  , 'luz' , 'água' , 'telefone' ]; 
    contaCadastrado = {
        id_conta: 1,
        descricao: "",
        codigo: ""

    }
    post(){
        console.log(this.contaCadastrado);
        this.webService.postCadastrarConta(this.contaCadastrado);

       
    }
    
    

}
