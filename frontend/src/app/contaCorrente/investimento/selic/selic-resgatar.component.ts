import { Component } from '@angular/core';


@Component({
    selector: 'investimento-selic-resgatar',
    templateUrl: '../../../views/investimento/selic/selic-resgatar.html',
})

export class SelicResgatarComponent {

    aplicacao = {
        quantidade:1,
        valor: 0
    }

    valor(){
        this.aplicacao.valor = this.aplicacao.quantidade * 100;
        return this.aplicacao.valor;
    }



}