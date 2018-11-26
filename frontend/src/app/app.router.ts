import { Routes, RouterModule } from '@angular/router';

import { ContaComponent } from './conta.component';


import { ContaCorrenteComponent } from './contaCorrente/conta-corrente.component';
import { ContaCorrenteExtratoComponent } from './contaCorrente/conta-corrente-extrato.component';
import { ContaCorrenteDepositoComponent } from './contaCorrente/conta-corrente-deposito.component';
import { ContaCorrenteSaqueComponent } from './contaCorrente/conta-corrente-saque.component';
import { ContaCorrenteDebitoComponent } from './contaCorrente/conta-corrente-debito.component';

import { DebitoExcluirComponent } from './contaCorrente/debito/debito-excluir.component';
import { DebitoConsultarComponent } from './contaCorrente/debito/debito-consultar.component';
import { DebitoCadastrarComponent } from './contaCorrente/debito/debito-cadastrar.component';

export const ROUTES : Routes = [
    { path: '', component: ContaComponent } ,
    { path: 'conta-corrente', component: ContaCorrenteComponent },
    { path: 'conta-corrente-deposito', component: ContaCorrenteDepositoComponent },
    { path: 'conta-corrente-extrato', component: ContaCorrenteExtratoComponent }, 
    { path: 'conta-corrente-saque', component: ContaCorrenteSaqueComponent }, 

    // { path: 'conta-corrente-debito', component: ContaCorrenteDebitoComponent, 
    //     children: [
    //     { path: 'debito-excluir', component: DebitoExcluirComponent },
    //     { path: 'debito-cadastrar', component: DebitoCadastrarComponent },
    //     { path: 'debito-consultar', component: DebitoConsultarComponent }
    //   ] }, 
    { path: 'conta-corrente-debito', component: ContaCorrenteDebitoComponent },
    { path: 'conta-corrente-debito/debito-excluir', component: DebitoExcluirComponent },
    { path: 'conta-corrente-debito/debito-cadastrar', component: DebitoCadastrarComponent },
    { path: 'conta-corrente-debito/debito-consultar', component: DebitoConsultarComponent },
  

    


]