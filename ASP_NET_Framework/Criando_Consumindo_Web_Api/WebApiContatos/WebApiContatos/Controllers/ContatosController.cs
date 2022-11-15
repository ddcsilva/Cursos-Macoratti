using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiContatos.Models;

namespace WebApiContatos.Controllers
{
    public class ContatosController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetTodosContatos(bool incluirEndereco = false)
        {
            IList<Contato> contatos = null;

            using (var context = new AppDbContext())
            {
                contatos = context.Contatos.Include("Endereco").ToList()
                    .Select(c => new Contato()
                    {
                        ContatoId = c.ContatoId,
                        Nome = c.Nome,
                        Email = c.Email,
                        Telefone = c.Telefone,
                        Endereco = c.Endereco == null || incluirEndereco == false ? null : new Endereco()
                        {
                            EnderecoId = c.Endereco.EnderecoId,
                            Local = c.Endereco.Local,
                            Cidade = c.Endereco.Cidade,
                            Estado = c.Endereco.Estado
                        }
                    }).ToList();
            }

            if (contatos.Count == 0)
            {
                return NotFound();
            }

            return Ok(contatos);
        }

        [HttpGet]
        public IHttpActionResult GetContatoPorId(int? id)
        {
            if (id == null)
            {
                return BadRequest("O Id do contato é inválido");
            }

            Contato contato = null;

            using (var context = new AppDbContext())
            {
                contato = context.Contatos.Include("Endereco").ToList()
                         .Where(c => c.ContatoId == id)
                         .Select(c => new Contato()
                         {
                             ContatoId = c.ContatoId,
                             Nome = c.Nome,
                             Email = c.Email,
                             Telefone = c.Telefone,
                             Endereco = c.Endereco == null ? null : new Endereco()
                             {
                                 EnderecoId = c.Endereco.EnderecoId,
                                 Local = c.Endereco.Local,
                                 Cidade = c.Endereco.Cidade,
                                 Estado = c.Endereco.Estado
                             }
                         }).FirstOrDefault<Contato>();
            }

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        [HttpGet]
        public IHttpActionResult GetContatoPorNome(string nome)
        {
            if (nome == null)
            {
                return BadRequest("Nome Inválido");
            }

            IList<Contato> contatos = null;

            using (var context = new AppDbContext())
            {
                contatos = context.Contatos.Include("Endereco").ToList()
                    .Where(x => x.Nome.ToLower() == nome.ToLower())
                    .Select(c => new Contato()
                    {
                        ContatoId = c.ContatoId,
                        Nome = c.Nome,
                        Email = c.Email,
                        Telefone = c.Telefone,
                        Endereco = c.Endereco == null ? null : new Endereco()
                        {
                            EnderecoId = c.Endereco.EnderecoId,
                            Local = c.Endereco.Local,
                            Cidade = c.Endereco.Cidade,
                            Estado = c.Endereco.Estado
                        }
                    }).ToList();
            }

            if (contatos.Count == 0)
            {
                return NotFound();
            }

            return Ok(contatos);
        }
    }
}
