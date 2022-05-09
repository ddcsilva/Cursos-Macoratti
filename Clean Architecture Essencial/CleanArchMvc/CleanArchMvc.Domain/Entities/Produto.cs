using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Produto : EntityBase
    {
        public Produto(string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem)
        {
            ValidarDominio(nome, descricao, preco, quantidadeEstoque, imagem);
        }

        public Produto(int id, string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem)
        {
            DomainExceptionValidation.VerificaErro(id < 0, "Id inválido!");
            Id = id;
            ValidarDominio(nome, descricao, preco, quantidadeEstoque, imagem);
        }

        public void Atualizar(string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem, int categoriaId)
        {
            ValidarDominio(nome, descricao, preco, quantidadeEstoque, imagem);
            CategoriaId = categoriaId;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public string Imagem { get; private set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        private void ValidarDominio(string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem)
        {
            DomainExceptionValidation.VerificaErro(string.IsNullOrEmpty(nome), "Nome inválido!");

            DomainExceptionValidation.VerificaErro(nome.Length < 3, "Nome inválido! Deve possuir no mínimo 3 caracteres.");

            DomainExceptionValidation.VerificaErro(string.IsNullOrEmpty(descricao), "Descrição inválida!");

            DomainExceptionValidation.VerificaErro(descricao.Length < 3, "Descrição inválida! Deve possuir no mínimo 3 caracteres.");

            DomainExceptionValidation.VerificaErro(preco < 0, "Preço inválido!");

            DomainExceptionValidation.VerificaErro(quantidadeEstoque < 0, "Quantidade em Estoque inválida!");

            DomainExceptionValidation.VerificaErro(imagem?.Length > 250, "Imagem inválida! O caminho da imagem deve possuir no máximo 250 caracteres.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Imagem = imagem;
        }
    }
}
