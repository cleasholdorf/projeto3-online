using System;
using System.Collections.Generic;
using System.Text;

namespace projeto_3_online
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome,float preco,string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Adicionar vagas: " + nome);
            Console.WriteLine("digite a quantidade");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("RETIRARS1 vagas: " + nome);
            Console.WriteLine("digite a quantidade");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome :{nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("==============================");
            
        }
    }
}
