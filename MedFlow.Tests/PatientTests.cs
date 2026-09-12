namespace MedFlow.Tests
{
    public class PatientTests
    {
        [Fact]
        public void Konstruktor_MitGueltigenDaten_SetztEigenschaften()
        {
            var patient = new Patient("Max", "Mustermann", new DateOnly(1985, 3, 14), "A123456789");
            Assert.Equal("Max", patient.Vorname);
            Assert.Equal("Mustermann", patient.Nachname);
            Assert.Equal(new DateOnly(1985, 3, 14), patient.Geburtsdatum);
            Assert.Equal("A123456789", patient.Versichertennummer);
        }

        [Fact]
        public void Konstruktor_MitLeeremVornamen_WirftArgumentException()
        {
            var patient = new Patient("", "Mustermann", new DateOnly(1985, 3, 14), "A123456789");
            Assert.Throws<ArgumentException>(() => patient.Vorname == "Max");
        }
        [Fact]
        public void Konstruktor_MitLeererVersichertennummer_WirftArgumentException()
        {
            var patient = new Patient("", "Mustermann", new DateOnly(1985, 3, 14), "A123456789");
            Assert.Throws<ArgumentException>(() => patient.Versichertennummer == "A123456789");
        }
        [Fact]
        public void Konstruktor_MitGeburtsdatumInDerZukunft_WirftArgumentOutOfRangeException()
        {
            var patient = new Patient("", "Mustermann", new DateOnly(2027, 3, 14), "A123456789");
            Assert.Throws<ArgumentException>(() => patient.Geburtsdatum == new DateOnly(1985, 3, 14));
        }
    }
}
