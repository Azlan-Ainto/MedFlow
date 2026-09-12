namespace MedFlow;

public class Patientenverwaltung
{
    private readonly List<Patient> _patienten = new();
    public void Anlegen(Patient patient)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(patient));        
        bool patientExistiert = _patienten.Any(p => string.Equals(
            p.Versichertennummer,
            patient.Versichertennummer, 
            StringComparison.OrdinalIgnoreCase));
        if (patientExistiert){
            throw new InvalidOperationException("Ein Patient mit der dieser Versichertennummer existiert bereits.");
        }
        _patienten.Add(patient);
    }
    public IReadOnlyList<Patient> AlleAbrufen(){
        return _patienten;
    }
}
