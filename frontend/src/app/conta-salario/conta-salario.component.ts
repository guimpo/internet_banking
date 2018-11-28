import { Component, OnInit } from '@angular/core';
import { ContaSalarioService } from './conta-salario.service';

@Component({
  selector: 'app-conta-salario',
  templateUrl: './conta-salario.component.html',
  styleUrls: ['./conta-salario.component.css']
})
export class ContaSalarioComponent implements OnInit {

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

  saque(value) {
    //console.log(value);
    alert("clicou!");
  }

  voltar() {
    alert("voltou!");
  }

}
