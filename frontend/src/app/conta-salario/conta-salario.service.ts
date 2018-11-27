import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContaSalario } from './conta-salario';

@Injectable({
  providedIn: 'root'
})
export class ContaSalarioService {

  private readonly API = 'http://localhost:3000/contasalario';

  private readonly API2 = 'https://localhost:44397/api/contasalario/2'

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get<ContaSalario>(this.API2);
  }
}
