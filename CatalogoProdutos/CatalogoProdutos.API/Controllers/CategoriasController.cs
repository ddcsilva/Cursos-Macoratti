using CatalogoProdutos.API.Data;
using CatalogoProdutos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoProdutos.API.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    // ControllerBase inclui recursos somente para API
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext context;

        public CategoriasController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return this.context.Categorias.ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = this.context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (categoria == null)
                return NotFound();

            return categoria;
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody]Categoria categoria)
        {
            this.context.Add(categoria);
            this.context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
                return BadRequest();

            this.context.Entry(categoria).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = this.context.Categorias.Find(id);

            if (categoria == null)
                return NotFound();

            this.context.Categorias.Remove(categoria);
            this.context.SaveChanges();

            return categoria;
        }
    }
}
