import { Component, Input } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType, MatSnackBar} from '@angular/material';
import { WebService } from '../../web.service';

export interface Parcela {
    dataVencimento: Date;
    valor: number;
  }

@Component({
    selector: 'emprestimo-simular',
    templateUrl: '../../views/emprestimo/emprestimo-simular.html',
    styleUrls: ['../../views/css/sort-overview-example.css'],

})

export class EmprestimoSimularComponent {
    constructor(private webService : WebService, public snackBar: MatSnackBar){}

    @Input() emprestimo; 
    aux;

    transacao = {
        tipo_transacao_id: 6,
        valor: 0
    }

    debito = {
        conta: 7,
        descricao: "Pagamento de emprestimo pessoal",
        codigo: "123"
    }

    displayedColumns: string[] = ['dataVencimento', 'valor'];
    dataSource = new MatTableDataSource();
  
    async ngOnInit() {  
        this.aux = this.emprestimo;
        this.transacao.valor = this.emprestimo.valor;     
        var response = await this.webService.simular(this.emprestimo);
        this.dataSource = response.json();
    }

    post() {
        this.webService.postEmprestimo(this.aux)
        this.webService.postTransacao(this.transacao);
        if(this.aux.metodoPagamento == 2) {
            this.webService.postCadastrarConta(this.debito);
        }
        this.snackBar.open("Emprestimo realizado com sucesso!", "Ok", {
            duration:3000,
        });
    }
   
}