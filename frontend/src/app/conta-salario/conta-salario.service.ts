import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContaSalario } from './conta-salario';
import { Saque } from './saque';

@Injectable({
  providedIn: 'root'
})
export class ContaSalarioService {

  private readonly API = 'http://localhost:3000/contasalario';

  private readonly API2 = 'https://localhost:44397/api/contasalario/2';

  private readonly SACAR = 'https://localhost:44397/api/contasalario/saque';

  private readonly DEPOSITAR = 'https://localhost:44397/api/contasalario/deposito';

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get<ContaSalario>(this.API2);
  }

  sacar(saque) {
    return this.http.post<ContaSalario>(this.SACAR, saque);
  }

  depositar(deposito) {
    return this.http.post<ContaSalario>(this.DEPOSITAR, deposito);
  }
}
