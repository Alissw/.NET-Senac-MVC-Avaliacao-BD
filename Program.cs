using System;
using View;

namespace Aplicativo
{
    public class Principal
    {
        public static void Main(String[] args)
        {
            int opcao = 0;
            do{
                Console.WriteLine("+-------------------------+");
                Console.WriteLine("| Digite a opção desejada |");
                Console.WriteLine("| 1 - Cadastrar Cliente   |");
                Console.WriteLine("| 2 - Cadastrar Filme     |");
                Console.WriteLine("| 3 - Cadastrar Locação   |");
                Console.WriteLine("| 4 - Listar Clientes     |");
                Console.WriteLine("| 5 - Consultar Cliente   |");
                Console.WriteLine("| 6 - Listar Filmes       |");
                Console.WriteLine("| 7 - Consultar Filme     |");
                Console.WriteLine("| 8 - Consultar Locação   |");
                Console.WriteLine("| 0 - Sair                |");
                Console.WriteLine("+-------------------------+");
                try{
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch{
                    Console.WriteLine("Opção inválida");
                    opcao = 99;
                }
                switch (opcao)
                {
                    case 1:
                        ClienteView.CadastrarCliente();
                        break;
                    case 2:
                        FilmeView.CadastrarFilme();
                        break;
                    case 3:
                        LocacaoView.CadastrarLocacao();
                        break;
                    case 4:
                        ClienteView.ListarClientes();
                        break;
                    case 5:
                        ClienteView.ConsultarCliente();
                        break;
                    case 6:
                        FilmeView.ListarFilmes();
                        break;
                    case 7: 
                        FilmeView.ConsultarFilme();
                        break;
                    case 8:
                        LocacaoView.ConsultarLocacao();
                        break;
                }
            } while (opcao != 10);

        }
    }
}