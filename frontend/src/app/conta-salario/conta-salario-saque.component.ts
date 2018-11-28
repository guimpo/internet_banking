import { Component, OnInit } from '@angular/core';

import { ContaSalarioService } from './conta-salario.service';

@Component({
  selector: 'app-conta-salario-saque',
  templateUrl: './views/conta-salario-saque.component.html',
  styleUrls: ['./css/conta-salario.component.css']
})
export class ContaSalarioSaqueComponent implements OnInit {

  id: number;
  numero: number;
  agencia: string;
  id_tipo_conta: number;
  descricao: string;
  id_pessoa: number;
  nome: string;
  saldo: number;


  constructor(private service: ContaSalarioService) {

  }

  ngOnInit() {
    this.service.get().subscribe(
      conta => {
        this.id = conta.id;
        this.numero = conta.numero;
        this.agencia = conta.agencia;
        this.id_tipo_conta = conta.tipoConta;
        this.descricao = conta.descricao;
        this.id_pessoa = conta.pessoa.id;
        this.nome = conta.pessoa.nome;
        this.saldo = conta.saldo;
    });
  }

  sacar(value) {
    if(value < 10) {
      alert("valor inválido");
      return false;
    } else {
      alert(value);
      this.service.sacar({
        "idContaSalario": this.id,
        "valor": value
      }).subscribe();
    }
  }

}
