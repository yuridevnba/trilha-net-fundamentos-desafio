
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Services;

namespace DesafioFundamentos.Models
{
    public class Menu 
    {
        // variaveis static
      static  bool PainelMenu = true;

       static bool Inicio = true;

        static decimal PH;

        static decimal PI;
        
        public void ApresentarMenu()
        {
            if (Inicio)
            {
                System.Console.WriteLine("Seja Bem Vindo ao sistema de Estacionamento!");
                
                System.Console.WriteLine("digite a preço Inicial:");
                PI = decimal.Parse(Console.ReadLine());

              System.Console.WriteLine("digite o preço hora:");
               PH = decimal.Parse(Console.ReadLine());
                Inicio = false;
           
                        Estacionamento estacionamento = new Estacionamento(PI,PH);
                        EstacionamentoService servico = new EstacionamentoService(estacionamento);
            }


               
            while (PainelMenu)
            {
                System.Console.WriteLine("\n");
                Console.WriteLine("Digite a sua opcao:");
                Console.WriteLine("1 - Cadastrar veiculo");
                Console.WriteLine("2 - Remover veiculo");
                Console.WriteLine("3 - Listar veiculos");
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
                        Console.WriteLine("Opcao invalida");
                        break;
                }

            }
             
            Console.WriteLine("O programa se encerrou");
            

        }
    }
}
