namespace MedFlow.Tests;

public class PatientenverwaltungTests
{

    [Fact]
    public void TryAnlegen_MitNeuemPatienten_GibtTrueZurueck()
    {
        var verwaltung = new Patientenverwaltung();
        var patient = new Patient("Max", "Min", new DateOnly(1986, 12, 02), "A123456789");
        bool ergebnis = verwaltung.TryAnlegen(patient);
        Assert.True(ergebnis);
        Assert.Single(verwaltung.AlleAbrufen());
    }
    [Fact]
    public void TryAnlegen_MitBereitsVorhandenerVersichertennummer()
    {
        // 1.Arrange
        var verwaltung = new Patientenverwaltung();
        var ersterPatient = new Patient("Max", "Min", new DateOnly(1986, 12, 02), "A123456789");
        var zweiterPatient = new Patient("Max", "Min", new DateOnly(1986, 12, 02), "A123456789");

        verwaltung.TryAnlegen(ersterPatient);   
        // 2.Act
        bool ergebnis = verwaltung.TryAnlegen(zweiterPatient);
        // 3.Asssert
        Assert.False(ergebnis);
        Assert.Single(verwaltung.AlleAbrufen());
    }

    [Fact]
    public void TryAnlegen_MitNull_WirftArgumentNullException()
    {
        // Arrange
        var verwaltung = new Patientenverwaltung();
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => verwaltung.TryAnlegen(null!));
    }


    [Fact]
    public void TryAnlegen_MitGleicherVersichertennummerAberAndererGrossschreibung_GibtFalseZurueck()
    { 
        // Arrange
        var verwaltung = new Patientenverwaltung();
        var ersterPatient = new Patient("Max", "Mustermann", new DateOnly(1985, 3, 14), "A12345678");
        var zweiterPatient = new Patient("Peter", "Muster", new DateOnly(1990, 5, 20), "a12345678");
        verwaltung.TryAnlegen(ersterPatient);
        // Act
        bool ergebnis = verwaltung.TryAnlegen(zweiterPatient);
        // Assert
        Assert.False(ergebnis);
        Assert.Single(verwaltung.AlleAbrufen());
    }
}
