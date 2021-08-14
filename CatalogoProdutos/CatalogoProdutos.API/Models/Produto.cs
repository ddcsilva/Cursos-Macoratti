using System;

namespace CatalogoProdutos.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        // Propriedade de Navegação

        // Uma Produto está relacionado com uma Categoria
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
