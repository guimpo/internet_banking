import { Component } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import {MatSnackBar} from '@angular/material';
import { WebService } from '../../../web.service';


@Component({
    selector: 'investimento-selic-aplicar',
    templateUrl: '../../../views/investimento/selic/selic-aplicar.html',
    styleUrls: ['../../../views/css/sort-overview-example.css'],
})

export class SelicAplicarComponent {

    constructor(private webService : WebService, public snackBar: MatSnackBar){}

    aplicacao = {
        quantidade:1,
        valor: 0
    }

    valor(){
        this.aplicacao.valor = this.aplicacao.quantidade * 100;
        return this.aplicacao.valor;
    }

    async ngOnInit() {
        
    }

    async post(){
        // console.log(this.deposito);
        var response = await this.webService.postAplicacaoSelic(this.aplicacao);
        var aux = response;

        if(this.aplicacao.valor < 0) {
            this.snackBar.open("Valor invalido!", "Ok", {
                duration:3000,
            });
        }
        
        else if(aux) {
            this.snackBar.open("Investimento realizado com sucesso!", "Ok", {
                duration:3000,
            }); 
        } else {
            this.snackBar.open("falhou!", "Ok", {
                duration:3000,
            });
        }
       
    }

    // Torendimento(){
    //     document.getElementById("rendimento").style.display= "block";
    // }

}