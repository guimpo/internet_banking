import { Component, Input } from '@angular/core';
import { WebService } from '../../../web.service';
import {MatSnackBar} from '@angular/material';


@Component({
    selector: 'investimento-poupanca-resgatar',
    templateUrl: '../../../views/investimento/poupanca/poupanca-resgatar.html',
})

export class PoupancaResgatarComponent {

    constructor(private webService : WebService , public snackBar: MatSnackBar){}

    @Input() investimento;
    resgatar:number;
    bloqueo:number;
    async ngOnInit() {
        
        var response = await this.webService
            .getBloqueado(this.investimento.TipoInvestimento.id);
        this.bloqueo =  response.json();  
        this.resgatar = 0;
       
    }
    
    async valorResgatar(){
        
        this.investimento.valor = this.resgatar;
        if(this.resgatar <= this.investimento.TipoInvestimento.valor - this.bloqueo ){
            var response = await this.webService
                .putResgatar(this.investimento);

            var aux = response.json();
            console.log(aux);
            if(aux) {
                this.snackBar.open("valor restagado com sucesso!", "Ok", {
                    duration:3000,
                }); 
                location.reload();  
            } else {
                this.snackBar.open("Falhou", "", {
                    duration:3000,
                });
            }
        }else{
            this.snackBar.open("valor bloqueado ou valor investido insuficiente", "", {
                duration:3000,
            });
        }
    }
    
}