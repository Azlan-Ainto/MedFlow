namespace MedFlow;

public class Patientenverwaltung
{
    private readonly List<Patient> _patienten = new();
    public bool TryAnlegen(Patient patient)
    {
        ArgumentNullException.ThrowIfNull(patient);

        bool patientExistiert = _patienten.Any(p => string.Equals(
            p.Versichertennummer,
            patient.Versichertennummer,
            StringComparison.OrdinalIgnoreCase));

        if (patientExistiert)
        {
            Console.WriteLine($"Ein Patient mit der Versichertennummer {patient.Versichertennummer} existiert bereit.");
            return false;
        }
        else
        {
            _patienten.Add(patient);
        }

        return true;
    }

      
    public IReadOnlyList<Patient> AlleAbrufen()
    {
        return _patienten;
    }
}
    