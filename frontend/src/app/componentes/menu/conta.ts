export interface Conta {
    id: number;
    numero: number;
    agencia: string;
    saldo: number;
    tipoConta: number;
    pessoa: {
        id: number;
        nome: string;
    }
}