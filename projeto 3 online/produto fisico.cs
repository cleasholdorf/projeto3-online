using System;
using System.Collections.Generic;
using System.Text;

namespace projeto_3_online
{
    [System.Serializable]
    class ProdutoFisico : Produto ,IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico()
        {
        }

        public ProdutoFisico(string nome, float preco,float frete)
        {
            this.frete = frete;
            
            this.nome = nome;
            this.preco = preco;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Adicionar entrada no estoque do produto: "+ nome);
            Console.WriteLine("digite a quantidade");
            int entrada = int.Parse(Console.ReadLine());
            //estoque =estoque +entrada;
            estoque += entrada;
            Console.WriteLine("entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Adicionar saida no estoque do produto: " + nome);
            Console.WriteLine("digite a quantidade");
            int entrada = int.Parse(Console.ReadLine());
            //estoque =estoque - entrada;
            estoque -= entrada;
            Console.WriteLine("entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome :{nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("==============================");
        }
    }
}
