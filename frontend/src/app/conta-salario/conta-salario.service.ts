import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContaSalario } from './conta-salario';

@Injectable({
  providedIn: 'root'
})
export class ContaSalarioService {

  private readonly API = 'http://localhost:3000/contasalario';

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get<ContaSalario>(this.API);
  }
}
