import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { MaterialModule } from './material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CdkTableModule } from '@angular/cdk/table';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkTreeModule } from '@angular/cdk/tree';

//tem que importar os Components 
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';

// Conta corrente
import { ContaComponent } from './conta.component';
import { ContaCorrenteComponent } from './contaCorrente/conta-corrente.component';
import { ContaCorrenteExtratoComponent } from './contaCorrente/conta-corrente-extrato.component';
import { ContaCorrenteDepositoComponent } from './contaCorrente/conta-corrente-deposito.component';
import { ContaCorrenteSaqueComponent } from './contaCorrente/conta-corrente-saque.component';
import { ContaCorrenteDebitoComponent } from './contaCorrente/conta-corrente-debito.component';

// Investimento
import { ContaCorrenteInvestimentoComponent } from './contaCorrente/conta-corrente-investimento.component';

// Poupanca
import { PoupancaComponent } from './contaCorrente/investimento/poupanca/poupanca.component';
import { PoupancaAplicarComponent } from './contaCorrente/investimento/poupanca/poupanca-aplicar.component';
import { PoupancaResgatarComponent } from './contaCorrente/investimento/poupanca/poupanca-resgatar.component';

// Selic
import { SelicComponent } from './contaCorrente/investimento/selic/selic.component';
import { SelicAplicarComponent } from './contaCorrente/investimento/selic/selic-aplicar.component';
import { SelicResgatarComponent } from './contaCorrente/investimento/selic/selic-resgatar.component';

// Emprestimo
import { ContaCorrenteEmprestimoComponent } from './contaCorrente/conta-corrente-emprestimo.component';
import { EmprestimoPagarComponent } from './contaCorrente/emprestimo/emprestimo-pagar.component';
import { EmprestimoRealizarComponent } from './contaCorrente/emprestimo/emprestimo-realizar.component';
import { EmprestimoSimularComponent } from './contaCorrente/emprestimo/emprestimo-simular.component';

//Débito automatico
import { DebitoCadastrarComponent } from './contaCorrente/debito/debito-cadastrar.component';
import { DebitoConsultarComponent } from './contaCorrente/debito/debito-consultar.component';

//coisa de comunicacao ao servidor
import { WebService } from './web.service';
import { HttpModule } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';

//todos relacionado com routes
import { RouterModule, Routes} from '@angular/router';
import { ROUTES } from './app.router';

// Componentes
import { ComponentesModule } from  './componentes/componentes.module';

// Tesouro Prefixado LTN
import { TesouroPrefixadoLtnComponent } from './contaCorrente/investimento/tesouro-prefixado-ltn/tesouro-prefixado-ltn.component';
import { TesouroPrefixadoLtnSimuladorComponent } from './contaCorrente/investimento/tesouro-prefixado-ltn/tesouro-prefixado-ltn-simulador/tesouro-prefixado-ltn-simulador.component';

@NgModule({
  declarations: [
    AppComponent,
    ContaComponent,
    DebitoCadastrarComponent,
    DebitoConsultarComponent,
    ContaCorrenteComponent,
    ContaCorrenteInvestimentoComponent,
    PoupancaAplicarComponent,
    PoupancaResgatarComponent,
    PoupancaComponent,
    SelicComponent,
    SelicAplicarComponent,
    SelicResgatarComponent,
    ContaCorrenteEmprestimoComponent, 
    EmprestimoRealizarComponent,
    EmprestimoPagarComponent,
    EmprestimoSimularComponent,
    ContaCorrenteExtratoComponent,
    ContaCorrenteDepositoComponent,
    ContaCorrenteSaqueComponent,
    ContaCorrenteDebitoComponent,
    TesouroPrefixadoLtnComponent,
    TesouroPrefixadoLtnSimuladorComponent
  ],
  imports: [
    MaterialModule,
    BrowserModule,
    BrowserAnimationsModule,
    CdkTableModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    ComponentesModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [WebService],
  bootstrap: [AppComponent],

  exports: [
    MaterialModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    ScrollingModule
  ]
})

export class AppModule { }
