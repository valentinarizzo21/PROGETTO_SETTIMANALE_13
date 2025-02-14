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

        public class Tax
        {
            public decimal LowerLimit { get; set; }
            public decimal UpperLimit { get; set; }
            public decimal Rate { get; set; }

            public Tax(decimal lowerLimit, decimal upperLimit, decimal rate)
            {
                LowerLimit = lowerLimit;
                UpperLimit = upperLimit;
                Rate = rate;
            }
        }

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
        //dopo prova con switch case per vedere il flusso del codice!!!!
        //
        //public decimal CalculateTax()
        //{
        //    decimal imposta = 0;
        //    decimal reddito = RedditoAnnuale;

        //    if (reddito <= 15000)
        //    {
        //        imposta = reddito * 0.23m;
        //    }
        //    else if (reddito <= 28000)
        //    {
        //        imposta = 15000 * 0.23m + (reddito - 15000) * 0.27m;
        //    }
        //    else if (reddito <= 55000)
        //    {
        //        imposta = 15000 * 0.23m + 13000 * 0.27m + (reddito - 28000) * 0.38m;
        //    }
        //    else if (reddito <= 75000)
        //    {
        //        imposta = 15000 * 0.23m + 13000 * 0.27m + 27000 * 0.38m + (reddito - 55000) * 0.41m;
        //    }
        //    else
        //    {
        //        imposta = 15000 * 0.23m + 13000 * 0.27m + 27000 * 0.38m + 20000 * 0.41m + (reddito - 75000) * 0.43m;
        //    }

        //    return imposta;
        //}
        public List<Tax> GetTax()
        {
            return new List<Tax>
            {
                new Tax(0, 15000, 0.23m),
                new Tax(15000, 28000, 0.27m),
                new Tax(28000, 55000, 0.38m),
                new Tax(55000, 75000, 0.41m),
                new Tax(75000, decimal.MaxValue, 0.43m)
            };
        }
        //public decimal CalculateTax()
        //{
        //    decimal imposta = 0;
        //    decimal reddito = RedditoAnnuale;

        //    if (reddito <= 15000)
        //    {
        //        imposta = CalcolaImpostaFinoA15000(reddito);
        //    }
        //    else if (reddito <= 28000)
        //    {
        //        imposta = CalcolaImpostaFinoA28000(reddito);
        //    }
        //    else if (reddito <= 55000)
        //    {
        //        imposta = CalcolaImpostaFinoA55000(reddito);
        //    }
        //    else if (reddito <= 75000)
        //    {
        //        imposta = CalcolaImpostaFinoA75000(reddito);
        //    }
        //    else
        //    {
        //        imposta = CalcolaImpostaOltre75000(reddito);
        //    }

        //    return imposta;
        //}

        //private decimal CalcolaImpostaFinoA15000(decimal reddito)
        //{
        //    return reddito * 0.23m;
        //}

        //private decimal CalcolaImpostaFinoA28000(decimal reddito)
        //{
        //    return 15000 * 0.23m + (reddito - 15000) * 0.27m;
        //}

        //private decimal CalcolaImpostaFinoA55000(decimal reddito)
        //{
        //    return 15000 * 0.23m + 13000 * 0.27m + (reddito - 28000) * 0.38m;
        //}

        //private decimal CalcolaImpostaFinoA75000(decimal reddito)
        //{
        //    return 15000 * 0.23m + 13000 * 0.27m + 27000 * 0.38m + (reddito - 55000) * 0.41m;
        //}

        //private decimal CalcolaImpostaOltre75000(decimal reddito)
        //{
        //    return 15000 * 0.23m + 13000 * 0.27m + 27000 * 0.38m + 20000 * 0.41m + (reddito - 75000) * 0.43m;
        //}

        public decimal CalculateTax()
        {
            decimal imposta = 0;
            decimal reddito = RedditoAnnuale;

            foreach (var tax in GetTax())
            {
                if (reddito > tax.LowerLimit)
                {
                    decimal taxableIncome = Math.Min(reddito, tax.UpperLimit) - tax.LowerLimit;
                    imposta += taxableIncome * tax.Rate;
                }
            }

            return imposta;
        }

    }
}
