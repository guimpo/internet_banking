import { Component, OnInit } from '@angular/core';
import { ContaSalarioService } from './conta-salario.service';

@Component({
  selector: 'app-conta-salario',
  templateUrl: './conta-salario.component.html',
  styleUrls: ['./conta-salario.component.css']
})
export class ContaSalarioComponent implements OnInit {

  id: number;
  nome: string;
  saldo: number;
  letras: string[] = [ "a", "b", "c"];

  constructor(private service: ContaSalarioService) {
    
  }

  ngOnInit() {
    this.service.get().subscribe(
      conta => {
        this.id = conta.id;
        this.nome = conta.nome;
        this.saldo = conta.saldo;
    });
  }

}
