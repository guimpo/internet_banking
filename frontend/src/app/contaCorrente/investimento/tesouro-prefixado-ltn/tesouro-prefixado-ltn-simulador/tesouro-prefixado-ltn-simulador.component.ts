import { Component, OnInit } from '@angular/core';

export interface PeriodicElement {
  titulo: string;
  vencimento: string;
  rendimentoAnual: number;
  valorMinimo: number;
  precoUnitario: number;
}

export interface Resultado {
  descricao: string;
  valor: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { titulo: 'Tesouro Prefixado 2021', vencimento: '01/01/2021', rendimentoAnual: 7.80, valorMinimo: 34.28, precoUnitario: 857.19 },
  { titulo: 'Tesouro Prefixado 2025', vencimento: '01/01/2025', rendimentoAnual: 9.81, valorMinimo: 34.09, precoUnitario: 568.24 },
];

const CALCULO_LTN:  Resultado[] = [
  { descricao: 'Dias corridos entre a data de compra e a de vencimento',	valor: '751' },
  { descricao: 'Dias corridos entre a data de compra e a de venda', valor: '751' },
  { descricao: 'Dias úteis entre a data de compra e a de vencimento', valor: '517' },
  { descricao: 'Dias úteis entre a data de compra e a de venda', valor: '517' },
  { descricao: 'Valor investido líquido', valor: 'R$ 34,28' },
  { descricao: 'Rentabilidade bruta (a.a.)', valor: '7,80%' },
  { descricao: 'Taxa de Negociação (0,0%)', valor: 'R$ 0,00' },
  { descricao: 'Taxa de administração na entrada', valor: 'R$ 0,00' },
  { descricao: 'Valor investido bruto', valor: 'R$ 34,28' },
  { descricao: 'Valor bruto do resgate', valor: 'R$ 39,99' },
  { descricao: 'Valor da taxa de custódia do resgate', valor: 'R$ 0,23' },
  { descricao: 'Valor da taxa de administração do resgate', valor: 'R$ 0,00' },
  { descricao: 'Alíquota média de imposto de renda', valor: '15,00%' },
  { descricao: 'Imposto de renda', valor: 'R$ 0,82' },
  { descricao: 'Valor líquido do resgate', valor: 'R$ 38,94' },
  { descricao: 'Rentabilidade líquida após taxas e I.R. (a.a.)', valor: '6,41%' }
];


@Component({
  selector: 'app-tesouro-prefixado-ltn-simulador',
  templateUrl: './tesouro-prefixado-ltn-simulador.component.html',
  styleUrls: ['./tesouro-prefixado-ltn-simulador.component.css']
})
export class TesouroPrefixadoLtnSimuladorComponent implements OnInit {

  displayedColumns: string[] = [ 'titulo', 'vencimento', 'rendimentoAnual', 'valorMinimo', 'precoUnitario' ]
  dataSource = ELEMENT_DATA

  displayedColumns2: string[] = [ 'descricao', 'valor' ]
  dataSource2 = CALCULO_LTN

  showSimulacao: boolean

  constructor() { 
    this.showSimulacao = false

  }

  ngOnInit() {
  }

  calcularClicked() {
    this.showSimulacao = !this.showSimulacao
  }

}
