using System;
using PROGETTO_SETTIMANALE_13.models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE");

        Console.Write("Inserisci il tuo nome: ");
        string nome = Console.ReadLine();

        Console.Write("Inserisci il tuo cognome: ");
        string cognome = Console.ReadLine();

        DateTime dataNascita;
        Console.Write("Inserisci la tua data di nascita (gg/mm/aaaa): ");
        while (!DateTime.TryParse(Console.ReadLine(), out dataNascita))
        {
            Console.WriteLine("Formato data non valido. Riprova.");
            Console.Write("Inserisci la tua data di nascita (gg/mm/aaaa): ");
        }

        Console.Write("Inserisci il tuo codice fiscale: ");
        string codiceFiscale = Console.ReadLine();

        char sesso;
        Console.Write("Inserisci il tuo sesso (M/F/ND): ");
        while (!char.TryParse(Console.ReadLine().ToUpper(), out sesso) || (sesso != 'M' && sesso != 'F'))
        {
            Console.WriteLine("Inserisci solo M, F o ND.");
            Console.Write("Inserisci il sesso (M/F/ND): ");
        }

        Console.Write("Inserisci il tuo comune di residenza: ");
        string comuneResidenza = Console.ReadLine();

        decimal redditoAnnuale;
        Console.Write("Inserisci il tuo reddito annuale: ");
        while (!decimal.TryParse(Console.ReadLine(), out redditoAnnuale))
        {
            Console.WriteLine("Importo non valido. Inserisci un numero.");
            Console.Write("Inserisci il tuo reddito annuale: ");
        }

        Taxpayer taxpayer = new Taxpayer(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

        decimal imposta = taxpayer.CalculateTax();

        Console.WriteLine("\nCALCOLO DELL'IMPOSTA DA VERSARE:");
        Console.WriteLine($"Dati contribuente: {taxpayer.Nome} {taxpayer.Cognome}, ");
        Console.WriteLine($"nato/a il {taxpayer.DataNascita:dd/MM/yyyy} ({taxpayer.Sesso}), ");
        Console.WriteLine($"residente in {taxpayer.ComuneResidenza}, ");
        Console.WriteLine($"codice fiscale: {taxpayer.CodiceFiscale}");
        Console.WriteLine($"Reddito dichiarato: {taxpayer.RedditoAnnuale:C}");
        Console.WriteLine($"IMPOSTA DA VERSARE: {imposta:C}");
    }
}
