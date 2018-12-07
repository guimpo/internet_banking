import { Component } from '@angular/core';
import { WebService } from '../../../web.service';
import {MatSnackBar} from '@angular/material';

@Component({
    selector: 'investimento-selic-resgatar',
    templateUrl: '../../../views/investimento/selic/selic-resgatar.html',
})

export class SelicResgatarComponent {

    constructor(private webService : WebService, public snackBar: MatSnackBar){}

    resgate = {
        quantidade:1,
        valor: 0
    }

    valor(){
        this.resgate.valor = this.resgate.quantidade * 100;
        return this.resgate.valor;
    }

    async post(){
        // console.log(this.deposito);
        var response = await this.webService.postResgatarcaoSelic(this.resgate);
        var aux = response.json();

        if(this.resgate.valor < 0) {
            this.snackBar.open("Valor invalido!", "Ok", {
                duration:3000,
            });
        }
        
        else if(aux == true) {
            this.snackBar.open("Resgate realizado com sucesso!", "Ok", {
                duration:3000,
            }); 
            window.location.reload();            
        } else {
            this.snackBar.open("falhou!", "Ok", {
                duration:3000,
            });
        }
       
    }

}