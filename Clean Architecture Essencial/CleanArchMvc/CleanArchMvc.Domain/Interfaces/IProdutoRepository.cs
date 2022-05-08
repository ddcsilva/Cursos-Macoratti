using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoPorIdAsync(int? id);
        Task<Produto> GetProdutoPorCategoriaAsync(int? id);
        Task<Produto> Criar(Produto produto);
        Task<Produto> Atualizar(Produto produto);
        Task<Produto> Excluir(Produto produto);
    }
}
