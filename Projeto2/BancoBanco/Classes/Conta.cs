using System;
namespace BancoBanco.Classes
{
  public class Conta
  {
    // Atributos
    private Tipo TipoDaConta { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    // Constructors
    public Conta(Tipo tipo, double saldo, double credito, string nome)
    {
      this.TipoDaConta = tipo;
      this.Saldo = saldo;
      this.Credito = credito;
      this.Nome = nome;
    }

    // Metodos
    // Bool pois consegue retornar validação
    public bool Sacar(double valorDoSaque)
    {
      // Validação do Saldo do cliente
      // A diferença entre o saldo e o saque não pode ser menor que o negativo do crédito
      if (this.Saldo - valorDoSaque < (this.Credito * -1))
      {
        Console.WriteLine("Saldo insuficiente");
        return false;
      }
      // Realizando o saque
      this.Saldo -= valorDoSaque;
      Console.WriteLine("{0} seu saldo atual é de R${1}", this.Nome, this.Saldo);
      return true;
    }

    public void Depositar(double valorDoDeposito)
    {
      // Adicionando o deposito ao saldo
      this.Saldo += valorDoDeposito;
      Console.WriteLine("{0} seu saldo atual é de R${1}", this.Nome, this.Saldo);
    }

    public void Transferir(double valorDaTransferencia, Conta contaReceber)
    {
      // Primeiro se verifica o saldo na conta realizando a transferencia
      if (this.Sacar(valorDaTransferencia))
      {
        // Depositando o valor na conta receptora
        contaReceber.Depositar(valorDaTransferencia);
      }
    }

    // Sobrescrevendo o ToString pra que ele não retorne o tipo de objeto
    public override string ToString()
    {
      string retorno = "";
      retorno += "Tipo da Conta: " + this.TipoDaConta + " | ";
      retorno += "Nome: " + this.Nome + " | ";
      retorno += "Saldo: " + this.Saldo + " | ";
      retorno += "Crédito: " + this.Credito + " | ";
      return retorno;
    }
  }
}