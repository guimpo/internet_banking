import { Component } from '@angular/core';
import { WebService } from '../../web.service';

@Component({
    selector: 'emprestimo-realizar',
    templateUrl: '../../views/emprestimo/emprestimo-realizar.html',
})

export class EmprestimoRealizarComponent {
    constructor(private webService : WebService){}

    conta;
    emprestimo = {
        valor: 100,
        parcelas: 12
    }

    async ngOnInit() {
        //recebe do servidor
        var response = await this.webService.getLogin(1);
        console.log(response.json());
  
        //vai mostrar la em cima cooresponte
        this.conta = response.json();
    }
}
