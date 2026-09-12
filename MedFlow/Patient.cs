namespace MedFlow;

public class Patient
{
    private DateOnly _geburtsdatum;
    public string Vorname { get; private set; }
    public string Nachname { get; private set; }
    public string Versichertennummer { get; private set; }

    public DateOnly Geburtsdatum
    {
        get => _geburtsdatum;
        private set
        {
            GeburtsdatumValidieren(value);
            _geburtsdatum = value;
        }
    }

    public Patient(string vorname, string nachname, DateOnly geburtsdatum, string versichertennummer)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(vorname);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(nachname);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(versichertennummer);

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
            throw new ArgumentOutOfRangeException(nameof(geburtsdatum), geburtsdatum, "Das Geburtsdatum darf nicht in der Zukunft liegen.");
        }
    }

    public override string ToString()
    {
        return $"{Nachname}, {Vorname} | geb. {Geburtsdatum:dd.MM.yyyy} | Versichertennummer: {Versichertennummer}";
    }
}