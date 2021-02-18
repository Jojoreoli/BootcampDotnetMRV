using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
  public class RepositorioDeSeries : IRepositorio<Serie>
  {
    // Criando a lista de series
    private List<Serie> listaSerie = new List<Serie>();

    public void Atualiza(int id, Serie entidade)
    {
      // Insere a entidade passada na posição passada
      listaSerie[id] = entidade;
    }

    public void Exclui(int id)
    {
      // Chama o método excluir na posição passada. Excluir está na classe Serie.
      listaSerie[id].Excluir();
    }

    public void Insere(Serie entidade)
    {
      // Adiciona a entidade na lista
      listaSerie.Add(entidade);
    }

    public List<Serie> Lista()
    {
      // Retorna a lista de series
      return listaSerie;
    }

    public int ProximoId()
    {
      // Por comecar do zero, o count sempre vai ser um a mais do que o index do ultimo id.
      return listaSerie.Count;
    }

    public Serie RetornaPorId(int id)
    {
      // Retorna o item da lista na posição do ID passado
      return listaSerie[id];
    }
  }
}