using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        Task<Categoria> GetCategoriaPorIdAsync(int? id);
        Task<Categoria> Criar(Categoria categoria);
        Task<Categoria> Atualizar(Categoria categoria);
        Task<Categoria> Excluir(Categoria categoria);
    }
}
