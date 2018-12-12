import { Component, OnInit} from '@angular/core';
import { Location } from '@angular/common';


import { TesouroPrefixadoLtnService } from './tesouro-prefixado-ltn.service';

@Component({
  selector: 'app-tesouro-prefixado-ltn',
  templateUrl: './tesouro-prefixado-ltn.component.html',
  styleUrls: ['./tesouro-prefixado-ltn.component.css']
})
export class TesouroPrefixadoLtnComponent implements OnInit {

  titulo: string
  loadApresentacao: boolean
  loadSimulador: boolean
  btnLabel: string
  

  constructor(private tesouroPrefixadoLtnService: TesouroPrefixadoLtnService, private location: Location) {
    this.titulo = "Tesouro Prefixado (LTN)"
    this.loadApresentacao = true
    this.loadSimulador = false
    this.btnLabel = "Simular"
  }

  ngOnInit() {
  }

  simularClicked() {
    this.loadApresentacao = !this.loadApresentacao
    this.loadSimulador = !this.loadSimulador
    this.loadApresentacao ? this.btnLabel = "Simular" : this.btnLabel = "Apresentação"
  }

  backClicked() {
    this.location.back();
  }

}
