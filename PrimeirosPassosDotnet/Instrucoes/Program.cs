using System;

namespace Instrucoes {
	class Program {
		static void Declaracoes() {
			// Declarando uma var sem atribuir valor
			int a;
			// Declarando mais de uma var e atribuindo valor na declaração
			int b = 2, c = 3;
			// Declarando uma constante e atribuindo o valor (deve ser atribuido na declaração)
			const int d = 4;
			// Atribuindo valor a var
			a = 1;
			// Imprimindo e realizando operações
			Console.WriteLine("Resultado: " + (a + b + c + d));
		}

		static void If(string[] args) {
			if (args.Length == 0) {
				Console.WriteLine("Sem argumento");
			}

			else if (args.Length == 1) {
				Console.WriteLine("Um argumento");
			}

			else {
				// Interpolação na hora de imprimir. Ostentação bigodinhos $"{}".
				Console.WriteLine($"{args.Length} argumentos");
			}
		}

		static void Switch(string[] args) {
			int numeroDeArgumentos = args.Length;
			switch (numeroDeArgumentos) {
				case 0:
					Console.WriteLine("Sem argumento");
					break;
				case 1:
					Console.WriteLine("Um argumento");
					break;
				default:
					Console.WriteLine($"{numeroDeArgumentos} argumentos");
					break;
			}
		}

		static void While(string[] args) {
			int i = 0;
			while (i < args.Length) {
				Console.WriteLine(args[i]);
				i++;
			}
		}

		static void Do() {
			string texto;
			do {
				Console.WriteLine("Fala algo");
				texto = Console.ReadLine();
				Console.WriteLine("Vou te repetir");
				Console.WriteLine(texto);
				Console.WriteLine("Haha");
			} while (!string.IsNullOrEmpty(texto));
		}

		static void For(string[] args) {
			for (int i = 0; i < args.Length; i++) {
				Console.WriteLine(args[i]);
			}
		}

		static void ForEach (string[] args) {
			foreach (string s in args) {
				Console.WriteLine(s);
			}
		}

		static void Break() {
			while (true) {
				Console.WriteLine("Para parar aperte enter");
				string s = Console.ReadLine();
				if (string.IsNullOrEmpty(s)) break;
				Console.WriteLine(s);
			}
		}

		static void Continue(string[] args) {
			for (int i = 0; i < args.Length; i++) {
				if (args[i].StartsWith("/")) continue;
				Console.WriteLine(args[i]);
			}
		}

		static void Return() {
      static int Somar(int a, int b) {
				return a + b;
			}

			Console.WriteLine(Somar(10,20));
			Console.WriteLine(Somar(47,34));
			return;
		}

		static void TryCatchFinallyThrow(string[] args) {
			double Dividir (double x, double y) {
				// Impossivel dividir por 0
				if(y == 0) throw new DivideByZeroException();
				return x / y;
			}

			// Tenta executar
			try {
				if (args.Length != 2) {
					throw new InvalidOperationException("Preciso de 2 numeros");
				}
				double x = double.Parse(args[0]);
				double y = double.Parse(args [1]);
				Console.WriteLine(Dividir(x, y));
			}
			// Catch trata as exceções
			catch (InvalidOperationException e){
				Console.WriteLine(e.Message);
			}
			catch (Exception e) {
				Console.WriteLine($"Erro generico: {e.Message}");
			}
			// Executa independente do sucesso
			finally {
				Console.WriteLine("Falous");
			}
		}

		static void Using() {
			// Ao usar o using o garbage disposal é automático.
			using (System.IO.TextWriter w = System.IO.File.CreateText("Olá.txt")) {
				w.WriteLine("Olá");
				w.WriteLine("Sou um texto novinho");
				w.WriteLine("Não me delete :c");
			}
		}

		static void Main(){
			string[] tchan = {"Jacaré", "Cumpade Washington", "Beto Jamaica", "Carla Perez", "Debora Brasil"};
			Declaracoes();
			If(tchan);
			Switch(tchan);
			While(tchan);
			Do();
			For(tchan);
			ForEach(tchan);
			Break();
			Continue(tchan);
			Return();
			TryCatchFinallyThrow(tchan);
			Using();
		}
	}
}
