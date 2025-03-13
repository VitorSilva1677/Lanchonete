using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete
{
    public class Pedido
    {
        public decimal TotalValor { get; set; }
        public int NumComanda { get; set; }
        public string Itens { get; set; }
        public List<Produto> ListaDeCompra { get; set; } = new List<Produto>();
    }
}
