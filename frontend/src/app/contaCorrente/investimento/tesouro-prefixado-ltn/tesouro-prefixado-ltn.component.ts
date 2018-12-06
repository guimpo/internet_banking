import { Component, OnInit} from '@angular/core';

import { TesouroPrefixadoLtnService } from './tesouro-prefixado-ltn.service';

@Component({
  selector: 'app-tesouro-prefixado-ltn',
  templateUrl: './tesouro-prefixado-ltn.component.html',
  styleUrls: ['./tesouro-prefixado-ltn.component.css']
})
export class TesouroPrefixadoLtnComponent implements OnInit {

  titulo: string


  
  constructor(private tesouroPrefixadoLtnService: TesouroPrefixadoLtnService) {
    this.titulo = "Tesouro Prefixado (LTN)"
  }

  ngOnInit() {
  }

}
