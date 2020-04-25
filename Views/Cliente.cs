using System;
using Models;
using Controllers;
using System.Linq;

namespace View{
    
    public class ClienteView {
        public static void CadastrarCliente(){
            Console.WriteLine("Cadastrar cliente:");
            Console.WriteLine("Nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            Console.WriteLine("\nData de nascimento no formato (dd/mm/yyyy): ");
            string dataNascimento = Console.ReadLine();
            Console.WriteLine("\n CPF: ");
            string cpfCLiente = Console.ReadLine();
            Console.WriteLine("\nDias para devolver filme: ");
            int diasDevolucao = Convert.ToInt32(Console.ReadLine());
            ClienteController.CadastrarCliente(nomeCliente, dataNascimento, cpfCLiente, diasDevolucao);
        }
        public static void ListarClientes(){
            Console.WriteLine("Lista de cliente");
            ClienteController.GetClientes().ForEach(cliente => Console.WriteLine(cliente));
        }
        public static void ConsultarCliente(){
            Console.WriteLine("Informe o ID do Cliente: ");
            int idCliente = Convert.ToInt32(Console.ReadLine());
            try {
                ClienteModels cliente = (from cliente1 in ClienteController.GetClientes()
                where cliente1.IdCliente == idCliente 
                select cliente1).First();
                
                Console.WriteLine("Consultar cliente");
                Console.WriteLine(cliente.ToString());
            }
            catch{
                Console.WriteLine("Cliente não existe");
            }
        }
    }
}