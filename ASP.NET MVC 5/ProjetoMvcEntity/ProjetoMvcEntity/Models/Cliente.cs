using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMvcEntity.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int TipoId { get; set; }
    }
}