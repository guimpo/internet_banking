import './polyfills';

import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {HttpClientModule} from '@angular/common/http';
import {MatNativeDateModule} from '@angular/material';
import {ContaCorrenteExtratoComponent} from './app/contaCorrente/conta-corrente-extrato.component';

if (environment.production) {
  enableProdMode();
}

  @NgModule({
    imports: [
      BrowserModule,
      BrowserAnimationsModule,
      FormsModule,
      HttpClientModule,
      AppModule,
      MatNativeDateModule,
      ReactiveFormsModule,
    ],
    entryComponents: [ContaCorrenteExtratoComponent],
    declarations: [ContaCorrenteExtratoComponent],
    bootstrap: [ContaCorrenteExtratoComponent],
    providers: []
  })
  export class demoModule {}

  platformBrowserDynamic().bootstrapModule(AppModule).catch(err => console.error(err));;
  



 
  
