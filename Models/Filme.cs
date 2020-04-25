using System.Collections.Generic;
using Respositories;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models{
    public class FilmeModels{
        [Key]
        public int IdFilme {get; set;}
        [Required]  
        public string Titulo {get; set;}
        [Required]  
        public string DataLancamento {get; set;}
        [Required]  
        public string Sinopse {get; set;}
        [Required]  
        public double ValorLocacaoFilme {get; set;}
        [Required]  
        public int EstoqueFilme {get; set;}
        public int FilmeLocado {get; set;}
        public List<LocacaoModels> locacoes = new List<LocacaoModels>();
        public FilmeModels(){ 

        }
        public FilmeModels(string titulo, string dataLancamento, string sinopse, double valorLocacaoFilme, int estoqueFilme){
            Titulo = titulo;
            DataLancamento = dataLancamento;
            Sinopse = sinopse;
            ValorLocacaoFilme = valorLocacaoFilme;
            EstoqueFilme = estoqueFilme;
            FilmeLocado = 0;

            var db = new Context();
            db.Filmes.Add(this);
            db.SaveChanges();
        }
        public static List<FilmeModels> GetFilmes(){
            var db = new Context();
            return db.Filmes.ToList();
        }
        public static FilmeModels GetFilme(int idFilme){
            var db = new Context();
            return (from filme in db.Filmes
                    where filme.IdFilme == idFilme
                    select filme).First();
        }
        public override string ToString(){
            var db = new Context();

        int qtdFilme=(from filme in db.LocacaoFilme where filme.IdFilme == IdFilme select filme).Count();

            return $"Filme: \n" +
                    $"Numero do ID do filme: {IdFilme}\n" +
                    $"Titulo do filme: {Titulo}\n" +
                    $"Data de lançamento do filme: {DataLancamento}\n" +
                    $"Sinopse do Filme: {Sinopse}\n" +
                    $"Valor da locação do filme: {ValorLocacaoFilme.ToString("C")}\n" +
                    $"Quantidade em estoque disponivel: {EstoqueFilme}\n" +
                    $"Quantidade de locações realizadas: {qtdFilme}\n" +
                    $"---------------------------------------------------------------\n";
        }
        public void AtribuirLocacao(LocacaoModels locacao){
            locacoes.Add(locacao);
        }
    }
}