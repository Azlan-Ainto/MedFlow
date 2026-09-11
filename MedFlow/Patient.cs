namespace MedFlow;

public class Patient
{
    private DateOnly _geburtsdatum;
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Versichertennummer { get; set; }

    public DateOnly Geburtsdatum
    {
        get => _geburtsdatum;
        set
        {
            GeburtsdatumValidieren(value);
            _geburtsdatum = value;
        }
    }

    public Patient(string vorname,string nachname,DateOnly geburtsdatum,string versichertennummer)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vorname,"Der Vorname darf nicht leer sein.");
        ArgumentException.ThrowIfNullOrWhiteSpace(nachname,"Der Nachname darf nicht leer sein.");
        ArgumentException.ThrowIfNullOrWhiteSpace(versichertennummer,"Die Versichertennummer darf nicht leer sein.");

        Vorname = vorname;
        Nachname = nachname;
        Versichertennummer = versichertennummer;
        Geburtsdatum = geburtsdatum;
    }

    private static void GeburtsdatumValidieren(DateOnly geburtsdatum)
    {
        DateOnly heute = DateOnly.FromDateTime(DateTime.Today);

        if (geburtsdatum > heute)
        {
            throw new ArgumentOutOfRangeException(nameof(geburtsdatum),geburtsdatum,"Das Geburtsdatum darf nicht in der Zukunft liegen.");
        }
    }

    public override string ToString()
    {
        return $"{Nachname}, {Vorname} | geb. {Geburtsdatum:dd.MM.yyyy} | Versichertennummer: {Versichertennummer}";
    }
}