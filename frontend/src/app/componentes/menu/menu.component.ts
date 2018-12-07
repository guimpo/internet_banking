import { Component, OnInit, Input } from '@angular/core';
import { MenuService } from './menu.service';
import { Conta } from './conta';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  conta: Conta

  constructor(private service: MenuService) { 

  }

  async ngOnInit() {
    this.conta = await this.service.getConta()
    console.log(this.conta)
  }

}
