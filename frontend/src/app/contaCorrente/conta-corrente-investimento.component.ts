import { Component,  EventEmitter } from '@angular/core'
// import { WebService } from '../web.service';
import {Router} from '@angular/router';
import { Injectable } from '@angular/core';




@Component({
    selector: 'conta-corrente',
    template: `
            <mat-card style="margin:18px;"> 
                <mat-card-content>
                    <mat-card-actions>
                        <button   routerLink="/conta-corrente-investimento-poupanca" mat-button color="primary">POUPANÇA</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card>
            <mat-card style="margin:18px;"> 
                <mat-card-content>
                    <mat-card-actions>
                        <button  routerLink="/conta-corrente-investimento-selic" mat-button color="primary">SELIC</button>
                    </mat-card-actions>
                </mat-card-content>
            </mat-card> 
    `,
  })
  export class ContaCorrenteInvestimentoComponent {
    constructor( ){}


  }