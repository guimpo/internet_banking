import { Component,  Output, EventEmitter  } from '@angular/core'
import { WebService } from '../web.service';


@Component({
    selector: 'conta-corrente-investimento',
    templateUrl: '../views/conta-corrente-investimento.html',
})

export class ContaCorrenteInvestimentoComponent {
    aplicacao = {
        saldo: 0,
        investimento: 0,
        liquidez: 0 ,
        rendabilidade: 0
    }

}