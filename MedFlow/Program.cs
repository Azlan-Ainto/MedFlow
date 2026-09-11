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
            string? auswah = Console.ReadLine();
            switch (auswah)
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
                    return;
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
    private static void PatientAnlegen(Patientenverwaltung patientenverwaltung)
    {
        Console.WriteLine("\n--- Patient anlegen ---");
        string vorname = EingabeFordern("Vorname");
        string nachname = EingabeFordern("Nachname");
        string versichertennummer = EingabeFordern("Versichertennummer");

        DateOnly patientGeburtsdatum;

        while (true)
        {
            string eingabe = EingabeFordern("Geburtsdatum");

            if (!DateOnly.TryParse(eingabe, out patientGeburtsdatum))
            {
                Console.WriteLine("Ungültiges Datumsformat.");
                continue;
            }

            try
            {
                Patient neuerPatient = new(vorname,nachname,patientGeburtsdatum,versichertennummer);
                patientenverwaltung.Anlegen(neuerPatient);
                Console.WriteLine("Patient wurde erfolgreich angelegt.");
                break;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
                Console.WriteLine("Bitte geben Sie ein gültiges Geburtsdatum ein.");
            }
        }
      }       
    
    private static void AllePatientenAnzeigen(Patientenverwaltung patientenverwaltung)
    {
        if (patientenverwaltung.AlleAbrufen().Count == 0)
        {
            Console.WriteLine("die Patientenliste ist leer.");
        }

        foreach (var patient in patientenverwaltung.AlleAbrufen())
        {
            Console.WriteLine(patient);
        }
    }
}
