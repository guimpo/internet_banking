import { Component } from '@angular/core'

@Component({
    selector: 'conta',
    template: `
    <mat-card style="margin:18px;"> 
        <mat-card-content>
            <mat-card-actions>
                <button routerLink="/conta-corrente" mat-button color="primary">Conta corrente</button>
            </mat-card-actions>
        </mat-card-content>
    </mat-card>

    <mat-card style="margin:18px;"> 
        <mat-card-content>
            <mat-card-actions>
                <button  mat-button color="primary">Conta Salário</button>
            </mat-card-actions>
        </mat-card-content>
    </mat-card>
    `,
})
export class ContaComponent {

}