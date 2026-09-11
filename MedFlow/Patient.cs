using System;
using System.Collections.Generic;


namespace MedFlow;

public class Patient
{
    private DateOnly _geburtsdatum;
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Versichertennummer { get; set; }
    public DateOnly Geburtsdatum {
        get => _geburtsdatum;
        set
        {
            GeburtsdatumValidieren(value);
          
        }
    }
   
    public Patient(string vorname, string nachname, DateOnly geburtsdatum, string versichertennummer)
    {
       ArgumentNullException.ThrowIfNull("Der Vorname darf nicht leer sein.", nameof(Vorname));
       ArgumentNullException.ThrowIfNull("Der Vorname darf nicht leer sein.", nameof(Nachname));
       ArgumentNullException.ThrowIfNull("Der Vorname darf nicht leer sein.", nameof(Geburtsdatum));
       ArgumentNullException.ThrowIfNull("Der Vorname darf nicht leer sein.", nameof(Versichertennummer));
       Vorname = vorname;
       Nachname = nachname;
       Geburtsdatum = geburtsdatum;
       Versichertennummer = versichertennummer;
    }
    
    private static void GeburtsdatumValidieren(DateOnly geburtsdatum)
    {
        // wenn das Geburtsdatum in der Zukunft(morgen) liegt, dann 
        // ArgumentOutOfRangeException auswerfen 
        DateOnly heute = DateOnly.FromDateTime(DateTime.Today);
        if(geburtsdatum > heute)
        {
            throw new ArgumentOutOfRangeException(nameof(Geburtsdatum), "Das Geburtsdatum darf nicht in der Zukunft liegen.");
        }
    }

    public override string ToString()
    {
        return $"{Nachname}, {Vorname} | geb. {Geburtsdatum:dd.MM.yyyy} | Versichertennummer: {Versichertennummer}";
    }
}
