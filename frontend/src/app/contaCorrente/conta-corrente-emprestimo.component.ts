import { Component,  Output, EventEmitter  } from '@angular/core'
import { WebService } from '../web.service';




@Component({
    selector: 'conta-corrente-emprestimo',
    template: `
    <mat-card style="margin:18px;"> 
        <mat-card-content>
            <mat-card-actions>
                <button routerLink="/conta-corrente-emprestimo/emprestimo-pagar" mat-button color="primary">Pagar</button>
            </mat-card-actions>
        </mat-card-content>
    </mat-card>
    <mat-card style="margin:18px;"> 
        <mat-card-content>
            <mat-card-actions>
                <button  routerLink="/conta-corrente-emprestimo/emprestimo-realizar" mat-button color="primary">Realizar</button>
            </mat-card-actions>
        </mat-card-content>
    </mat-card> 
    
    `,
})

export class ContaCorrenteEmprestimoComponent {


}