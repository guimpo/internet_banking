import { Component } from '@angular/core'
// import { WebService } from '../web.service';
import {Router} from '@angular/router';

@Component({
    selector: 'conta-corrente',
    template: `
            <mat-card style="margin:18px;"> 
                <mat-card-content>
                    <mat-card-actions>
                        <button  routerLink="/investimento/poupanca/investimento" mat-button color="primary">POUPANCA</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card>
            <mat-card style="margin:18px;"> 
                <mat-card-content>
                    <mat-card-actions>
                        <button  routerLink="/conta-corrente-extrato" mat-button color="primary">SELIC</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card> 
    `,
  })
  export class ContaCorrenteInvestimentoComponent {
    constructor( ){


    }
  }