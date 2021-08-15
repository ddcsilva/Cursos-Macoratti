using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.API.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        // Definir a inicialização da Collection
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string ImagemUrl { get; set; }

        // Propriedade de Navegação

        // Uma Categoria possui Muitos Produtos
        public ICollection<Produto> Produtos { get; set; }
    }
}
