using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete
{
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int ID { get; set; }
        public void Cardapio()
        {
            Console.WriteLine($"{Nome} : {Valor}");
        }
    }
}
