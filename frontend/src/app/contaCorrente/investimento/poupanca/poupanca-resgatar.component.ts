import { Component, Input } from '@angular/core';


@Component({
    selector: 'investimento-poupanca-Resgatar',
    templateUrl: '../../../views/investimento/poupanca/poupanca-resgatar.html',
})

export class PoupancaResgatarComponent {

    @Input() investimento;
}