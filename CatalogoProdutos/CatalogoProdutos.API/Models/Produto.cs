using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.API.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Required]
        [MaxLength(300)]
        public string ImagemUrl { get; set; }

        public float Estoque { get; set; }

        public DateTime DataCadastro { get; set; }

        // Propriedade de Navegação

        // Uma Produto está relacionado com uma Categoria
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
