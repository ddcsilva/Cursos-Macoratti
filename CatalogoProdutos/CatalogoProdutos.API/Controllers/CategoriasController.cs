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
            try
            {
                return this.context.Categorias.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as categorias do banco de dados");
            }
        }

        // É necessário definir outro endpoint para não ter conflito
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            try
            {
                // Com o método Include, eu decido o que incluir na minha lista
                return this.context.Categorias.AsNoTracking().Include(p => p.Produtos).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as categorias do banco de dados");
            }
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                var categoria = this.context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);

                if (categoria == null)
                    return NotFound($"A categoria com id = {id} não foi encontrada");

                return categoria;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as categorias do banco de dados");
            }
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody]Categoria categoria)
        {
            try
            {
                this.context.Add(categoria);
                this.context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar uma nova categoria");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (id != categoria.Id)
                    return BadRequest($"Não foi possível atualizar a categoria com id = {id}");

                this.context.Entry(categoria).State = EntityState.Modified;
                this.context.SaveChanges();

                return Ok($"A categoria com id = {id} foi atualizada com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar a categoria com id = {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            try
            {
                var categoria = this.context.Categorias.Find(id);

                if (categoria == null)
                    return NotFound($"A categoria com id = {id} não foi encontrada");

                this.context.Categorias.Remove(categoria);
                this.context.SaveChanges();

                return categoria;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir a categoria com id = {id}");
            }
        }
    }
}
