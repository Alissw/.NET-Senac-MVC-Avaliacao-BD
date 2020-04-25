using System;
using Models;
using System.Collections.Generic;


namespace Controllers{
    public class ClienteController{
        public static void CadastrarCliente(string nomeCliente,string dataNascimento,string cpfCliente,int diasDevolucao){
        DateTime dtNasc;
        try{
            dtNasc = Convert.ToDateTime(dataNascimento);
        }
        catch{
            Console.WriteLine("Data informada esta invalida favor preencher corretamente: !");
            Console.WriteLine("Ex: (dd,mm,aaaa)");
            dtNasc = DateTime.Now;
        }
        new ClienteModels(nomeCliente,
        dataNascimento,
        cpfCliente,
        diasDevolucao);

        }
        public static List<ClienteModels> GetClientes()
        {
            return ClienteModels.GetClientes();
        }
    }
}