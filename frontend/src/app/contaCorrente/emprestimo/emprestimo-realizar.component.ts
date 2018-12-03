import { Component } from '@angular/core';
import { WebService } from '../../web.service';

@Component({
    selector: 'emprestimo-realizar',
    templateUrl: '../../views/emprestimo/emprestimo-realizar.html',
})

export class EmprestimoRealizarComponent {
    constructor(private webService : WebService){}
    loadComponent = false;
    emprestimo = {
        valor: 1000,
        parcelas: 12,
        id: 1,
        metodoPagamento: 0
    }

    async ngOnInit() {
    
    }

    async post() {
        this.loadComponent = true;
    }
}
