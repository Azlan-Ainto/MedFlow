using static System.ArgumentException;
namespace MedFlow;

public class Patient
{

    public string Vorname { get; private set; }
    public string Nachname { get; private set; }
    public string Versichertennummer { get; private set; }
    public DateOnly Geburtsdatum { get; private set; }
        
        

    public Patient(
        string vorname,
        string nachname, 
        DateOnly geburtsdatum, 
        string versichertennummer
    ){
        ThrowIfNullOrWhiteSpace(vorname);
        ThrowIfNullOrWhiteSpace(nachname);
        ThrowIfNullOrWhiteSpace(versichertennummer);

        if (!IstGueltigerName(vorname))
            throw new ArgumentException(
                "Der Vorname enthält ungültige Zeichen.", 
                nameof(vorname)
             );

        if (!IstGueltigerName(nachname))

            throw new ArgumentException(
                "Der Nachname enthält ungültige Zeichen.", 
                nameof(nachname)
            );

        if (!IstGueltigesGeburtsdatum(geburtsdatum))

            throw new ArgumentOutOfRangeException(
                   nameof(geburtsdatum),
                   geburtsdatum,
                    "Das Geburtsdatum darf nicht in der Zukunt sein"
             
             );

        Vorname = vorname.Trim();
        Nachname = nachname.Trim();
        Versichertennummer = versichertennummer.Trim();
        Geburtsdatum = geburtsdatum;
    }
    public static bool IstGueltigerName(string name)
    {
        return !string.IsNullOrWhiteSpace(name)&& 
                        name.Any(char.IsLetter)&& 
                        name.All(
                            c => 
                            char.IsLetter(c) || 
                            c == ' ' || 
                            c == '-' || 
                            c == '\'');
    }

    public static bool IstGueltigesGeburtsdatum(
        DateOnly geburtsdatum
    )
    {
        DateOnly heute = DateOnly.FromDateTime(DateTime.Today);

        if (geburtsdatum > heute)
            return false;
        return true;
    }


    public override string ToString()
    {
        return 
            $"{Nachname}, " +
            $"{Vorname} | " +
            $"geb. {Geburtsdatum:dd.MM.yyyy} | " +
            $"Versichertennummer: {Versichertennummer}";
    }
}