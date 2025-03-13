using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lanchonete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produto> cardapios = new List<Produto>();
            List <Pedido> pedidos = new List<Pedido>();
            var pedido = new Pedido();

            Produto produtos = new Produto();
            produtos.ID = 1;
            produtos.Nome = "X-Burger";
            produtos.Valor = 24.90M;
            cardapios.Add(produtos);
            Produto produtos2 = new Produto();
            produtos2.ID = 2;
           produtos2.Nome = "X- Salada";
            produtos2.Valor = 20.90M;
            cardapios.Add(produtos2);
            Produto produtos3 = new Produto();
            produtos3.ID = 3;
            produtos3.Nome = "X- Bacon";
            produtos3.Valor = 24.90M;
            cardapios.Add(produtos3);
            Produto produtos4 = new Produto();
            produtos4.ID = 4;
            produtos4.Nome = "Refrigerante";
            produtos4.Valor = 8.00M;
            cardapios.Add(produtos4);
            int op;
            do
            {
                Console.WriteLine("""
                    1 - Opção: Criar um pedido
                    2 - Visualizar pedidos já cadastrados.
                    0 - Sair
                    """);
                

                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:

                        foreach (var produto in cardapios)
                        {
                            produto.Cardapio();
                        }
                        pedido = new Pedido
                        {
                            NumComanda = pedidos.Count() + 1,
                            ListaDeCompra = new List<Produto>(),
                            TotalValor = 0
                        };
                        pedidos.Add(pedido);
                        Console.WriteLine("Faça seu pedido: ");
                        CriarPedido(cardapios, pedido);
                        break;
                    case 2:
                        Console.WriteLine("Escolha um pedido: ");
                        foreach (var numero in pedidos)
                        {
                            Console.WriteLine($"{numero.NumComanda}");
                        }
                        int nome = int.Parse(Console.ReadLine());
                        pedido = pedidos.FirstOrDefault(x => x.NumComanda == nome);
                        if (pedido == null)
                        {
                            Console.WriteLine("Pedido inválido.");
                            return;
                        }
                        Console.WriteLine($"Pedido númeroª{pedido.NumComanda}");
                        Console.WriteLine("Produtos: ");
                        foreach (var contagem in pedido.ListaDeCompra)
                        {
                            Console.WriteLine($"{contagem.Nome} preço: {contagem.Valor}");
                        }
                        Console.WriteLine($"O  total dos produtos deu: {pedido.TotalValor}\n");
                        break;
                    case 0:
                        Console.WriteLine("Finalizando.");
                        break;
                    default:
                        Console.WriteLine("Inválido");
                        break;
                }
                
                Console.WriteLine("Digite 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != 0); 
        }
        private static void CriarPedido(List<Produto> cardapios, Pedido pedidos)
        {
            int espera = 0;
            while (espera == 0)
            {
                foreach (var item in cardapios)
                {
                    Console.WriteLine($"Digite: {item.ID} para {item.Nome} com preço  de: {item.Valor}.");
                }
                espera = int.Parse(Console.ReadLine());
                var item3 = cardapios.FirstOrDefault(x => x.ID == espera);
                if (item3 != null)
                {
                    pedidos.ListaDeCompra.Add(item3);
                    pedidos.TotalValor = pedidos.ListaDeCompra.Sum(x => x.Valor);
                    espera = 0;
                    Console.Clear ();
                    Console.WriteLine("Escolha o próiximo produto ou digite 0 para sair.");
                }
                else
                {
                    Console.WriteLine("Produto inválido. Digite 0 para sair ou qualquer outra tecla para continuar.");
                    var nome  = Console.ReadLine();
                    if(nome != "0")
                    {
                        espera = 0;
                    }
                    else
                    {
                        espera = 1;
                    }
                }
            }
        }
    }
}