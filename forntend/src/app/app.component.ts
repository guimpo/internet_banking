import { Component, ViewChild  } from '@angular/core';
// import { MenssageComponent } from './menssage.component';
// import { NewMenssageComponent} from './new-mensagens.component';


import { ContaCorrenteComponent } from './contaCorrente/conta-corrente.component';
import { ContaCorrenteExtratoComponent } from './contaCorrente/conta-corrente-extrato.component';


//nome de tag denifido no component coresponte veja cada TS vai saber o que aconteceu  
@Component({
  selector: 'app-root',
  template: `    
      <router-outlet></router-outlet>
      `,
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  // //esquema para atualizar em tempo real
  // @ViewChild(MenssageComponent) messages : MenssageComponent;

  // onPosted(message) {
  //   this.messages.mensagens .push(message);
  // }
 
}
