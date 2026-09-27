
namespace MedFlow;

public class Program
{
    private const string NamensregelHinweis =
        "Erlaubt sind " +
        "Buchstaben, " +
        "Leerzeichen, " +
        "Bindestrich und " +
        "Apostroph.";


    static void Main(string[] args)
    {
        Patientenverwaltung patientenverwaltung = new();
        bool weiter = true;
        while (weiter)
        {
            Console.WriteLine("\n================================================================");
            Console.WriteLine("*** MedFlow - Ihr CRM Profi für die Verwaltung von Patienten ***");
            Console.WriteLine("=================================================================");
            Console.WriteLine();

            Console.WriteLine("1) Patient anlegen");
            Console.WriteLine("2) Alle Patienten anzeigen");
            Console.WriteLine("0) Beenden");
            Console.WriteLine();
            Console.Write("Auswahl: ");
            string? auswahl = Console.ReadLine();
            switch (auswahl)
            {
                case "1":
                    PatientAnlegen(patientenverwaltung);
                    break;
                case "2":
                    AllePatientenAnzeigen(patientenverwaltung);
                    break;
                case "0":

                    Console.WriteLine("Programm wird beendet.");
                    weiter = false;
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }
        }
    }

    private static string EingabeFordern(string feldname)
    {
        string? eingabe;
        do
        {
            Console.Write($"Geben Sie {feldname} ein:");
            eingabe = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(eingabe))
            {
                Console.WriteLine("Die Eingabe darf nicht leer sein.");
            }
         

        } while (string.IsNullOrWhiteSpace(eingabe));

        return eingabe;
    }

    private static string VornameFordern()
    {
        while (true)
        {
            string vorname = EingabeFordern("Vorname");
            if (Patient.IstGueltigerName(vorname))
            {
                return vorname;
            }
            Console.WriteLine(NamensregelHinweis);
        }
    }

    private static string NachnameFordern()
    {
        while (true)
        {
            string nachname = EingabeFordern("Nachname");
            if (Patient.IstGueltigerName(nachname))
                return nachname;
            Console.WriteLine(NamensregelHinweis);

        }
    }

    private static DateOnly GeburtsdatumFordern()
    {
        string[] erlaubteFormate =
        {
            "dd.MM.yyyy",
            "dd/MM/yyyy"
        };

        while (true)
        {
            string geburtsdatumEingabe = EingabeFordern("Geburtsdatum");


            bool istGeburtsdatumsformatRichtig = DateOnly.TryParseExact(
                geburtsdatumEingabe,
                erlaubteFormate,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateOnly geburtsdatum
             );

            if (istGeburtsdatumsformatRichtig && Patient.IstGueltigesGeburtsdatum(geburtsdatum))
                return geburtsdatum;

            Console.WriteLine(
                $"Erlaubte Formate: " +
                $"{erlaubteFormate[0]}, " +
                $"{erlaubteFormate[1]}"
            );
        }
    }

    private static void PatientAnlegen(
        Patientenverwaltung patientenverwaltung
    )
    {

        Console.WriteLine("*** Patient anlegen ****");
        Console.WriteLine();
        string vorname = VornameFordern();
        string nachname = NachnameFordern();
        string versichertennummer = EingabeFordern("Versichertennummer");
        DateOnly geburtsdatum = GeburtsdatumFordern();

        try
        {
            Patient neuerPatient = new(vorname, nachname, geburtsdatum, versichertennummer);

            var istPatientRichtigErstellt = patientenverwaltung.TryAnlegen(neuerPatient);
            if (istPatientRichtigErstellt)
            {
                Console.WriteLine("Patient wurde erfolgreich angelegt.");
            }
            else
            {
                Console.WriteLine("... Der Patient wurde nicht angelegt! ...");
            }
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine($"Fehler: {exc.Message}");
        }
    }

    private static void AllePatientenAnzeigen(
        Patientenverwaltung patientenverwaltung
    )
    {
        Console.WriteLine("*** In der Liste existieren folgende Patienten: ***");

        var patientenliste = patientenverwaltung.AlleAbrufen();
        if (patientenliste.Count == 0)
            return;

        foreach (var patient in patientenliste)
        {
            Console.WriteLine("\n" + patient);
        }

    }
}
