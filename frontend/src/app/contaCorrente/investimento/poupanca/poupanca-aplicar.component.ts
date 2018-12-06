import { Component, Input } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../../../web.service';
import {MatSnackBar} from '@angular/material';

@Component({
    selector: 'investimento-poupanca-aplicar',
    templateUrl: '../../../views/investimento/poupanca/poupanca-aplicar.html',
    styleUrls: ['../../../views/css/sort-overview-example.css'],

})

export class PoupancaAplicarComponent {

    constructor(private webService : WebService, public snackBar: MatSnackBar) { }
    @Input() investimento;


    async ngOnInit() {
       
       
    } 
    async Torendimento(){
        if(this.investimento.Conta.saldo >= this.investimento.valor){
            var axu = this.webService.postInvestido(this.investimento);
            if(axu){
                location.reload();
                this.snackBar.open("valor ap[licado com sucesso!", "Ok", {
                    duration:3000,
                }); 
            }
            
        }else{
            this.snackBar.open("saldo insuficiente", "", {
                duration:3000,
            });
        }

        
    }
}