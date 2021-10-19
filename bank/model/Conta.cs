using System;

namespace bank.model
{
    public class Conta
    {
        private EConta Tipo { get; set; }
        private double Saldo { get; set; }
        private double Limite;

        private string Nome { get; set; }

        public Conta(EConta tipo, double saldo, double limite, string nome)
        {
            this.Tipo = tipo;
            this.Saldo = saldo;
            this.Limite = limite;
            this.Nome = nome;
        }


        public bool Sacar(double valorDoSaque)
        {
            if (this.Saldo - valorDoSaque < (this.Limite * -1))
            {
                Console.WriteLine("Seu saldo é insuficiente");
                return false;
            }

            this.Saldo -= valorDoSaque;
            Console.WriteLine("Saque realizado!");
            Console.WriteLine("Seu saldo atual é de {0}", this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("{0}, o saldo atual da conta é de {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.Tipo + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Limite " + this.Limite;
            return retorno;
        }


    }
}