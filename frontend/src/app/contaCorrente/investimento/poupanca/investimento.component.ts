import { Component,  Output, EventEmitter  } from '@angular/core'
import { WebService } from '../../../web.service';


@Component({
    selector: 'investimento',
    templateUrl: '../../views/investimento/poupanca/poupanca.html',
})

export class InvestimentoComponent {
    aplicacao = {
        saldo: 0,
        investimento: 0,
        liquidez: 0 ,
        rendabilidade: 0
    } 
}