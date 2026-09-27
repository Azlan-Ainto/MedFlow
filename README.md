# MedFlow

[![CI](https://github.com/Azlan-Ainto/MedFlow/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Azlan-Ainto/MedFlow/actions/workflows/dotnet.yml)

Praxisverwaltung als Konsolenanwendung – Lern- und Portfolioprojekt für C# und .NET.

MedFlow entsteht schrittweise entlang echter Anforderungen: jede Funktion beginnt als Ticket,
wird testgetrieben umgesetzt und über einen Feature-Branch nach `main` gebracht.

## Features

- **Patienten anlegen** mit Validierung aller Pflichtfelder
- **Namensregeln**, die auch echte Namen zulassen: Buchstaben inklusive Umlauten und Akzenten,
  dazu Leerzeichen, Bindestrich und Apostroph (`Anna-Lena`, `O'Brien`, `van der Berg`, `José`).
  Ein Name muss mindestens einen Buchstaben enthalten.
- **Geburtsdatum** darf nicht in der Zukunft liegen. Eingabeformate: `dd.MM.yyyy` und `dd/MM/yyyy`.
  Ungültige Eingaben werden sofort beim Eintippen abgewiesen – nur das betroffene Feld wird erneut abgefragt.
- **Dublettenprüfung** der Versichertennummer, unabhängig von Groß- und Kleinschreibung
- **Eingaben werden getrimmt**, damit `A123` und `A123 ` nicht als zwei verschiedene Nummern gelten
- **Patientenliste anzeigen**

## Technologien

| Bereich | Einsatz |
|---|---|
| Sprache & Laufzeit | C# 14, .NET 10 (LTS) |
| Entwicklungsumgebung | Visual Studio 2026 |
| Tests | xUnit (`[Fact]`, `[Theory]`/`[InlineData]`) |
| Versionsverwaltung | Git, GitHub, Feature-Branches |
| CI | GitHub Actions – Build und Tests bei jedem Push auf `main` und bei jedem Pull Request |

## Projektstruktur

```
MedFlow/
├── MedFlow.slnx                     Projektmappe
├── MedFlow/                         Konsolenanwendung
│   ├── Patient.cs                   Domäne: Patient samt Validierungsregeln
│   ├── Patientenverwaltung.cs       Domäne: Bestand, Dublettenprüfung
│   └── Program.cs                   Oberfläche: Menü und Eingaben
├── MedFlow.Tests/                   xUnit-Testprojekt
│   ├── PatientTests.cs
│   └── PatientenverwaltungTests.cs
├── .github/workflows/dotnet.yml     CI-Pipeline
├── LEARNING_PROGRESS.md             Entwicklertagebuch
└── README.md
```

Die Domäne kennt keine Konsole: `Patient` und `Patientenverwaltung` melden Fehler über
Exceptions bzw. Rückgabewerte, die Textausgabe findet ausschließlich in `Program.cs` statt.

## Ausführen

```bash
git clone https://github.com/Azlan-Ainto/MedFlow.git
cd MedFlow
dotnet run --project MedFlow
```

Voraussetzung: .NET 10 SDK.

## Tests

```bash
dotnet test
```

Derzeit 32 Tests über Pflichtfeldprüfung, Namensregeln, Geburtsdatum, Trimmen und Dublettenprüfung.

## Beispielverwendung

```
=== MedFlow ===

1) Patient anlegen
2) Alle Patienten anzeigen
0) Beenden

Auswahl: 1
Geben Sie Vorname ein: Anna-Lena
Geben Sie Nachname ein: O'Brien
Geben Sie Versichertennummer ein: A123456789
Geben Sie Geburtsdatum ein: 14.03.1985
Patient wurde erfolgreich angelegt.
```

## Projektstatus

In aktiver Entwicklung.

Die Patienten werden bisher nur im Arbeitsspeicher gehalten und sind nach dem Beenden der
Anwendung verloren. Der nächste Entwicklungsschritt ist die Persistenz mit SQL und
Entity Framework Core.

## Commit-Konventionen

```
feat:     neue Funktion
fix:      Fehlerbehebung
test:     Tests hinzugefügt oder geändert
refactor: Umbau ohne Verhaltensänderung
docs:     Dokumentation
chore:    Projektpflege, Konfiguration
ci:       Build- und Pipeline-Änderungen
```

Beispiel: `feat: Pruefung auf doppelte Versichertennummern`

## Lernziele

Das Projekt dient dem Aufbau eines vollständigen Entwicklungsprozesses, nicht nur dem Schreiben
von C#-Code:

- objektorientierte Modellierung einer Fachdomäne, Kapselung, Trennung von Domäne und Oberfläche
- Validierung und Ausnahmebehandlung: Guard Clauses, Wahl des Exception-Typs, `Try`-Muster
- testgetriebene Entwicklung mit xUnit, inklusive der Gegenprobe, dass ein Test fehlschlagen kann
- Git und GitHub im Alltag: Branches, Commits, Pull Requests, Releases
- Continuous Integration mit GitHub Actions
- schrittweise Erweiterung zu Datenbank, REST-API und Web-Oberfläche
