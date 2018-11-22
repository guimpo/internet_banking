import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

//tem que importar os elementos do html 
import {
  MatButtonModule, 
  MatCheckboxModule, 
  MatCardModule,
  MatInputModule,
  MatSnackBarModule,
  MatToolbarModule
} from '@angular/material';

//tem que importar os Components 
import { AppComponent } from './app.component';
// import { MenssageComponent } from './menssage.component';
// import { NewMenssageComponent} from './new-mensagens.component';
import { FormsModule } from '@angular/forms';

import { ContaComponent } from './conta.component';
import { ContaCorrenteComponent } from './contaCorrente/conta-corrente.component';
import { ContaCorrenteExtratoComponent } from './contaCorrente/conta-corrente-extrato.component';
import { ContaCorrenteDepositoComponent } from './contaCorrente/conta-corrente-deposito.component';
import { ContaCorrenteSaqueComponent } from './contaCorrente/conta-corrente-saque.component';
import { ContaCorrenteDebitoComponent } from './contaCorrente/conta-corrente-debito.component';


//coisa de comunicacao ao servidor
import { WebService } from './web.service';
import { HttpModule } from '@angular/http';

//todos relacionado com routes
import { RouterModule, Routes} from '@angular/router';
import { ROUTES } from './app.router';
// import { DebitoExcluirComponent } from './contaCorrente/debito/debito-excluir.component';
// import { DebitoConsultarComponent } from './contaCorrente/debito/debito-consultar.component';
// import { DebitoCadastrarComponent } from './contaCorrente/debito/debito-cadastrar.component';

//o que importa em cima tem que copiar para abaixo tambem, Component no declarations
//Module no imports, WebService no providers
@NgModule({
  declarations: [
    AppComponent,
    // MenssageComponent,
    // NewMenssageComponent,
    ContaComponent,

    ContaCorrenteComponent,
    ContaCorrenteExtratoComponent,
    ContaCorrenteDepositoComponent,
    ContaCorrenteSaqueComponent,
    ContaCorrenteDebitoComponent,
   
    // DebitoExcluirComponent,
    // DebitoConsultarComponent,
    // DebitoCadastrarComponent
    
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,

    MatButtonModule, 
    MatCardModule,
    MatCheckboxModule,
    MatInputModule,
    MatSnackBarModule,
    MatToolbarModule,

    HttpModule,
    FormsModule,
    RouterModule.forRoot(ROUTES)
    

  ],
  providers: [WebService],
  bootstrap: [AppComponent]
})
export class AppModule { }
