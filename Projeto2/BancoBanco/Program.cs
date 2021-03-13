using System;
using System.Collections.Generic;
using BancoBanco.Classes;

namespace BancoBanco
{
  class Program
  {

    static List<Conta> listaDeContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoSelecionada = MenuOpcoes();
      while (opcaoSelecionada.ToUpper() != "X")
      {
        switch (opcaoSelecionada)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirConta();
            break;
          case "3":
            Transferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoSelecionada = MenuOpcoes();
      }
      Console.WriteLine("O BancoBanco agradeçe sua preferência!");
      Console.ReadLine();
    }

    // Funções

    private static void ListarContas()
    {
      Console.WriteLine("Lista de Clientes!");
      Console.WriteLine();

      if (listaDeContas.Count == 0)
      {
        Console.WriteLine("Nenhum Cliente cadastrado :c");
        return;
      }
      for (int i = 0; i < listaDeContas.Count; i++)
      {
        Conta conta = listaDeContas[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static void InserirConta()
    {
      Console.WriteLine("Cadastro de novo cliente");
      Console.WriteLine();
      Console.WriteLine("1 - Pessoa Física");
      Console.WriteLine("2 - Pessoa Jurídica");
      Console.Write("Digite qual o tipo de cliente: ");
      int escolhaTipoDaConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o NOME do cliente: ");
      string nomeCliente = Console.ReadLine();

      Console.Write("Digite o SALDO INICIAL do cliente: ");
      double saldoInicial = double.Parse(Console.ReadLine());

      Console.Write("Digite o CRÉDITO do cliente: ");
      double creditoCliente = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta
      (tipo: (Tipo)escolhaTipoDaConta,
      saldo: saldoInicial,
      credito: creditoCliente,
      nome: nomeCliente);

      listaDeContas.Add(novaConta);

      Console.WriteLine("{0} cadastrado com sucesso!", nomeCliente);
      Console.ReadLine();
    }

    private static void Transferir()
    {
      Console.WriteLine("TRANSFERÊNCIA");
      Console.WriteLine();

      Console.Write("Digite o número da sua conta: ");
      int numeroTransferidor = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta a receber a transferência: ");
      Conta receptor = listaDeContas[int.Parse(Console.ReadLine())];

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listaDeContas[numeroTransferidor].Transferir(valorTransferencia, receptor);
    }

    private static void Sacar()
    {
      Console.WriteLine("SAQUE");
      Console.WriteLine();

      Console.Write("Digite o número da conta: ");
      int numeroConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor do saque: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listaDeContas[numeroConta].Sacar(valorSaque);
    }

    private static void Depositar()
    {
      Console.WriteLine("DEPÓSITO");
      Console.WriteLine();

      Console.Write("Digite o número da conta: ");
      int numeroConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor depositado: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      listaDeContas[numeroConta].Depositar(valorDeposito);
    }

    private static string MenuOpcoes()
    {
      Console.WriteLine();
      Console.WriteLine("BancoBanco, o Banco mais Banco que o Banco da fila de espera do seu Banco!");
      Console.WriteLine();
      Console.WriteLine("1 - Listar contas.");
      Console.WriteLine("2 - Inserir nova conta.");
      Console.WriteLine("3 - Transferir.");
      Console.WriteLine("4 - Sacar.");
      Console.WriteLine("5 - Depositar.");
      Console.WriteLine("X - Sair.");
      Console.WriteLine();
      Console.Write("Informe a opção desejada: ");

      string opcao = Console.ReadLine().ToUpper();
      Console.WriteLine();
      Console.Clear();
      return opcao;
    }
  }
}
