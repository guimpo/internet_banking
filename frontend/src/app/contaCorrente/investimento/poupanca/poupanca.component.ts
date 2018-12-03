import { Component,  Output, EventEmitter  } from '@angular/core'
import { WebService } from '../../../web.service';


@Component({
    selector: 'investimento',
    templateUrl: '../../../views/investimento/poupanca/poupanca.html',
})

export class PoupancaComponent {

    constructor(private webService : WebService){}

   
    async ngOnInit() {

        var response = await this.webService.getPopanca();
        console.log(response.json());
        this.investimemto  = response.json();
          
        
        var response = await this.webService.getLogin(1);
        this.conta = response.json();
        this.aplicacao.saldo = this.conta['saldo'];
        
    } 
    conta=[];
    investimemto = [];
    aplicacao = {
        saldo: 0,
        investimento: 0,
       
    } 

}