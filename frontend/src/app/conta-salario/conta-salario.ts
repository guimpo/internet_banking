export interface ContaSalario {
    id: number;
    numero: number;
    agencia: string;
    tipoConta: number;
    descricao: string;
    pessoa: {
        id: number;
        nome: string;
    };
    saldo: number;
}