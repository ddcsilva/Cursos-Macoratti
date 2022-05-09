using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext _contexto;

        public CategoriaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Categoria> Criar(Categoria categoria)
        {
            _contexto.Add(categoria);
            await _contexto.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Atualizar(Categoria categoria)
        {
            _contexto.Update(categoria);
            await _contexto.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Excluir(Categoria categoria)
        {
            _contexto.Remove(categoria);
            await _contexto.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> GetCategoriaPorIdAsync(int? id)
        {
            return await _contexto.Categorias.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await _contexto.Categorias.ToListAsync();
        }
    }
}
