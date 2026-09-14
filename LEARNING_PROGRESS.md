# Thema: 
* Projektaufbau, Klassen, Validierung, Git, erste Unit Tests
## Entwickelt: 
* Patient, Patientenverwaltung, Konsolenmenü, xUnit-Testprojekt
# Fehler: 
* Setter ohne Zuweisung (CS0649 hat es gemeldet, ich habe die Warnung übersehen); 
* ThrowIfNull mit Meldung statt Wert aufgerufen – Validierung war wirkungslos; beim Reparieren ##   ThrowIfNullOrEmpty statt ThrowIfNullOrWhiteSpace genommen

# Nächster Schritt: 
* Dublettenprüfung Versichertennummer, README, GitHub Actions

### Tag 2 – 12.09.2026
- Thema: 

    Unit Tests mit xUnit

- Was wurde entwickelt: 

    Testprojekt MedFlow.Tests mit Projektverweis auf MedFlow, sechs Tests für die Validierung im Patient-Konstruktor.

- Was habe ich gelernt: 

    Aufbau eines xUnit-Tests ([Fact], Assert.Throws, Namensschema Methode_Szenario_Erwartung). 

    Ein grüner Build sagt nichts darüber aus, ob das Programm richtig ist.  

- Welche Fehler sind aufgetreten:

    Beim Reparieren der Guard Clauses habe ich ThrowIfNullOrEmpty statt ThrowIfNullOrWhiteSpace genommen. 
 
    Damit war ein Vorname aus reinen Leerzeichen wieder erlaubt – und 
    
    keiner meiner Tests hat es gemerkt, weil keiner diesen Fall abdeckte.

- Wie wurden sie gelöst: 

    Test mit "   " ergänzt, rot laufen lassen, dann die richtige Methode eingesetzt.

- Was kann ich jetzt selbstständig: 

Ein Testprojekt anlegen, verbinden und einfache Tests für Konstruktor-Validierung schreiben und ausführen.

- Nächster Schritt: 

Dublettenprüfung der Versichertennummer.

### Tag 3 – 13.09.2026

- Thema: 

Feature-Branch, erstes LINQ, testgetriebene Entwicklung

- Was wurde entwickelt: 

Branch feature/dubletten-pruefung. 

Prüfung auf bereits vergebene Versichertennummern in der Patientenverwaltung, 

unabhängig von Groß- und Kleinschreibung, inklusive Tests.

- Was habe ich gelernt: 

LINQ-Methode Any mit Lambda-Ausdruck. 

string.Equals mit StringComparison.OrdinalIgnoreCase statt Vergleich über ToUpper. 

Unterschied zwischen ArgumentException (der übergebene Wert ist falsch) und 

InvalidOperationException (der Wert ist in Ordnung, der aktuelle Zustand lässt die Operation nicht zu). 

Assert.Same prüft Referenzgleichheit, Assert.Equal Wertgleichheit.

- Welche Fehler sind aufgetreten: 

Guard Clause mit nameof(patient) statt mit patient aufgerufen – die Prüfung lief ins Leere. 

Danach einen Null-Test geschrieben, der gar nicht fehlschlagen konnte, weil ich nur geprüft habe, 

ob eine Variable null ist, die ich selbst auf null gesetzt hatte.


- Wie wurden sie gelöst: 

ArgumentNullException.ThrowIfNull(patient) eingesetzt, 

den Test mit Assert.Throws und null! umgebaut und anschließend die Gegenprobe gemacht: 

Guard auskommentiert, geprüft dass der Test wirklich rot wird, Guard wieder aktiviert.

- Was kann ich jetzt selbstständig: 

Auf einem Feature-Branch arbeiten, zuerst den Test schreiben und 

dann den Code, und prüfen ob ein Test überhaupt fehlschlagen kann.

- Nächster Schritt: Die Konsole an die neue Regel anpassen.

### Tag 4 – 14.09.2026

- Thema: 

    Verträge ändern, Schichtentrennung, Continuous Integration

- Was wurde entwickelt:

    Anlegen zu TryAnlegen mit bool-Rückgabe umgebaut. 
 
    Konsole so strukturiert, dass ein falsches Datum nur die Datumseingabe wiederholt und
 
    eine doppelte Versichertennummer den Vorgang beendet. Eigene Abfragemethoden für Vorname, Nachname und Geburtsdatum.

- Was habe ich gelernt: 

Für erwartbare Fehlschläge ist ein bool-Rückgabewert passender als eine Exception; 

die .NET-Konvention dafür heißt Try-Muster. 

Eine Exception wird dort gefangen, wo man sinnvoll auf sie reagieren kann, nicht dort wo sie zufällig vorbeikommt.

- Welche Fehler sind aufgetreten: 

Ich habe den Vertrag von Anlegen geändert, die Tests aber nicht angepasst, 

und mit zwei roten Tests gepusht, weil ich vorher kein dotnet test ausgeführt habe. 

Außerdem stand ein Console.WriteLine in der Domänenklasse – im Testlauf 

wurden dadurch Meldungen ausgegeben, die für die Anmeldung gedacht waren.

- Wie wurden sie gelöst: 

Tests auf den neuen Vertrag umgeschrieben (Rückgabewert false und zusätzlich geprüft, dass nichts eingefügt wurde), 

usgabe aus der Domäne entfernt, doppelte Tests zusammengefasst. 

Als dauerhafte Absicherung eine GitHub-Actions-Pipeline eingerichtet, 

damit Build und Tests nicht mehr von meiner Aufmerksamkeit abhängen.


- Was kann ich jetzt selbstständig: 

Erkennen, wann eine Änderung ein Vertrag ist und die Tests deshalb zuerst angepasst werden müssen.


- Nächster Schritt: 

README mit Status-Badge, danach Ticket MF-2 – Namen mit Bindestrich, Apostroph und Leerzeichen zulassen.