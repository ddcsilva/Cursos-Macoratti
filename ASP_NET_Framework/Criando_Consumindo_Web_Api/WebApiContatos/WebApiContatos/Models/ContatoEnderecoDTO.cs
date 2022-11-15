namespace WebApiContatos.Models
{
    public class ContatoEnderecoDTO
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Local { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}