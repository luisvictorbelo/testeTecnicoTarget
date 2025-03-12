using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolucaoTesteTargetSistemas.Classes
{
    public class Faturamento
    {
        public int Dia { get; set; }
        public decimal Valor { get; set; }
        
        public static decimal MenorFaturamento(List<Faturamento> lista) {
            
            return  lista.Min(l => l.Valor);
        }

        public static decimal MaiorFaturamento(List<Faturamento> lista) {
            
            return lista.Max(l => l.Valor);
        }

        public static decimal Media(List<Faturamento> lista) {
            
            int diasNaoNulos = lista.Count(l => l.Valor != 0);
            
            decimal somaFaturamento = lista.Sum(l => l.Valor);

            return somaFaturamento / diasNaoNulos;
        }

        public static int DiasAcimaDaMedia(List<Faturamento> lista, decimal media) {

            return lista.Count(l => l.Valor > media);
        }
    }
}