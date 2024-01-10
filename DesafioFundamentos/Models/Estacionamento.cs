namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        
        private decimal precoInicial {get;set;} = 0;
        private decimal precoPorHora {get;set;} = 0;
        private List<string> veiculos { get; set; }
       
        public  Estacionamento(decimal precoInicial, decimal precoHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoHora;
            
        }

      

        public decimal ValorPagar(int horas){

            return precoInicial + precoPorHora * horas;

        }
    }
}
