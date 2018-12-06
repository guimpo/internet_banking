
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatToolbarModule} from '@angular/material/toolbar';
import { MenuComponent } from './menu/menu.component';


@NgModule({
  declarations: [MenuComponent],
  imports: [
    CommonModule,
    MatToolbarModule
  ],
  exports: [MatToolbarModule, MenuComponent]

})
export class ComponentesModule { }
