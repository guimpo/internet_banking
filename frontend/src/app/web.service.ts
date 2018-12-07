

import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';



// arquivo que comunica com  servidor
@Injectable()
export class WebService {

    //url dinamica
    BASE_URL = `${environment.API}`;

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

    // getValorInvestido(id){
    //     return this.http.get(this.BASE_URL + '/investimento/investido/'+id).toPromise();
    // }

    putResgatar(investimento){
        return this.http.put(this.BASE_URL + '/investimento/resgatar/',investimento).toPromise();
    }
    getBloqueado(id){
        return this.http.get(this.BASE_URL + '/investimento/bloqueado/'+id).toPromise();
    }
    postInvestido(investimento){
        return this.http.post(this.BASE_URL + '/investimento/poupanca/', investimento).toPromise();
    }

    getPopanca(conta_id){
        return this.http.get(this.BASE_URL + '/investimento/poupanca/'+conta_id).toPromise();
    }

    getSelic(){
        return this.http.get(this.BASE_URL + '/investimento/selic').toPromise();
    }

    postAplicacaoSelic(aplicacao) {
        return this.http.post(this.BASE_URL + '/investimento/aplicar-selic',aplicacao).toPromise();
    }

    //EMPRESTIMO -----
    postEmprestimo(emprestimo) {
        return this.http.post(this.BASE_URL + '/emprestimo', emprestimo).toPromise();
    }

    simular(emprestimo) {
        return this.http.post(this.BASE_URL + '/emprestimo/simular', emprestimo).toPromise();
    }
    
    getParcelas(){
        return this.http.get(this.BASE_URL + '/emprestimo').toPromise();
    }

    boleto(parcela){
        return this.http.post(this.BASE_URL + '/emprestimo/boleto', parcela).toPromise();
    }

    codigo(parcela){
        return this.http.post(this.BASE_URL + '/emprestimo/codigo', parcela).toPromise();
    }
}
