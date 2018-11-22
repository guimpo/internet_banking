

import { Http } from '@angular/http';
import { Injectable } from '@angular/core';



// arquivo que comunica com  servidor
@Injectable()
export class WebService {

    //url dinamica
    BASE_URL = 'https://localhost:44397/api';

    constructor(private http : Http){

    }

    getMensagens(){
        return this.http.get(this.BASE_URL + '/mensagens').toPromise();
    }

    postMessage(message) {
        return this.http.post(this.BASE_URL + '/mensagens', message).toPromise();
    }
}
