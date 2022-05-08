using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Categoria
    {
        public Categoria(string nome)
        {
            ValidarDominio(nome);
        }

        public Categoria(int id, string nome)
        {
            DomainExceptionValidation.VerificaErro(id < 0, "Id inválido!");
            Id = id;
            ValidarDominio(nome);
        }

        public void Atualizar(string nome)
        {
            ValidarDominio(nome);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        private void ValidarDominio(string nome)
        {
            DomainExceptionValidation.VerificaErro(string.IsNullOrEmpty(nome), "Nome inválido!");

            DomainExceptionValidation.VerificaErro(nome.Length < 3, "Nome inválido! Deve possuir no mínimo 3 caracteres.");

            Nome = nome;
        }
    }
}
