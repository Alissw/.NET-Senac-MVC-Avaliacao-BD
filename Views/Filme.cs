using System;
using Models;
using Controllers;
using System.Linq;

namespace View{
    public class FilmeView{
        public static void CadastrarFilme(){
        Console.WriteLine("Cadastrar Filme");
        Console.WriteLine("Título:");
        string titulo = Console.ReadLine();
        Console.WriteLine("\nData de Lançamento:");
        Console.WriteLine("Informe a data no formato (dd/mm/yyyy)");
        string dataLancamento = Console.ReadLine();
        Console.WriteLine("\nSinopse: ");
        string sinopse = Console.ReadLine();
        Console.WriteLine("\nValor da Locação:");
        double valorLocacaoFilme = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nDisponivel no Estoque : ");
        int estoqueFilme = Convert.ToInt32(Console.ReadLine());
        
        FilmeController.CadastrarFilme(titulo, dataLancamento, sinopse, valorLocacaoFilme, estoqueFilme);
        }
        public static void ListarFilmes(){
            Console.WriteLine("Lista de filmes");
            FilmeController.GetFilmes().ForEach(filme => Console.WriteLine(filme));
        }
        public static void ConsultarFilme(){
            Console.WriteLine("Digite o Id do filme: ");
            int idFilme = Convert.ToInt32(Console.ReadLine());
            try{
                FilmeModels filme = (from fil in FilmeController.GetFilmes() where fil.IdFilme == idFilme select fil).First();
                Console.WriteLine("Consultar Filmes");
                Console.WriteLine(filme.ToString());
            }
            catch{
                Console.WriteLine("O filme que você informou não existe ");
            }
        }
    }
}