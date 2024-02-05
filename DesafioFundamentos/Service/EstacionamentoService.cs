using System.Text.RegularExpressions;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repository;

namespace Services
{
    public class EstacionamentoService
    {

    private static Estacionamento estacionamento;
    

     public  EstacionamentoService(Estacionamento estacionamento) {
       EstacionamentoService.estacionamento = estacionamento;

     }
        /// ADIÇÃO//////// 
        //////////////////        
        
        public static void Adicionar()
        {

            
            Console.Write("Digite a placa do veiculo para estacionar: ");
            string placa = Console.ReadLine().ToUpper();


            if (ValidarPlaca(placa))
            {

                if (EstacionamentoRepository.ProcurarUm(placa) == null)
                {
                    Veiculo vec = new Veiculo()
                    {
                        Placa = placa,
                    };

                    EstacionamentoRepository.Adicionar(vec);
                    Console.WriteLine("Placa Valida!!!");
                }

                else
                {
                    Console.WriteLine("Placa Ja Existe no Estacionamento!!!");
                }


            }
            else{
                Console.WriteLine("Erro na Placa!");
            }


            Console.ReadKey();
            Console.Clear();
            Menu menu = new Menu();
            menu.ApresentarMenu();

        }

          //// REMOÇÃO////// 
         //////////////////  
        public static void RemoverVeiculo()
        {

            Console.Clear();
            Console.Write("Digite a placa do veiculo para remover: ");
            string placa = Console.ReadLine().ToUpper();

           
            var veiculo = EstacionamentoRepository.ProcurarUm(placa);


            if (veiculo != null)
            {


                
                Console.Write("Digite a quantidade de horas que o veiculo permaneceu estacionado: ");
                int horas = int.Parse(Console.ReadLine());
              
                 
              decimal valorTotal =   estacionamento.ValorPagar(horas);
                EstacionamentoRepository.Delete(placa);

              

                  Console.WriteLine($"O veiculo  {placa}, foi removido e o preco total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Placa nao existe no estacionamento!");
            }

            Console.ReadKey();
            Console.Clear();
            Menu menu = new Menu();
            menu.ApresentarMenu();

        }

        //// LISTAR////// 
        /////////////////
        public static void ListarVeiculos()
        {

            var veiculos = EstacionamentoRepository.Listar();


            if (veiculos.Count>0)
            {
                Console.Clear();
                Console.WriteLine("Os veiculos estacionados são:");

                foreach (var CopiaVeiculo in veiculos)
                {
                    Console.WriteLine($" {CopiaVeiculo.ToString()}");

                }
            }
            else
            {
                Console.WriteLine("Nao ha veiculos estacionados.");
            }

            Console.ReadKey();
            Console.Clear();
            Menu menu = new Menu();
            menu.ApresentarMenu();
        }
        

        //// VALIDAR ////// 
        ///////////////////  
        /// PFP-1461//normal
        

        public static bool ValidarPlaca(string placaa)
        {
          
        string  placa = placaa.Trim();
            
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            
            if (placa.Length != 8) { return false; }


             ///pegar as 3 letras iniciais
              string ppp = placa.Substring(0, 3); 
              bool indicativo;

              bool saoLetras = ppp.All(char.IsLetter);
              
             // pegar os 4 números tirando o "-"
             string numero = placa.Substring(placa.IndexOf('-')+1);
             bool ehValido = numero.All(c => char.IsDigit(c));

            if ( saoLetras && ehValido)
            {
             
             return indicativo=true;
                
            }
            else
            {
                System.Console.WriteLine("Placa fora do padrao");
               return indicativo=false;
               
            }
        }
    }
}