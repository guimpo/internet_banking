import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-conta-salario',
  templateUrl: './conta-salario.component.html',
  styleUrls: ['./conta-salario.component.css']
})
export class ContaSalarioComponent implements OnInit {

  saldo: number;
  letras: string[] = ['a', 'b', 'c'];

  constructor() {
    this.saldo = 500.0;

    for (let i = 0; i < this.letras.length; i++) {
      let l = this.letras[i];
    }
  }

  ngOnInit() {

  }

}
