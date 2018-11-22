import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

//tem que importar os Components 
import { AppComponent } from './app.component';
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

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


import {DragDropModule} from '@angular/cdk/drag-drop';
import {ScrollingModule} from '@angular/cdk/scrolling';
import {CdkTableModule} from '@angular/cdk/table';
import {CdkTreeModule} from '@angular/cdk/tree';

//tem que importar os elementos do html 
import {

  MatAutocompleteModule,
  MatBadgeModule,
  MatBottomSheetModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
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
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatTreeModule,
  

} from '@angular/material';


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
    ContaCorrenteDebitoComponent    
    
    
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

    MatTableModule,
    DragDropModule,
    ScrollingModule,
    CdkTableModule,
    CdkTreeModule,

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
