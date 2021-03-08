using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;
using CursoMVC.Models;

namespace CursoTeste
{
    class CategoriasControllerTest
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;
        public CategoriasControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste Categoria" };
            _mockContext.Setup(m => m.Categorias).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Categorias.FindAsync(1)).ReturnsAsync(_categoria);
            _mockContext.Setup(m => m.SetModified(_categoria));

        }
    }
}
