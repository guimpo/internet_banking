import { Component,  Output, EventEmitter  } from '@angular/core'
import { WebService } from '../../../web.service';

export interface Investimento{
    valor: number;
    Conta:Object;
    TipoInvestimento:Object;
}

@Component({
    selector: 'investimento',
    templateUrl: '../../../views/investimento/poupanca/poupanca.html',
})

export class PoupancaComponent {

    constructor(private webService : WebService){}
    loadAplicarComponent = false;
    loadResgatarComponent = false;
   
    async ngOnInit() {

        var response = await this.webService.getLogin(1);
        this.conta = response.json();
        this.investimento.Conta = this.conta;
        var response = await this.webService.getPopanca(this.conta['id']);
        console.log(response.json());
        this.investimento.TipoInvestimento = response.json();

    } 
    
    investimento:Investimento = {
        valor:0,
        TipoInvestimento: 0,
        Conta:0
    }
    async aplicar() {
        this.loadAplicarComponent = true;
        this.loadResgatarComponent = false;
    }
    async resgatar() {
        this.loadAplicarComponent = false;
        this.loadResgatarComponent = true;
    }
    conta=[];
}