using DesafioFundamentos.Models;
using Microsoft.VisualBasic;

namespace DesafioFundamentos.Repository
{
    
    public class EstacionamentoRepository
    {
       
        private static List<Veiculo> veiculos = new List<Veiculo>();

         // ADICIONAR //
        public static void Adicionar(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }
        
        // LISTAR //
        public static List<Veiculo> Listar()
        {
            return veiculos;
        }
         
        // PROCURAR //
        public static Veiculo ProcurarUm(string placa)
        {
           return  veiculos.FirstOrDefault(e => e.Placa == placa);

        }
        
        // DELETAR //
        public static void Delete(string placa)
        {
            
            var veiculo = ProcurarUm(placa);
            veiculos.Remove(veiculo);
}
    }
}