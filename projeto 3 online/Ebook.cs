using System;
using System.Collections.Generic;
using System.Text;

namespace projeto_3_online
{
    [System.Serializable]
    class Ebook:Produto,IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome,float preco, string autor)
        {
            this.autor = autor;
            this.nome = nome;
            this.preco = preco;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("nao é possivel");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("digite a quantiudade de vendas: " + nome);
            Console.WriteLine("digite a quantidade");
            int entrada = int.Parse(Console.ReadLine());
            
            vendas += entrada;
            Console.WriteLine("entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome :{nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("==============================");
        }
    }
}
