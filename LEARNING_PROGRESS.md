# Lernfortschritt – MedFlow

## Projekt
MedFlow – Praxisverwaltung als Konsolenanwendung

## Technologie
C# / .NET 10 / xUnit / Git / GitHub Actions

## Aktueller Stand
Patienten anlegen und auflisten mit vollständiger Validierung und Dublettenprüfung,
32 grüne Unit Tests, CI-Pipeline auf GitHub Actions. Daten liegen bisher nur im
Arbeitsspeicher – Persistenz ist der nächste Schritt (Ticket MF-3).

## Lernfortschritt

### Tag 1 – 11.09.2026
- Thema:

    Projektaufbau, Klassen, Validierung, Git, erste Unit Tests

- Was wurde entwickelt:

    Konsolenprojekt MedFlow mit .NET 10, Klassen Patient und Patientenverwaltung,
    Konsolenmenü zum Anlegen und Auflisten, Git-Repository und GitHub-Repository von Hand aufgesetzt.

- Was habe ich gelernt:

    Was ein Repository, ein Commit und .gitignore sind, und warum bin/ und obj/ nicht in die History gehören.

    Klasse und Objekt, Eigenschaften, DateOnly statt DateTime für ein Geburtsdatum.

    Nullable Reference Types: Console.ReadLine() liefert string? und nicht string.

- Welche Fehler sind aufgetreten:

    Der Setter von Geburtsdatum hat den Wert geprüft, aber nicht zugewiesen – die Ausgabe zeigte 01.01.0001.
    Der Compiler hatte es mit CS0649 gemeldet, ich hatte die Warnung übersehen.

    ArgumentNullException.ThrowIfNull mit der Fehlermeldung als erstem Argument aufgerufen
    statt mit dem zu prüfenden Wert – die Validierung war dadurch wirkungslos.

- Wie wurden sie gelöst:

    Warnung gelesen und die fehlende Zuweisung ergänzt. Guard Clauses auf den Wert statt auf den
    Meldungstext umgestellt und die Wirkung von Hand mit drei Testfällen nachgewiesen.

- Was kann ich jetzt selbstständig:

    Ein .NET-Projekt anlegen, mit Git versionieren, auf GitHub pushen und eine Klasse mit
    Eigenschaften und Validierung im Konstruktor schreiben.

- Nächster Schritt:

    Dublettenprüfung der Versichertennummer, README, GitHub Actions.

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

### Tag 5 – 26.09.2026
- Thema:

    Wiedereinstieg nach zwölf Tagen Pause, Parameter von Ausnahmen, Testabdeckung

- Was wurde entwickelt:

    Prüfung des Geburtsdatums auf eine Stelle zusammengeführt: Geburtsdatum ist jetzt eine
    gewöhnliche Eigenschaft, die Regel steht im Konstruktor neben den drei anderen.

    Versichertennummer wird getrimmt.

    Tests ergänzt für die Zeichenregel beim Nachnamen, für das Trimmen aller Felder und für
    Namen mit Umlaut und Akzent. Von 13 auf 32 Tests.

- Was habe ich gelernt:

    ArgumentException nimmt (message, paramName), ArgumentOutOfRangeException nimmt
    (paramName, message) – die Reihenfolge ist umgekehrt. Bei zwei gleichartigen Parametern
    hilft der Compiler nicht; benannte Argumente machen die Absicht sichtbar.

    Ein Test, der nur den Typ der Exception prüft, bemerkt eine vertauschte Meldung nicht.
    Eine Zusicherung auf ParamName deckt sie auf.

    CI prüft nur, was gepusht wurde. Was im Arbeitsverzeichnis liegt, sieht kein Automat –
    die erste Verteidigungslinie ist dotnet test vor dem Commit.

- Welche Fehler sind aufgetreten:

    Zwölf Tage Arbeit lagen unversioniert im Arbeitsverzeichnis, auf einem Branch ohne einen
    einzigen Commit.

    Die Prüfung des Geburtsdatums stand doppelt – im Konstruktor und im Setter – und die
    fehlerhafte Fassung mit vertauschten Argumenten lief zuerst.

    Im Setter wurde der Rückgabewert von IstGueltigesGeburtsdatum ignoriert. Die Zeile sah aus
    wie eine Prüfung und tat nichts; der Compiler warnt dabei nicht.

- Wie wurden sie gelöst:

    Zusicherung auf ParamName ergänzt, Test lief rot, dann die Argumentreihenfolge korrigiert.
    Die doppelte Prüfung auf eine Stelle reduziert. Arbeitsverzeichnis in mehreren sinnvollen
    Commits gesichert.

- Was kann ich jetzt selbstständig:

    Nach einer Pause mit git status und git diff den eigenen Stand lesen, bevor ich weiterarbeite.
    Erkennen, wann eine Regel doppelt im Code steht.

- Nächster Schritt:

    Aufräumen, README ausfüllen, Release v0.1.0.

### Tag 6 – 27.09.2026
- Thema:

    Lesbarkeit, Konventionen, Arbeiten auf einem Feature-Branch

- Was wurde entwickelt:

    Branch feature/geburtsdatum-validieren angelegt und auf GitHub gepusht.

    #region-Blöcke aus Patient.cs entfernt, geschweifte Klammern bei allen Guard Clauses ergänzt,
    using static System.ArgumentException entfernt, Testnamen in beiden Testdateien vereinheitlicht.

    Vorprüfung des Geburtsdatums in GeburtsdatumFordern: ein Datum in der Zukunft wird bereits
    bei der Eingabe abgewiesen, der Benutzer korrigiert nur dieses eine Feld statt den ganzen Vorgang
    zu verlieren.

    README.md und LEARNING_PROGRESS.md ausgefüllt.

- Was habe ich gelernt:

    Ein if ohne geschweifte Klammern nimmt genau eine Anweisung mit. Eine später eingefügte Zeile
    fällt still heraus, der Einzug behauptet das Gegenteil, der Compiler schweigt.

    #region versteckt Code und ist durch die Navigation der Entwicklungsumgebung überholt.

    Der Wert einer Namenskonvention liegt in ihrer Ausnahmslosigkeit.

    Ein Branch ist nur eine Datei mit einem Commit-Hash. Lokaler Branch, origin/-Zeiger und der
    Branch auf GitHub sind drei getrennte Zeiger.

- Welche Fehler sind aufgetreten:

    Branch und Repository verwechselt: ich habe einen Branch angelegt, aber von einem neuen
    Repository gesprochen.

    Zwei Testnamen folgen der neuen Konvention noch nicht.

- Wie wurden sie gelöst:

    Begriffe geklärt und die Zeiger im Repository nachgesehen. Die restlichen Testnamen stehen
    als kleine Aufgabe an.

- Was kann ich jetzt selbstständig:

    Einen Feature-Branch anlegen, darauf committen und mit git push -u origin <branch>
    veröffentlichen; lokale und entfernte Zeiger unterscheiden.

- Nächster Schritt:

    Pull Request für feature/geburtsdatum-validieren, Merge nach main, Release v0.1.0,
    danach Ticket MF-3 – Persistenz mit SQL und Entity Framework Core.
