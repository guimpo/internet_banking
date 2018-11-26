import { Component } from '@angular/core'
// import { WebService } from '../web.service';

import {Router} from '@angular/router';

@Component({
    selector: 'conta-corrente',
    template: `
            <mat-card style="margin:18px;"> 
                <mat-card-content>
                    <mat-card-actions>
                        <button routerLink="/conta-corrente-deposito" mat-button color="primary">Depósito</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card>
            <mat-card style="margin:18px;"> 
                <mat-card-content>
                    <mat-card-actions>
                        <button  routerLink="/conta-corrente-extrato" mat-button color="primary">Extrato</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card> 
            <mat-card style="margin:18px;">    
                <mat-card-content>
                    <mat-card-actions>
                        <button routerLink="/conta-corrente-saque" mat-button color="primary">Saque</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card>  
            <mat-card style="margin:18px;">   
                <mat-card-content>
                    <mat-card-actions>
                        <button routerLink="/conta-corrente-debito" mat-button color="primary">Débito em conta</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card>
              `,
  })
  export class ContaCorrenteComponent {
    // constructor(private webService : WebService){}
    // private router: Router;
    constructor( ){}

    deposito(){
        console.log("kao");
        // this.router.navigate(['/conta-extrato']);
    }
    extrato(){

    }
    saque(){

    }
    debito(){

    }

  }