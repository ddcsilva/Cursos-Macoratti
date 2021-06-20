using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMvcEntity.Models
{
    [Table("Tipos")]
    public class Tipo
    {
        public int TipoId { get; set; }
        public string Nome { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}