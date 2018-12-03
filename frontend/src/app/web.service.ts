

import { Http } from '@angular/http';
import { Injectable } from '@angular/core';



// arquivo que comunica com  servidor
@Injectable()
export class WebService {

    //url dinamica
    BASE_URL = 'https://localhost:44397/api';

    constructor(private http : Http){

    }

    // TESTES
    getMensagens(){
        return this.http.get(this.BASE_URL + '/mensagens').toPromise();
    }

    postMessage(message) {
        return this.http.post(this.BASE_URL + '/mensagens', message).toPromise();
    }
    ///////////


    // CONTA CORRENT ----
    postTransacao(transacao) {
        return this.http.post(this.BASE_URL + '/transacao', transacao).toPromise();
    }

    getTransacao(){
        return this.http.get(this.BASE_URL + '/transacao').toPromise();
    }

    getLogin(id){
        return this.http.get(this.BASE_URL + '/transacao/login/' + id).toPromise();
    }

    getExtrato(){
        return this.http.get(this.BASE_URL + '/transacao').toPromise();
    }

    postCadastrarConta(conta) {
        return this.http.post(this.BASE_URL + '/conta', conta).toPromise();
    }

    getContaCadastrada(){
        return this.http.get(this.BASE_URL + '/conta').toPromise();
    }

    deleteContaCadastrada(id){
        return this.http.delete(this.BASE_URL + '/conta/'+ id).toPromise();
    }

    valida(valor) {
        return this.http.get(this.BASE_URL + '/transacao/valida/' + valor).toPromise();
    }
    ///////


    //INVESTIMENTO -----
    getPopanca(){
        return this.http.get(this.BASE_URL + '/investimento/poupanca').toPromise();
    }

    getSelic(){
        return this.http.get(this.BASE_URL + '/investimento/selic').toPromise();
    }

    //EMPRESTIMO -----
    postEmprestimo(emprestimo) {
        return this.http.post(this.BASE_URL + '/emprestimo', emprestimo).toPromise();
    }

    simular(emprestimo) {
        return this.http.post(this.BASE_URL + '/emprestimo/simular', emprestimo).toPromise();
    }
    
}
