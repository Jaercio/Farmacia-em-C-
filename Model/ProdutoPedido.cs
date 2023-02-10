using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProdutoPedido
    {
        public ProdutoPedido(int p1, string p2, decimal p3, int p4)
        {
            ProdutoId = p1;
            Nome = p2;
            PrecoVenda = p3;
            Quantidade = p4;
        }

        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }

    }
}
