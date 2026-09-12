namespace MedFlow.Tests;

public class PatientTests
{
    [Fact]
    public void Konstruktor_MitGueltigenDaten_SetztEigenschaften()
    {
        var patient = new Patient("Max", "Min", new DateOnly(1985, 3, 14), "A12");
        Assert.Equal("Max", patient.Vorname);
        Assert.Equal("Min", patient.Nachname);
        Assert.Equal(new DateOnly(1985, 3, 14), patient.Geburtsdatum);
        Assert.Equal("A12", patient.Versichertennummer);
    }

    [Fact]
    public void Konstruktor_MitLeeremVornamen_WirftArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Patient("", "Min", new DateOnly(1985, 3, 14), "A12"));
    }

    [Fact]
    public void Konstruktor_MitLeererVersichertennummer_WirftArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Patient("Max", "Min", new DateOnly(1985, 3, 14), ""));
    }

    [Fact]
    public void Konstruktor_MitGeburtsdatumInDerZukunft_WirftArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Patient("Max", "Min", new DateOnly(2027, 3, 14), "A12"));
    }
}

