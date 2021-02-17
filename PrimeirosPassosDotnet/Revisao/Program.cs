using System;

namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {
			int nAluno = 0;
			// Criando o array de Alunos
			Aluno[] alunos = new Aluno[30];
			int indiceAluno = 0;

			int opcaoEscolhida = MenuOps();
      
			// Laço de repetição
      while (opcaoEscolhida != 4)
      {
        // Executando a escolha do usuário
        switch (opcaoEscolhida)
        {
          case 1:
						Console.WriteLine("Informe o nome do aluno: ");
						Aluno aluno = new();
						aluno.Nome = Console.ReadLine();

						Console.WriteLine("Informe a nota do aluno: ");
						if (decimal.TryParse(Console.ReadLine(), out decimal nota)) {
							aluno.Nota = nota;
						}
						else {
							throw new ArgumentException("Valor da nota inválido");
						}

						alunos[indiceAluno] = aluno;
						indiceAluno++;

            break;
          
					case 2:
						foreach(Aluno a in alunos) {
							if (a != null) {
							Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota} ");
							}
							else break;
						}
            break;

          case 3:
						decimal notaTotal = 0;
						foreach (Aluno al in alunos) {
							if (al != null) {
								notaTotal += al.Nota;
								nAluno++;
							}
							else {
								var media = notaTotal / nAluno;
								Console.WriteLine($"Média geral: {media}");
								Enum conceitoGeral;
								if (0 < media && media < 2) {
									conceitoGeral = Enum.E;
								}
								else if (media < 4) {
									conceitoGeral = Enum.D;
								}
								else if (media < 6) {
									conceitoGeral = Enum.C;
								}
								else if (media < 8) {
									conceitoGeral = Enum.B;
								}
								else conceitoGeral = Enum.A;
								Console.WriteLine($"Conceito da turma: {conceitoGeral}");

								break;
							}
						}
            break;

          default:
            // Joga um erro mostrando que a escolha não está dentro do escopo.
            throw new ArgumentOutOfRangeException();
        }
				opcaoEscolhida = MenuOps();
      }
    }

    private static int MenuOps()
    {
      // Menu de opções
			Console.WriteLine();
      Console.WriteLine("CALCULADOR DE MÉDIA");
      Console.WriteLine();
      Console.WriteLine("1 - Inserir novo aluno.");
      Console.WriteLine("2 - Listar alunos.");
      Console.WriteLine("3 - Calcular média geral.");
      Console.WriteLine("4 - Sair");
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada: ");
      
			// Lendo a opção do usuário
      int opcaoEscolhida = int.Parse(Console.ReadLine());
			return opcaoEscolhida;
    }
  }
}
