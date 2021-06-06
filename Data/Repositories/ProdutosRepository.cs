using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Repositories
{
    public class ProdutoRepository
    {
        private static List<ProdutoModel> _produtos = new()
        {
            new ProdutoModel
            {
                IdProduto = 1,
                NomeProduto = "iPod Classic",
                CaracteristicasProduto = "Silver - 160gb",
                QuantidadeProduto = 2,
                DataFabricacao = new DateTime(2009, 10, 01)

            }


        };
        public IEnumerable<ProdutoModel> GetAll(string busca = null)
        {
            if (string.IsNullOrWhiteSpace(busca))
            {
                return _produtos;
            }

            return _produtos.Where(x => x.NomeProduto.Contains(busca));
        }
        public void Addition(ProdutoModel produtoModel)
        {
            if (_produtos.Count() == 0)
            {
                produtoModel.IdProduto = 0;
            }
            else
            {
                produtoModel.IdProduto = _produtos.LastOrDefault().IdProduto + 1;
            }

            _produtos.Add(produtoModel);
        }
        public ProdutoModel GetById(int id)
        {
            return _produtos.FirstOrDefault(x => x.IdProduto == id);
        }

        public void Update(ProdutoModel produtoModel)
        {
            var produto = GetById(produtoModel.IdProduto);

            if (produto == null)
            {
                return;
            }

            produto.IdProduto = produtoModel.IdProduto;
            produto.NomeProduto = produtoModel.NomeProduto;
            produto.CaracteristicasProduto = produtoModel.CaracteristicasProduto;
            produto.QuantidadeProduto = produtoModel.QuantidadeProduto;
            produto.DataFabricacao = produtoModel.DataFabricacao;
        }
        public void Erase(int id)
        {
            var produto = GetById(id);

            _produtos.Remove(produto);
        }
    }
}
