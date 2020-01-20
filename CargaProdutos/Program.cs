using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CargaProdutos.Clients;
using CargaProdutos.Models;

namespace CargaProdutos
{
    class Program
    {
        private static async Task Interromper()
        {
            await Console.Out.WriteLineAsync(
                "Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static async Task Main()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            var apiProdutosClient =
                    new APIProdutosClient(config);
            await apiProdutosClient.AutenticarComSenha();
            if (apiProdutosClient.IsAuthenticatedUsingToken)
            {
                await apiProdutosClient.IncluirProduto(
                    new Produto()
                    {
                        CodigoBarras = "00005",
                        Nome = "Teste Produto 05",
                        Preco = 5.05
                    });
                await Interromper();

                await apiProdutosClient.IncluirProduto(
                    new Produto()
                    {
                        CodigoBarras = "00006",
                        Nome = "Teste Produto 06",
                        Preco = 6.78
                    });
                await Interromper();

                await apiProdutosClient.ListarProdutos();
            }

            await Console.Out.WriteLineAsync("\nFinalizado!");
        }
    }
}