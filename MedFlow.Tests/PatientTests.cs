namespace MedFlow.Tests;

public class PatientTests
{
    [Fact]
    public void Konstruktor_Mit_Gueltigen_Daten_Setzt_Eigenschaften()
    {
        var patient = new Patient(
            "Max", 
            "Min", 
            new DateOnly(1985, 3, 14), 
            "A12"
        );
        Assert.Equal("Max", patient.Vorname);
        Assert.Equal("Min", patient.Nachname);
        Assert.Equal(new DateOnly(1985, 3, 14), patient.Geburtsdatum);
        Assert.Equal("A12", patient.Versichertennummer);
    }

    [Fact]
    public void Konstruktor_Mit_Leerem_Vornamen_Wirft_ArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => new Patient(
                "", 
                "Min", 
                new DateOnly(1985, 3, 14), "A12"));
    }

    [Fact]
    public void Konstruktor_Mit_Leerer_Versichertennummer_Wirft_ArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => new Patient(
                "Max", 
                "Min", 
                new DateOnly(1985, 3, 14), 
                ""
             )
        );
    }


   [Fact]
    public void Konstruktor_Mit_Geburtsdatum_In_Der_Zukunft_Wirft_ArgumentOutOfRangeException()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => new Patient(
                "Max", 
                "Min", 
                DateOnly.FromDateTime(DateTime.Today).AddDays(1), 
                "A12")
            );
        Assert.Equal("geburtsdatum", exception.ParamName);
    }

    [Fact]
    public void Konstruktor_Mit_Leerem_Nachnamen_Wirft_ArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => new Patient(
                "Max", 
                "", 
                new DateOnly(1985, 3, 14), "A12"));
    }
    [Fact]
    public void Konstruktor_Mit_Nur_Leerzeichen_Im_Vornamen_Wirft_ArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => new Patient(
                "   ", 
                "Min", 
                new DateOnly(1985, 3, 14), 
                "A12"));
    }

    [Theory]
    [InlineData("Anna-Lena")]
    [InlineData("O'Brien")]
    [InlineData("van der Berg")]
   
    public void Konstruktor_Mit_Gueltigem_Vornamen_LegtPatientAn(string vorname)
    {
        var patient = new Patient(vorname, "Min", new DateOnly(2001,1,1), "A12344");
       
        Assert.Equal(vorname, patient.Vorname);
    }

    [Theory]
    [InlineData("-")]
    [InlineData("1Max")]
    [InlineData("'")]
    [InlineData("____")]
    [InlineData("---")]
    [InlineData("M*ax")]
    [InlineData("M_ax")]
    public void Konstruktor_Mit_Ungueltigem_Vornamen_Wirft_ArgumentException(string vorname)
    {

        var exception = Assert.Throws<ArgumentException>(
            () => new Patient(
                vorname,
                "Min",                
                new DateOnly(2001,1,1),
                "A12344")
         );

        Assert.Equal("vorname", exception.ParamName);

    }


    [Theory]
    [InlineData("-")]
    [InlineData("1Fax")]
    [InlineData("'")]
    [InlineData("____")]
    [InlineData("---")]
    [InlineData("F*ax")]
    [InlineData("F_ax")]

    public void Konstruktor_Mit_Ungueltigem_Nachnamen_WirftArgumentException(string nachname)
    {

        var exception = Assert.Throws<ArgumentException>(
            () => new Patient(
               "Max",
               nachname,
                new DateOnly(2005, 5, 5),
               "A12344"));
        Assert.Equal("nachname", exception.ParamName);

    }

    
    [Theory]
    [InlineData("Müller")]
    [InlineData("José")]
    [InlineData("Max Müller")]
    [InlineData("José-Maria")]
    public void Ist_Gueltiger_Name_Mit_Sonderzeichen_Liefert_True(string name)
    {
            bool ergebnis = Patient.IstGueltigerName(name);

            Assert.True(ergebnis);
    }



    [Fact]
    public void Konstruktor_Mit_Fuehrenden_Und_Nachfolgenden_Leerzeichen_Speichert_Getrimmte_Werte()
    {
        // Arrange
        string vorname = "  Adam  ";
        string nachname = "  Anton  ";
        string versichertennummer = "  A12345678   ";
        DateOnly geburtsdatum = new(2001, 1, 1);

        // Act
        var patient = new Patient(
            vorname,
            nachname,
            geburtsdatum,
            versichertennummer);

        // Assert
        Assert.Equal("Adam", patient.Vorname);
        Assert.Equal("Anton", patient.Nachname);
        Assert.Equal("A12345678", patient.Versichertennummer);
        Assert.Equal(new DateOnly(2001, 1, 1), patient.Geburtsdatum);
    }
}

