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

    public Patient(string vorname,string nachname, DateOnly geburtsdatum, string versichertennummer)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vorname);
        ArgumentException.ThrowIfNullOrWhiteSpace(nachname);
        ArgumentException.ThrowIfNullOrWhiteSpace(versichertennummer);

        if (!IstGueltigerName(vorname))
            throw new ArgumentException("Der Vorname enthält ungültige Zeichen.", nameof(vorname));

        if (!IstGueltigerName(nachname))
            throw new ArgumentException("Der Nachname enthält ungültige Zeichen.", nameof(nachname));

        Vorname = vorname;
        Nachname = nachname;
        Versichertennummer = versichertennummer;
        Geburtsdatum = geburtsdatum;
    }
    private static bool IstGueltigerName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\'');
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