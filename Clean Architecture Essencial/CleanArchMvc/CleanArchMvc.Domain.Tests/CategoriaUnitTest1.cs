using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoriaUnitTest1
    {
        [Fact(DisplayName = "Criar Categoria Com Parâmetros Válidos")]
        public void CriarCategoria_ParametrosValidos_ObjetoValido()
        {
            Action action = () => new Categoria(1, "Categoria");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Categoria Com Id Inválido")]
        public void CriarCategoria_IdInvalido_LancarExcecao()
        {
            Action action = () => new Categoria(-1, "Categoria");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id inválido!");
        }

        [Fact(DisplayName = "Criar Categoria Com Nome Curto")]
        public void CriarCategoria_NomeCurto_LancarExcecao()
        {
            Action action = () => new Categoria(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido! Deve possuir no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criar Categoria Com Nome Vazio")]
        public void CriarCategoria_NomeVazio_LancarExcecao()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido!");
        }

        [Fact(DisplayName = "Criar Categoria Com Nome Nulo")]
        public void CriarCategoria_NomeNulo_LancarExcecao()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}