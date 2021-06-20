using System.ComponentModel.DataAnnotations;

namespace AtividadeValidacaoDataAnnotations.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O Nome deve conter entre 5 e 50 caracteres!")]
        [Display(Name = "Informe o nome do Produto")]
        public string Nome { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A Descrição deve conter entre 5 e 50 caracteres!")]
        [Display(Name = "Informe a descrição do Produto")]
        public string Descricao { get; set; }
        [Range(2, 10, ErrorMessage = "O valor deve estar entre 2 e 10!")]
        public int Estoque { get; set; }
    }
}