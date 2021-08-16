using CatalogoProdutos.API.Data;
using CatalogoProdutos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoProdutos.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    // ControllerBase inclui recursos somente para API
    public class ProdutosController : ControllerBase
    {
        private readonly DataContext context;

        public ProdutosController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                return this.context.Produtos.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os produtos do banco de dados");
            }
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = this.context.Produtos.AsNoTracking().FirstOrDefault(p => p.Id == id);

                if (produto == null)
                    return NotFound();

                return produto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os produtos do banco de dados");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            try
            {
                this.context.Produtos.Add(produto);
                this.context.SaveChanges();

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar um produto");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            try
            {
                if (id != produto.Id)
                    return BadRequest();

                this.context.Entry(produto).State = EntityState.Modified;
                this.context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar o produto com id = {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            try
            {
                var produto = this.context.Produtos.Find(id);

                if (produto == null)
                    return NotFound();

                this.context.Produtos.Remove(produto);
                this.context.SaveChanges();

                return produto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o produto com id = {id}");
            }
        }
    }
}
