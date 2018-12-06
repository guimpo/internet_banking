import { Component, Input } from '@angular/core';
import {MatSort, MatTableDataSource, FloatLabelType} from '@angular/material';
import { WebService } from '../../../web.service';

@Component({
    selector: 'investimento-poupanca-aplicar',
    templateUrl: '../../../views/investimento/poupanca/poupanca-aplicar.html',
    styleUrls: ['../../../views/css/sort-overview-example.css'],

})

export class PoupancaAplicarComponent {

    constructor(private webService : WebService) { }
    @Input() investimento;


    async ngOnInit() {
        console.log(this.investimento);
       
    } 
    async Torendimento(){
        var response = await this.webService.postInvestido(this.investimento);
        location.reload();
    }
}