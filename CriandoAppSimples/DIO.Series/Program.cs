using System;

namespace DIO.Series
{
  class Program
  {
    static RepositorioDeSeries repositorio = new RepositorioDeSeries();
    static void Main()
    {
      int opcaoUsuario = MenuOps();

      while (opcaoUsuario != 6)
      {
        switch (opcaoUsuario)
        {
          case 1:
            ListarSeries();
            break;
          case 2:
            InserirSerie();
            break;
          case 3:
            AtualizarSerie();
            break;
          case 4:
            ExcluirSerie();
            break;
          case 5:
            VisualizarSerie();
            break;
          case 6:
            Console.Clear();
            return;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = MenuOps();
      }
    }
    private static int MenuOps()
    {
      Console.WriteLine();
      Console.WriteLine("Super Séries 5.000!");
      Console.WriteLine();
      Console.WriteLine("1 - Listar séries");
      Console.WriteLine("2 - Inserir nova série");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Excluir série");
      Console.WriteLine("5 - Visualizar série");
      Console.WriteLine("6 - Sair");
      Console.WriteLine();
      Console.Write("Digite sua opção: ");

      int opcaoUsuario = int.Parse(Console.ReadLine());
      return opcaoUsuario;
    }

    private static void ListarSeries()
    {
      Console.WriteLine("Listar séries");
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.RetornaExcluido();
        if (!excluido)
        {
          Console.WriteLine("#ID {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
        }
      }
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o gênero entre as opções listadas acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano de lançamento da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(
        id: repositorio.ProximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao);

      repositorio.Insere(novaSerie);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o gênero entre as opções listadas acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano de lançamento da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(
        id: indiceSerie,
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao);

      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());
      Console.WriteLine();
      Console.WriteLine($"Série escolhida: {repositorio.RetornaPorId(indiceSerie)}");
      Console.WriteLine("Deseja continuar? (S/N)");
      string continuar = Console.ReadLine();
      continuar = continuar.ToUpper();

      if (continuar == "S")
      {
        repositorio.Exclui(indiceSerie);
      }
      else return;
    }

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      Console.WriteLine(serie);
    }
  }
}
