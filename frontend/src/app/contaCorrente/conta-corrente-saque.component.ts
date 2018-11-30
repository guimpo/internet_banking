import { Component,  Output, EventEmitter  } from '@angular/core';
import { WebService } from '../web.service';
import {MatSnackBar} from '@angular/material';

@Component({
    selector: 'conta-corrente-saque',
    templateUrl: '../views/conta-corrente-saque.html',
})
export class ContaCorrenteSaqueComponent {
    form;
    constructor(private webService : WebService, public snackBar: MatSnackBar){}

    saque = {
        tipo_transacao_id: 1,
        valor: 0
    }
    async ngOnInit(){

        //recebe do servidor
        var response = await this.webService.getLogin(1);
        console.log(response.json());
  
        //vai mostrar la em cima cooresponte
        this.conta = response.json();
        
    }
    conta = [ ];
    async post(){
        // console.log(this.deposito);
        //var response = await this.webService.valida(this.saque.valor);
        //var aux = response.json();
        
        if(this.saque.valor < 0) {
            this.snackBar.open("Valor invalido!", "Ok", {
                duration:3000,
            });
        }
        else if(this.saque.valor <= this.conta['saldo']) {
            this.snackBar.open("Saque realizado com sucesso!", "Ok", {
                duration:3000,
            });
            this.webService.postTransacao(this.saque);    
        } else {
            this.snackBar.open("Saldo insuficiente!", "Ok", {
                duration:3000,
            });
        }
        
    }
}