import { Component,  Output, EventEmitter  } from '@angular/core'
import { WebService } from '../../../web.service';

export interface Investimento{
    valor: number;
    Conta:Object;
    TipoInvestimento:Object;
}

export interface Poupanca{
    id: number;
    descricao:string;
    liquidez:string;
    rentabilidade:number
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

        var response = await this.webService.getInvestido(this.conta['id']);
        this.tipo = response.json();
        this.investimento.TipoInvestimento =  this.tipo; 
        
        var response = await this.webService.getPoupanca();
        this.poupanca = response.json();
      
        if(this.investimento.TipoInvestimento== null){
            this.investimento.TipoInvestimento= this.poupanca;
        }
        console.log(  this.investimento);
        
       

    } 
    
    investimento:Investimento = {
        valor:0,
        TipoInvestimento: 0,
        Conta:0
    }
    poupanca:Poupanca = {
        id: 0,
        descricao:"",
        liquidez:"",
        rentabilidade:0
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
    tipo=[];
    juro=[];
    
}