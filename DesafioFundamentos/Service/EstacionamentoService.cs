using System.Text.RegularExpressions;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repository;

namespace Services
{
    public class EstacionamentoService
    {

    /// PInicial, PHora//////// 
        ////////////////// 
    
    private static string _resultado;

    public static string PInicial(decimal PInicio,decimal PHora)
    {
        _resultado = ($"{PInicio} {PHora}");
        return _resultado;
    }

    public static string UsarResultado()
    {
       
        return _resultado;
    }


        /// ADIÇÃO//////// 
        //////////////////        
        
        public static void Adicionar()
        {

            Console.Clear();
            Console.Write("Digite a placa do veículo para estacionar: ");
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
                    Console.WriteLine("Placa Válida!!!");
                }

                else
                {
                    Console.WriteLine("Placa Inválida!!!");
                }


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
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine().ToUpper();

           
            var veiculo = EstacionamentoRepository.ProcurarUm(placa);


            if (veiculo != null)
            {


              string Pinicial= EstacionamentoService.UsarResultado();

                string Inicio = Pinicial.Substring(0, 1);
                // System.Console.WriteLine(ppp);
                 string Fim = Pinicial.Substring(2);

              
                decimal result = decimal.Parse(Inicio);
                decimal resultt = decimal.Parse(Fim);

               Estacionamento estacionamento = new Estacionamento(result,resultt);
                //  System.Console.WriteLine(Pinicial);

        
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = int.Parse(Console.ReadLine());
              
                 
                 decimal valorTotal = estacionamento.ValorPagar(horas);
                EstacionamentoRepository.Delete(placa);

              

                 Console.WriteLine($"O veículo  {placa}, foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Placa não existe no estacionamento!");
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
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var CopiaVeiculo in veiculos)
                {
                    Console.WriteLine($" {CopiaVeiculo.ToString()}");

                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

            Console.ReadKey();
            Console.Clear();
            Menu menu = new Menu();
            menu.ApresentarMenu();
        }
        

        //// VALIDAR ////// 
        ///////////////////  
        /// PFP1461//normal
        

        public static bool ValidarPlaca(string placa)
        {

            
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            
            if (placa.Length > 8) { return false; }



              string ppp = placa.Substring(0, 3); 
              bool indicativo = false;
              
           
             string numero = placa.Substring(placa.IndexOf('-')+1);
             bool ehValido = numero.ToCharArray().All(c => char.IsDigit(c));
             

            if (char.IsLetter(ppp,0) && char.IsLetter(ppp,1) && char.IsLetter(ppp,2)  && ehValido)
            {
             
             return indicativo=true;
                
            }
            else
            {
                System.Console.WriteLine("Placa fora do padrão");
               return indicativo=false;
               
            }
        }
    }
}