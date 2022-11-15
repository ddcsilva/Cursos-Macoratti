using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiContatos.Models
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        public int ContatoId { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(40)]
        public string Telefone { get; set; }

        [Required]
        public virtual Endereco Endereco { get; set; }

        public virtual int EnderecoId { get; set; }
    }
}