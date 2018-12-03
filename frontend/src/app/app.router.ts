import { Routes, RouterModule } from '@angular/router';

import { ContaComponent } from './conta.component';

import { ContaCorrenteComponent } from './contaCorrente/conta-corrente.component';
import { ContaCorrenteExtratoComponent } from './contaCorrente/conta-corrente-extrato.component';
import { ContaCorrenteDepositoComponent } from './contaCorrente/conta-corrente-deposito.component';
import { ContaCorrenteSaqueComponent } from './contaCorrente/conta-corrente-saque.component';
import { ContaCorrenteDebitoComponent } from './contaCorrente/conta-corrente-debito.component';
import { ContaCorrenteInvestimentoComponent } from './contaCorrente/conta-corrente-investimento.component';

import { PoupancaComponent } from './contaCorrente/investimento/poupanca/poupanca.component';
import { PoupancaAplicarComponent } from './contaCorrente/investimento/poupanca/poupanca-aplicar.component';
import { PoupancaResgatarComponent } from './contaCorrente/investimento/poupanca/poupanca-resgatar.component';

import { SelicComponent } from './contaCorrente/investimento//selic/selic.component';


import { ContaCorrenteEmprestimoComponent } from './contaCorrente/conta-corrente-emprestimo.component';
import { EmprestimoPagarComponent } from './contaCorrente/emprestimo/emprestimo-pagar.component';
import { EmprestimoRealizarComponent } from './contaCorrente/emprestimo/emprestimo-realizar.component';
import { EmprestimoSimularComponent } from './contaCorrente/emprestimo/emprestimo-simular.component';

import { DebitoConsultarComponent } from './contaCorrente/debito/debito-consultar.component';
import { DebitoCadastrarComponent } from './contaCorrente/debito/debito-cadastrar.component';

import { ContaSalarioComponent } from './conta-salario/conta-salario.component';
import { ContaSalarioExtratoComponent } from './conta-salario/conta-salario-extrato.component';
import { ContaSalarioSaqueComponent } from './conta-salario/conta-salario-saque.component';
import { ContaSalarioDepositoComponent } from './conta-salario/conta-salario-deposito.component';


export const ROUTES : Routes = [
    { path: '', component: ContaComponent } ,
    { path: 'conta-corrente', component: ContaCorrenteComponent },
    { path: 'conta-corrente-deposito', component: ContaCorrenteDepositoComponent },
    { path: 'conta-corrente-extrato', component: ContaCorrenteExtratoComponent }, 
    { path: 'conta-corrente-saque', component: ContaCorrenteSaqueComponent }, 
    
    // INVESTIMENTO
    { path: 'conta-corrente-investimento', component: ContaCorrenteInvestimentoComponent},
    { path: 'conta-corrente-investimento-poupanca', component: PoupancaComponent,
        children: [
            { path: 'aplicar', component: PoupancaAplicarComponent },
            { path: 'resgatar', component: PoupancaResgatarComponent }
           
          ]
    }, 
    { path: 'conta-corrente-investimento-selic', component: SelicComponent,
    children: [
        { path: 'aplicar', component: PoupancaAplicarComponent },
        { path: 'resgatar', component: PoupancaResgatarComponent }
       
      ]
    }, 

    // EMPRESTIMO
    { path: 'conta-corrente-emprestimo', component: ContaCorrenteEmprestimoComponent }, 
    { path: 'conta-corrente-emprestimo/emprestimo-pagar', component: EmprestimoPagarComponent }, 
    { path: 'conta-corrente-emprestimo/emprestimo-realizar', component: EmprestimoRealizarComponent,
    children: [
        { path: 'emprestimo-simular', component: EmprestimoSimularComponent  }
       
      ]
    }, 
 
    { path: 'conta-corrente-debito', component: ContaCorrenteDebitoComponent },
 
    { path: 'conta-corrente-debito/debito-cadastrar', component: DebitoCadastrarComponent },
    { path: 'conta-corrente-debito/debito-consultar', component: DebitoConsultarComponent },

    { path: 'conta-salario', component: ContaSalarioComponent },
    { path: 'conta-salario-extrato', component: ContaSalarioExtratoComponent },
    { path: 'conta-salario-saque', component: ContaSalarioSaqueComponent },
    { path: 'conta-salario-deposito', component: ContaSalarioDepositoComponent },

    
   



]
