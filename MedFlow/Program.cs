namespace MedFlow;

public class Program
{
    static void Main(string[] args)
    {
        Patientenverwaltung patientenverwaltung = new();
        bool weiter = true;
        while (weiter)
        {
            Console.WriteLine("\n=== MedFlow ===");
            Console.WriteLine("1) Patient anlegen");
            Console.WriteLine("2) Alle Patienten anzeigen");
            Console.WriteLine("0) Beenden");
            Console.WriteLine("Auswahl:");
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

    private static DateOnly GeburtsdatumFordern()
    {
        while (true)
        {
            string eingabe = EingabeFordern("Geburtsdatum");

            if (DateOnly.TryParse(eingabe, out DateOnly geburtsdatum))
            {
                return geburtsdatum;
            }

            Console.WriteLine(
                "Ungültiges Datumsformat oder kein Geburtsdatum angegeben.\n" +
                "Bitte geben Sie das Datum in einem der folgenden Formate ein:\n" +
                "[dd.MM.yyyy] oder [dd/MM/yyyy] oder [dd-MM-yyyy]");
        }
    }

    private static string VornameFordern()
    {
        while (true)
        {
            string vorname = EingabeFordern("Vorname");
            if (vorname.All(char.IsLetter))
            {
                return vorname;
            }
            Console.WriteLine("Der Vorname darf nur aus Buchstaben bestehen");
        }
    }
    
    private static string NachnameFordern()
    {
        while (true)
        {
            string nachname = EingabeFordern("Nachname");
            if(nachname.All(char.IsLetter))            
                return nachname;
            Console.WriteLine("Der Nachname darf nur Buchstabe bestehen.");
            
        }
    }

    private static void PatientAnlegen(Patientenverwaltung patientenverwaltung)
    {
        Console.WriteLine("\n--- Patient anlegen ---");
        string vorname = VornameFordern();
        string nachname = NachnameFordern();
        string versichertennummer = EingabeFordern("Versichertennummer");
        DateOnly geburtsdatum = GeburtsdatumFordern();

        try
        {
            Patient neuerPatient = new(
                vorname,
                nachname,
                geburtsdatum,
                versichertennummer);

            patientenverwaltung.Anlegen(neuerPatient);

            Console.WriteLine("Patient wurde erfolgreich angelegt.");
        }
        catch (ArgumentOutOfRangeException exc)
        {
            Console.WriteLine($"Fehler: {exc.Message}");
        }
        catch (ArgumentNullException exc)
        {
            Console.WriteLine($"Fehler: {exc.Message}");
        }
        catch (Exception exc)
        {
            Console.WriteLine($"Fehler: {exc.Message}");
        }

    }

    private static void AllePatientenAnzeigen(Patientenverwaltung patientenverwaltung)
    {
        if (patientenverwaltung.AlleAbrufen().Count == 0)
        {
            Console.WriteLine("die Patientenliste ist leer.");
            return;
        }

        foreach (var patient in patientenverwaltung.AlleAbrufen())
        {
            Console.WriteLine(patient);
        }
    }
}
