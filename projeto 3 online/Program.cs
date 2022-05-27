using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace projeto_3_online
{
    class Program

    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }



        static void Main(string[] args)
        {
            Carregar();
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Entrada\n5-Saida\n6-sair");
                string opstr = Console.ReadLine();
                int opInt = int.Parse(opstr);
                Menu escolha = (Menu)opInt;
                switch (escolha)
                {
                    case Menu.Listar:
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Cadastro();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Entrada:
                        Entrada();
                        break;
                    case Menu.Saida:
                        saida();
                        break;
                    case Menu.Sair:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("digite de 1 a 7");
                        break;
                }
                Console.Clear();
            }
        }
        static void Listagem()
        {
            Console.WriteLine("lista de produtos");
            int i = 0;
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("digite o ID do elemento que você quer remover");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
          
        }
        enum Escolher { produto = 1, Ebook, Curso }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1-Produto\n2-Ebook\n3-Curso");
            string opStr = Console.ReadLine();
            int EscolhaInt = int.Parse(opStr);
            Escolher pronto = (Escolher)EscolhaInt;
            switch (pronto)
            {
                case Escolher.produto:
                    CadastrarPF();
                    break;
                case Escolher.Ebook:
                    CadastrarEbook();
                    break;
                case Escolher.Curso:
                    CadastrarCurso();
                    break;
                default:
                    break;
            }
        }
        static void CadastrarPF()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso Cur = new Curso(nome, preco, autor);
            produtos.Add(Cur);
            Salvar();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter esconder = new BinaryFormatter();
            esconder.Serialize(stream, produtos);
            stream.Close();


        }
        public static void Entrada()
        {
            Listagem();
            Console.WriteLine("digite o ID do elemento que você quer dar entrada");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }
        public static void saida()
        {
            Listagem();
            Console.WriteLine("digite o ID do elemento que você quer remover");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter esconder = new BinaryFormatter();


            try
            {
                produtos = (List<IEstoque>)esconder.Deserialize(stream);
                if (produtos == null)
                {
                    produtos = new List<IEstoque>();


                }
            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
        }

    }
}
