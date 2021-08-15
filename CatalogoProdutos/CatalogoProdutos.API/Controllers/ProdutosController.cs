using CatalogoProdutos.API.Data;
using CatalogoProdutos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return this.context.Produtos.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = this.context.Produtos.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return produto;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            this.context.Produtos.Add(produto);
            this.context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            this.context.Entry(produto).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = this.context.Produtos.Find(id);

            if (produto == null)
                return NotFound();

            this.context.Produtos.Remove(produto);
            this.context.SaveChanges();

            return produto;
        }
    }
}
