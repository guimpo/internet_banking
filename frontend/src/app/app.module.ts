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
  MatToolbarModule,
  MatSelectModule,
  MatTableModule
} from '@angular/material';
import {CdkTableModule} from '@angular/cdk/table';

//tem que importar os Components 
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { ContaComponent } from './conta.component';
import { ContaCorrenteComponent } from './contaCorrente/conta-corrente.component';
import { ContaCorrenteExtratoComponent } from './contaCorrente/conta-corrente-extrato.component';
import { ContaCorrenteDepositoComponent } from './contaCorrente/conta-corrente-deposito.component';
import { ContaCorrenteSaqueComponent } from './contaCorrente/conta-corrente-saque.component';
import { ContaCorrenteDebitoComponent } from './contaCorrente/conta-corrente-debito.component';
import { DebitoCadastrarComponent } from './contaCorrente/debito/debito-cadastrar.component';
import { DebitoConsultarComponent } from './contaCorrente/debito/debito-consultar.component';

//contasalario
import { ContaSalarioExtratoComponent } from './conta-salario/conta-salario-extrato.component';
import { ContaSalarioSaqueComponent } from './conta-salario/conta-salario-saque.component';
import { ContaSalarioDepositoComponent } from './conta-salario/conta-salario-deposito.component';


//coisa de comunicacao ao servidor
import { WebService } from './web.service';
import { HttpModule } from '@angular/http';
import { HttpClient } from '@angular/common/http';

//todos relacionado com routes
import { RouterModule, Routes} from '@angular/router';
import { ROUTES } from './app.router';


import {DragDropModule} from '@angular/cdk/drag-drop';
import {ScrollingModule} from '@angular/cdk/scrolling';

import {CdkTreeModule} from '@angular/cdk/tree';

//tem que importar os elementos do html 
import {

  MatAutocompleteModule,
  MatBadgeModule,
  MatBottomSheetModule,

  MatButtonToggleModule,


  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,

  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,

  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
 
  MatSortModule,
  MatStepperModule,

  MatTabsModule,

  MatTooltipModule,
  MatTreeModule,
  

} from '@angular/material';

import { ContaSalarioComponent } from './conta-salario/conta-salario.component';
import { HttpClientModule } from '@angular/common/http';

//o que importa em cima tem que copiar para abaixo tambem, Component no declarations
//Module no imports, WebService no providers
@NgModule({
  declarations: [
    AppComponent,
    // MenssageComponent,
    // NewMenssageComponent,
    ContaComponent,
 
    DebitoCadastrarComponent,
    DebitoConsultarComponent,
    ContaCorrenteComponent,
    ContaCorrenteExtratoComponent,
    ContaCorrenteDepositoComponent,
    ContaCorrenteSaqueComponent,
    ContaCorrenteDebitoComponent,
    ContaSalarioComponent,
    ContaSalarioSaqueComponent,
    ContaSalarioExtratoComponent,
    ContaSalarioDepositoComponent
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
    MatSelectModule,
    MatTableModule,
    CdkTableModule,
    
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(ROUTES)   
    

  ],
  providers: [WebService],
  bootstrap: [AppComponent],

  exports: [
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    ScrollingModule,
  ]
})
export class AppModule { }
