import { Component } from '@angular/core'



@Component({
    selector: 'debito-cadastrar',
    templateUrl: '../../views/debito/debito-cadastrar.html',
    styleUrls: ['../../views/css/debito-cadastrar.css'],
})
export class DebitoCadastrarComponent {

    estados: string [] = [ 
        'Paraná' , 'Santa Catarina' , 'São Paulo' , 'Minas Gerais' , 'Rio de janeiro' ];

    contas: string [] = [ 'Gás'  , 'luz' , 'água' , 'telefone' ];    

}
