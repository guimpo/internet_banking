import { Component,  Output, EventEmitter  } from '@angular/core'
import { WebService } from '../../../web.service';


@Component({
    selector: 'investimento',
    templateUrl: '../../../views/investimento/selic/selic.html',
})

export class SelicComponent {

    constructor(private webService : WebService){}

   
    async ngOnInit() {

        var response = await this.webService.getSelic();
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