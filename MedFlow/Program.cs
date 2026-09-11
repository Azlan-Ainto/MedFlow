namespace MedFlow;

public class Program
{
    static void Main(string[] args)
    {
        Patient patient = new("Max", "Mustermann", new DateOnly(1985, 3, 14), "A123456789");
        Console.WriteLine(patient);

        // Handtest

       //var a = new Patient("Max", "Mustermann", new DateOnly(2030, 1, 1), "A1");   // Zukunft
      // var b = new Patient("", "Mustermann", new DateOnly(1985, 3, 14), "A1");     // leerer Vorname
       // var c = new Patient("Max", "Mustermann", new DateOnly(1985, 3, 14), "  ");  // nur Leerzeichen
    }
}
