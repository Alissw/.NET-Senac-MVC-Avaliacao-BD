using System;
using System.Collections.Generic;
using Models;

namespace Controllers {
    public class FilmeController{
        public static void CadastrarFilme(string titulo,string dataLancamento, string sinopse, double valorLocacaoFilme, int estoqueFilme){
            DateTime dtLancamento;
            try{
                dtLancamento = Convert.ToDateTime(dataLancamento);
            }
            catch
            {
                Console.WriteLine("Data informada esta invalida favor preencher corretamente: !");
                Console.WriteLine("Ex: (dd,mm,aaaa)");
                dtLancamento = DateTime.Now;
            }
            new FilmeModels(
                titulo,
                dataLancamento,
                sinopse,
                valorLocacaoFilme,
                estoqueFilme
            );
        }
        public static List<FilmeModels> GetFilmes()
        {
            return FilmeModels.GetFilmes();
        }
    }
}