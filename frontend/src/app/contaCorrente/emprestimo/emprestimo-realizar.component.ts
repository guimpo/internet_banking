import { Component } from '@angular/core';


@Component({
    selector: 'emprestimo-realizar',
    templateUrl: '../../views/emprestimo/emprestimo-realizar.html',
})

export class EmprestimoRealizarComponent {

    emprestado = {
        saldo: 0,
        valor: 0,
        parcelas:0

    }
}
