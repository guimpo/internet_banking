import { Component ,  Output, EventEmitter } from '@angular/core'

//tem que importa o que foi criado tal sera webservice
import { WebService } from './web.service';


@Component({
    selector: 'new-mensagem',
    template: `
        <mat-card style="margin:18px;"> 
            <mat-card-content>
                <mat-form-field>
                    <input [(ngModel)]="message.nome" matInput placeholder="Name">
                </mat-form-field>
                <mat-form-field>
                    <input [(ngModel)]="message.sobrenome" matInput placeholder="Sobrenome">
                </mat-form-field>
                <mat-card-actions>
                    <button (click)="post()" mat-button color="primary">POST</button>
                </mat-card-actions>
            </mat-card-content>
        </mat-card>
              `,
  })
  export class NewMenssageComponent {
//  atualiza em tempo real
    @Output() onPosted = new EventEmitter();


    constructor(private webService : WebService){}
//  iniciando menssage
    message = {
        nome: "",
        sobrenome: ""
    }
    post(){
        this.webService.postMessage(this.message);

        //  atualiza pagina em tempo real 
        this.onPosted.emit(this.message);
    }
  }