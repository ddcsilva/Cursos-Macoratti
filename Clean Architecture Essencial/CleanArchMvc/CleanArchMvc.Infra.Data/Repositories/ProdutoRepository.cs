using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    internal class ProdutoRepository : IProdutoRepository
    {
        private ApplicationDbContext _contexto;
        public ProdutoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Produto> Criar(Produto produto)
        {
            _contexto.Add(produto);
            await _contexto.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Atualizar(Produto produto)
        {
            _contexto.Update(produto);
            await _contexto.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Excluir(Produto produto)
        {
            _contexto.Remove(produto);
            await _contexto.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> GetProdutoPorIdAsync(int? id)
        {
            return await _contexto.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _contexto.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoPorCategoriaAsync(int? id)
        {
            // Eager Loading
            return await _contexto.Produtos.Include(c => c.Categoria).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
