using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using CargaProdutos.Models;

namespace CargaProdutos.Interfaces
{
    public interface IProdutosAPI
    {
        [Get("/Produtos")]
        Task<List<Produto>> ListarProdutos(
            [Header("Authorization")]string token);

        [Post("/Produtos")]
        Task<ResultadoAPIProdutos> IncluirProduto(
            [Header("Authorization")]string token,
            [Body]Produto produto);
    }
}