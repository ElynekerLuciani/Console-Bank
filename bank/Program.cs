using System;
using System.Collections.Generic;
using bank.model;

namespace Bank
{
    class Program
    {
        static List<Conta> listaDeContas = new List<Conta>();

        static void Main(string[] args)
        {
            Console.WriteLine("");

            var opçãoDoUsuario = MenuDeUsuario();

            while (opçãoDoUsuario != "X")
            {
                switch (opçãoDoUsuario)
                {
                    case "1":
                        Depositar();
                        break;
                    case "2":
                        Sacar();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        CriarNovaConta();
                        break;
                    case "5":
                        ListarContas();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                opçãoDoUsuario = MenuDeUsuario();
            }
        }

        private static string MenuDeUsuario()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("|          Banco DIO          |");
            Console.WriteLine("===============================");
            Console.WriteLine("");
            Console.WriteLine("|   Informe a opção desejada  |");
            Console.WriteLine("|(1) Depositar                |");
            Console.WriteLine("|(2) Sacar                    |");
            Console.WriteLine("|(3) Transferir               |");
            Console.WriteLine("|(4) Criar nova conta         |");
            Console.WriteLine("|(5) Listar contas            |");
            Console.WriteLine("");
            Console.WriteLine("===============================");

            string opçãoDesejada = Console.ReadLine().ToUpper();
            return opçãoDesejada;

        }

        private static void CriarNovaConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("|Informe os dados a seguir:   |");
            Console.WriteLine("===============================");
            Console.WriteLine("");

            Console.WriteLine("Digite 1 para Conta Pessoa Física ou 2 para Conta Pessoa Jurídica");
            int tipoDaConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Defina o saldo inicial da conta");
            double saldoDaConta = double.Parse(Console.ReadLine());

            Console.WriteLine("Defina o limite de crédito disponível para essa conta");
            double limiteDaConta = double.Parse(Console.ReadLine());

            var novaConta = new Conta((EConta)tipoDaConta, saldoDaConta, limiteDaConta, nomeCliente);

            listaDeContas.Add(novaConta);
            Console.WriteLine("Uma nova conta foi criada.");

        }

        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("|Informe os dados a seguir:   |");
            Console.WriteLine("===============================");
            Console.WriteLine("");

            Console.WriteLine("Qual o número da conta?");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o valor do depósito?");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaDeContas[numeroConta].Depositar(valorDeposito);
            Console.WriteLine("Operação finalizada.");
        }

        private static void Sacar()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("|Informe os dados a seguir:   |");
            Console.WriteLine("===============================");
            Console.WriteLine("");

            Console.WriteLine("Qual o número da conta?");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o valor do saque?");
            double valorDoSaque = double.Parse(Console.ReadLine());

            listaDeContas[numeroConta].Sacar(valorDoSaque);
            Console.WriteLine("Operação finalizada.");
        }

        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("|Informe os dados a seguir:   |");
            Console.WriteLine("===============================");
            Console.WriteLine("");

            Console.WriteLine("Qual o número da conta de origem?");
            int numeroContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o número da conta de destino?");
            int numeroContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o valor da transferência?");
            double valorDaTransferencia = double.Parse(Console.ReadLine());

            listaDeContas[numeroContaOrigem].Transferir(valorDaTransferencia, listaDeContas[numeroContaDestino]);
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("|Listas de Contas Cadastradas  |");
            Console.WriteLine("===============================");
            Console.WriteLine("");

            if (listaDeContas.Count == 0)
                Console.WriteLine("Nenhuma conta cadastrada");

            for (int i = 0; i < listaDeContas.Count; i++)
            {
                Conta conta = listaDeContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);

            }
        }

    }
}
