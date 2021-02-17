namespace classes.Métodos
{
    public class Ref
    {
        static void Inverte(ref int x, ref int y) {
          int temp = x;
          x = y;
          y = temp;
        }

        public static void Inverte() {
          int i = 1, j = 2;
          Inverte(ref i, ref  j);
          System.Console.WriteLine($"{i} {j}");
        }
    }
}