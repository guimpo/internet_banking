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
        
      
        this.resgatar = 0;
       console.log(this.investimento);
    }
    
    async valorResgatar(){
    
        if(this.investimento.TipoInvestimento.valor >= this.resgatar){
            this.investimento.valor = this.resgatar;
            var response = await this.webService
                .postResgatar(this.investimento);

            var aux = response.json();
            console.log(aux);
            if(aux) {
                this.snackBar.open("valor restagado com sucesso!", "Ok", {
                    duration:3000,
                }); 
                location.reload();  
            } else {
                this.snackBar.open("Falha", "", {
                    duration:3000,
                });
            }
        }else{
            this.snackBar.open("valor investido insuficiente", "", {
                duration:3000,
            });
        }
    }
    
}