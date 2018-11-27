import { Component,  Output, EventEmitter  } from '@angular/core'
import {MatSnackBar} from '@angular/material';
import { WebService } from '../web.service';


@Component({
    selector: 'conta-corrente-deposito',
    templateUrl: '../views/conta-corrente-deposito.html',
})
export class ContaCorrenteDepositoComponent {
    
    
    constructor(private webService : WebService, public snackBar: MatSnackBar){}

    deposito = {
        id_tipo_transacao: 2,
        valor: 0

    }
    async ngOnInit(){

        //recebe do servidor
        var response = await this.webService.getLogin(2);
        console.log(response.json());
  
        //vai mostrar la em cima cooresponte
        this.conta = response.json();
        

       

    }
    conta = [ ];
    async post(){
        // console.log(this.deposito);
        var response = await this.webService.postTransacao(this.deposito);
        var aux = response.json();

        if(aux.boolean) {
            this.snackBar.open("Depósito realizado com sucesso!", "Ok", {
                duration:3000,
            }); 
        } else {
            this.snackBar.open("falhou!", "Ok", {
                duration:3000,
            });
        }
       
    }
}