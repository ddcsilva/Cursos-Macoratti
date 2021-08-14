using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatalogoProdutos.API.Models
{
    public class Categoria
    {
        // Definir a inicialização da Collection
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }

        // Propriedade de Navegação

        // Uma Categoria possui Muitos Produtos
        public ICollection<Produto> Produtos { get; set; }
    }
}
