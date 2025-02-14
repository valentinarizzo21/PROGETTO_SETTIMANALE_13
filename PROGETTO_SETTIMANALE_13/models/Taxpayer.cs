using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGETTO_SETTIMANALE_13.models
{
    public class Taxpayer
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; } 
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public decimal RedditoAnnuale { get; set; }

        public Taxpayer(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, decimal redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }
        //dopo prova con switch case 
        public decimal CalculateTax()
        {
            decimal imposta = 0;
            decimal reddito = RedditoAnnuale;

            if (reddito <= 15000)
            {
                imposta = reddito * 0.23m;
            }
            else if (reddito <= 28000)
            {
                imposta = 15000 * 0.23m + (reddito - 15000) * 0.27m;
            }
            else if (reddito <= 55000)
            {
                imposta = 15000 * 0.23m + 13000 * 0.27m + (reddito - 28000) * 0.38m;
            }
            else if (reddito <= 75000)
            {
                imposta = 15000 * 0.23m + 13000 * 0.27m + 27000 * 0.38m + (reddito - 55000) * 0.41m;
            }
            else
            {
                imposta = 15000 * 0.23m + 13000 * 0.27m + 27000 * 0.38m + 20000 * 0.41m + (reddito - 75000) * 0.43m;
            }

            return imposta;
        }
    }
}
