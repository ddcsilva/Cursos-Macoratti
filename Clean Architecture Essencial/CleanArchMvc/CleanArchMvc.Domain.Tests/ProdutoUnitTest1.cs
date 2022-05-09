using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CriarProduto_ParametrosValidos_ObjetoValido()
        {
            Action action = () => new Produto(1, "Produto", "Descrição", 9.99m, 99, "Imagem");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CriarProduto_IdInvalido_LancarExcecao()
        {
            Action action = () => new Produto(-1, "Produto", "Descrição", 9.99m, 99, "Imagem");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Id inválido!");
        }

        [Fact]
        public void CriarProduto_NomeCurto_LancarExcecao()
        {
            Action action = () => new Produto(1, "Pr", "Descrição", 9.99m, 99, "Imagem");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Nome inválido! Deve possuir no mínimo 3 caracteres.");
        }

        [Fact]
        public void CriarProduto_NomeImagemGrande_LancarExcecao()
        {
            Action action = () => new Produto(1, "Produto", "Descrição", 9.99m, 99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should()
                .Throw<DomainExceptionValidation>()
                 .WithMessage("Imagem inválida! O caminho da imagem deve possuir no máximo 250 caracteres.");
        }

        [Fact]
        public void CriarProduto_ImagemNula_SemExcecao()
        {
            Action action = () => new Produto(1, "Produto", "Descrição", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CriarProduto_ImagemNula_SemNullReferenceException()
        {
            Action action = () => new Produto(1, "Produto", "Descrição", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CriarProduto_ImagemVazia_SemExcecao()
        {
            Action action = () => new Produto(1, "Produto", "Descrição", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CriarProduto_PrecoInvalido_LancarExcecao()
        {
            Action action = () => new Produto(1, "Produto", "Descrição", -9.99m, 99, "");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Preço inválido!");
        }

        [Theory]
        [InlineData(-5)]
        public void CriarProduto_EstoqueInvalido_LancarExcecao(int valor)
        {
            Action action = () => new Produto(1, "Produto", "Descrição", 9.99m, valor, "Imagem");
            action.Should().Throw<DomainExceptionValidation>()
                   .WithMessage("Quantidade em Estoque inválida!");
        }
    }
}
