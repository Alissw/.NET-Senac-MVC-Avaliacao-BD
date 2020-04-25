using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using Respositories;

namespace Models{
    public class ClienteModels{
        [Key]
        public int IdCliente {get; set;}
        [Required]
        public string NomeCliente {get; set;}
        [Required] 
        public string DataNascimento {get; set;}
        [Required] 
        public string CpfCliente {get; set;}
        [Required] 
        public int DiasDevolucao {get; set;}
        public List<LocacaoModels> locacoes = new List<LocacaoModels>();
        public ClienteModels(){

        }
        public ClienteModels(string nomeCliente, string dataNascimento, string cpfCliente, int diasDevolucao){
            NomeCliente = nomeCliente;
            DataNascimento = dataNascimento;
            CpfCliente = cpfCliente;
            DiasDevolucao = diasDevolucao; 
            locacoes = new List<LocacaoModels>();           

            var db = new Context();
            db.Clientes.Add(this);
            db.SaveChanges();
        } 
        public static ClienteModels GetCliente(int idCliente){
            var db = new Context();
            return (from cliente in db.Clientes
                    where cliente.IdCliente == idCliente
                    select cliente).First();
        }
        public void AdicionarLocacao(LocacaoModels locacao){
            locacoes.Add(locacao);
        }     
        public static List<ClienteModels> GetClientes(){
            var db = new Context();
            return db.Clientes.ToList();
        }
        public override string ToString()
        {            
            return $" Cliente: \n" +
                    $"Numero do ID do cliente: {IdCliente}\n" +
                    $"Nome completo do cliente: {NomeCliente}\n" +
                    $"Data de nascimento do cliente: {DataNascimento}\n" +
                    $"CPF: {CpfCliente}\n" +
                    $"Dias para devolver o filme: {DiasDevolucao}\n" +
                    $"--------------------------------------------------------------";
        }  
    }
}