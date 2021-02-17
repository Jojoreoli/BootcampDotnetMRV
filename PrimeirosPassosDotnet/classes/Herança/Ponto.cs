namespace classes.Herança
{
  public class Ponto
  {
    public int x, y;
    private int distancia;

    public Ponto(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    protected void CalcularDistancia()
    {

    }

    private void CalcularDistancia2()
    {

    }

    // virtual permite override pela classe filha
    public virtual void CalcularDistancia3()
    {
      
    }
  }
}