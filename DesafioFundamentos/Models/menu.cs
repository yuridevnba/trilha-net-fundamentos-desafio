
using System.Security.Cryptography.X509Certificates;
using Services;

namespace DesafioFundamentos.Models
{
    public class Menu 
    {
        bool PainelMenu = true;
        static bool PInicial = true;
        public void ApresentarMenu()
        {
            if (PInicial)
            {
                System.Console.WriteLine("Seja Bem Vindo ao sistema de Estacionamento!");
                System.Console.WriteLine("digite a preço Inicial:");
                int horasInicial = int.Parse(Console.ReadLine());

                 System.Console.WriteLine("digite o preço hora:");
                int precoHora = int.Parse(Console.ReadLine());
                PInicial = false;
                EstacionamentoService.PInicial(horasInicial,precoHora);
                
                
            }

            

            while (PainelMenu)
            {
                System.Console.WriteLine("\n");
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                switch (Console.ReadLine())
                {
                    case "1":
                        EstacionamentoService.Adicionar();
                        break;

                    case "2":
                        EstacionamentoService.RemoverVeiculo();
                        break;

                    case "3":
                        EstacionamentoService.ListarVeiculos();
                        break;

                    case "4":
                        PainelMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

            }
             
            Console.WriteLine("O programa se encerrou");
           throw new Exception("Fimmm!");
        }
    }
}
