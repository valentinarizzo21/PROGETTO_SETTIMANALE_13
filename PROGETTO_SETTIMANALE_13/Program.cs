﻿using System;
using PROGETTO_SETTIMANALE_13.models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE");

        Console.Write("Inserisci il tuo nome: ");
        string nome = Console.ReadLine();
        while (string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("Il nome non può essere vuoto.");
            Console.Write("Inserisci il tuo nome: ");
            nome = Console.ReadLine();
        }

        Console.Write("Inserisci il tuo cognome: ");
        string cognome = Console.ReadLine();
        while (string.IsNullOrEmpty(cognome))
        {
            Console.WriteLine("Il cognome non può essere vuoto.");
            Console.Write("Inserisci il tuo cognome: ");
            cognome = Console.ReadLine();
        }

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
        Console.Write("Inserisci il tuo sesso (M/F/N): ");
        while (!char.TryParse(Console.ReadLine().ToUpper(), out sesso) || (sesso != 'M' && sesso != 'F' && sesso != 'N'))
        {
            Console.WriteLine("Inserisci solo M, F o N.");
            Console.Write("Inserisci il sesso (M/F/N): ");
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
        Console.WriteLine($"\nDati contribuente: {taxpayer.Nome} {taxpayer.Cognome}, ");
        Console.WriteLine($"\nNato/a il {taxpayer.DataNascita:dd/MM/yyyy} ({taxpayer.Sesso}), ");
        Console.WriteLine($"\nResidente in {taxpayer.ComuneResidenza}, ");
        Console.WriteLine($"\nCodice fiscale: {taxpayer.CodiceFiscale}");
        Console.WriteLine($"\nReddito dichiarato: {taxpayer.RedditoAnnuale:C}");
        Console.WriteLine($"\nIMPOSTA DA VERSARE: {imposta:C}");
    }
}
