namespace MedFlow
{
    public class Patientenverwaltung
    {
        private readonly List<Patient> _patienten = new List<Patient>();
        public void Anlegen(Patient patient)
        {
            _patienten.Add(patient);
        }
        public IReadOnlyList<Patient> AlleAbrufen()
        {
            return _patienten;
        }
    }
}
