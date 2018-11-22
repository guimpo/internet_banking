import { Component } from '@angular/core'
import { WebService } from './web.service';


// *ngFor= "let mensagen of mensagens    como for
@Component({
    selector: 'mensagem',
    template: `<h1>this is mensagem </h1> 
                
                <div *ngFor= "let mensagen of mensagens">
                  <mat-card style="margin:18px;"> 
                    <mat-card-title>{{ mensagen.nome }}</mat-card-title>
                    <mat-card-content>{{ mensagen.sobrenome }} </mat-card-content>
                  </mat-card>
                </div>
                <button mat-button>teste</button>
              `,
  })
  export class MenssageComponent {
    constructor(private webService : WebService){}


    //async e await para esperar reponse. com isso erro desaparece
    async ngOnInit(){

      //recebe do servidor
      var response = await this.webService.getMensagens();
      console.log(response.json());

      //vai mostrar la em cima cooresponte
      this.mensagens = response.json();
    }
    mensagens = [ ];
  }