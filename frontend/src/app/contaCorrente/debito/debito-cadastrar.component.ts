import { Component } from '@angular/core'
import { WebService } from '../../web.service';
import {MatSnackBar} from '@angular/material';

// export interface Conta{
//     id:number,
//     numero:number,
//     agencia: string,
//     saldo:number,
//     tipo_conta_id:number,
//     pessoa_id:number
// } 

@Component({
    selector: 'debito-cadastrar',
    templateUrl: '../../views/debito/debito-cadastrar.html',
    styleUrls: ['../../views/css/debito-cadastrar.css'],
})

// const Conta: Conta[] = this.conta;
export class DebitoCadastrarComponent {

    constructor(private webService : WebService,  public snackBar: MatSnackBar){}

    // async ngOnInit(){

    //     //recebe do servidor
    //     var response = await this.webService.getLogin(1);
       
  
    //     //vai mostrar la em cima cooresponte
    //     this.conta = response.json();
    //     console.log(this.conta);
        

       

    // }
    // conta = [];
    servicos: string [] = [ 'Gás'  , 'luz' , 'água' , 'telefone' ]; 
    contaCadastrado = {
        Conta: 1,
        descricao: "",
        codigo: ""

    }
    async post(){
        console.log(this.contaCadastrado);
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
