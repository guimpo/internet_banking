import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Conta } from './conta';


@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private readonly API = `${environment.API}` + '/transacao/login/1'

  constructor(private http: HttpClient) { }

  async getConta(): Promise<Conta> {
    return await this.http.get<Conta>(this.API).toPromise()
  }
}
