import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  @Input()
  numero: number

  @Input()
  agencia: string

  constructor() { 
    this.numero = 123456
    this.agencia = '654321-x'
  }

  ngOnInit() {
  }

}
