import { Component, OnInit } from '@angular/core';

import { ContaSalarioService } from './conta-salario.service';

@Component({
  selector: 'app-conta-salario-deposito',
  templateUrl: './views/conta-salario-deposito.component.html',
  styleUrls: ['./css/conta-salario.component.css']
})
export class ContaSalarioDepositoComponent implements OnInit {

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

  depositar(value) {
    if(value <= 0) {
      alert("valor inválido");
      return false;
    } else {
      alert(value);
      this.service.depositar({
        "idContaSalario": this.id,
        "valor": value
      }).subscribe(
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
  }

}
