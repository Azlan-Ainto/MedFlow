namespace MedFlow;
public class Program
{
    static void Main(string[] args)
    {
        Patient patient = new("Max","Mustermann", new DateOnly(1985,3,14),"A123456789");
        Console.WriteLine(patient);
    }
}
