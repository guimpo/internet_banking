import { Component,  Output, EventEmitter  } from '@angular/core'

import { WebService } from '../web.service';


@Component({
    selector: 'conta-corrente-deposito',
    templateUrl: '../views/conta-corrente-deposito.html',
})
export class ContaCorrenteDepositoComponent {
    
    constructor(private webService : WebService){}

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
    post(){
        // console.log(this.deposito);
        this.webService.postTransacao(this.deposito);

       
    }
}