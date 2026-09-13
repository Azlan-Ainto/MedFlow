
namespace MedFlow.Tests;

public class PatientenverwaltungTests
{
    [Fact]
    public void Anlegen_MitNull_WirftArgumentNullException()
    {
        var patientveraltung = new Patientenverwaltung();
        Patient? patient = null;
        patientveraltung.Anlegen(patient);

    }

    [Fact]
    public void Anlegen_MitNeuerVersichertennummer_FuegtPatientHinzu()
    {
        // Arrange
        var patientenverwaltung = new Patientenverwaltung();
        var patient = new Patient("Max", "Min", new DateOnly(2004, 01, 01), "A123");

        // Act
        patientenverwaltung.Anlegen(patient);
        //Assert
        var patientenListe = patientenverwaltung.AlleAbrufen();
        Assert.Single(patientenListe);
        Assert.Same(patient, patientenListe.First());
    }

    [Fact]
    public void Anlegen_MitBereitsVorhandenerVersichertennummer_WirftInvalidOperationException()
    {
        var verwaltung = new Patientenverwaltung();
        var ersterPatient = new Patient("Max", "Min", new DateOnly(1985, 3, 14), "A123");
        var zweiterPatient = new Patient("Max", "Min", new DateOnly(1985, 3, 14), "A123");

        verwaltung.Anlegen(ersterPatient);
        Assert.Throws<InvalidOperationException>(() => verwaltung.Anlegen(zweiterPatient));
        Assert.Single(verwaltung.AlleAbrufen());
    }

    [Fact]
    public void Anlegen_MitVersichertennummerInAndererSchreibweise_WirftInvalidOperationException()
    {
        var verwaltung = new Patientenverwaltung();
        var ersterPatient = new Patient("Max", "Min", new DateOnly(1985, 3, 14), "A123");
        var zweiterPatient = new Patient("Peter", "Pan", new DateOnly(1990, 7, 20), "a123");
        verwaltung.Anlegen(ersterPatient);
        Assert.Throws<InvalidOperationException>(() => verwaltung.Anlegen(zweiterPatient));
        Assert.Single(verwaltung.AlleAbrufen());
    }
}
