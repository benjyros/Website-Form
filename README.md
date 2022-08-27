# Website-Form

My personal website for creating forms.

# Lern-Bericht
Website-Form - Benjamin Peterhans

## Einleitung

Für diesen Portfolioeintrag habe ich mir vorgenommen, eine Webseite zu erstellen, in der ein Formular zu sehen ist. Das Formular soll dann serverseitig kontrolliert werden und dementsprechend bei Fehleingaben eine Fehlermeldung anzeigen. Dabei sollen die Informationen zum Formular zwischengespeichert und sie dann auf einer neuen Seite wiedergeben werden.

## Ziele

Meine Ziele:

- Z1: Ich kann ein eigenes Formular mit HTML erstellen.
- Z2: Ich kann Fehlereingaben im Formular umgehen.

Modulziele:

- LZ 22: Ich kann Formulareingabedaten serverseitig validieren.
- LZ 23: Ich kann Daten aus einem Formular in der Session abrufbar verwalten.

## Beschreibung

Um diese Webseite mit einem Formular programmieren zu können, brauchen wir zuerst einmal ein Programm, mit dem wir den Code aufschreiben können. Ich habe hierfür Visual Studio 2019 benutzt, da hier schon verschiedene Funktionen vorinstalliert sind.
Nach der Erstellung des neuen Projektes wurden grundlegende Elemente ausgeführt (z.B. Controller, Ansichten und Template erstellen). Um die Aufgabe, die ich mir vorgenommen habe, zu erfüllen, habe ich zwei verschiedene Ansichten erstellt: eines für das Formular, das andere für das Dankeschön. Um ein Formular dann in HTML zu erstellen, müssen wir alle Elemente in "<form></form> einsetzen (siehe Code rechts). Beim Absenden des Formulars werden die eingegebenen Werte per "POST" weitergeleitet. Das heisst, man kann die Daten nicht direkt ablesen. Wenn die Methode nicht "POST" wäre, würde man die eingegebenen Daten in der URL lesen können. Und das wollen wir ja nicht.
Jetzt funktioniert das Formular schon: Man kann Daten eingeben und auch versenden. Jedoch wäre hier noch das Problem, dass die Daten nicht auf die Vollständigkeit überprüft werden. Mit der serverseitigen Validierung (clientseitig würde auch gehen) kann man dann auf die Vollständigkeit überprüfen und allenfalls Fehlermeldungen ausgeben. 
Falls sich dann keine Fehlermeldungen mehr ergeben, wird man auf die zweite Ansicht weitergeleitet, bei der der Webseitenbenutzer kurz informiert wird, dass die Daten gespeichert wurden.

Für eine Veranschaulichung habe ich (siehe unten) ein Video, wie die Webseite schlussendlich aussieht, und auch wie sie funktioniert.

### Demo

[![IMAGE ALT TEXT](http://img.youtube.com/vi/nVYdplBjJ1w/0.jpg)](http://www.youtube.com/watch?v=nVYdplBjJ1w "Website-Forms")

## Codeausschnitt

```cshtml

@{
    ViewBag.Title = "Formular";
    ViewBag.LinkHome = "nav-link";
    ViewBag.LinkFormular = "nav-link active";
    Layout = "~/Views/Shared/Template.cshtml";
}

<h2>Kontaktformular</h2>

<form action="/Home/Formular" method="POST">
    <fieldset>
        <div class="form-group">
            <label for="name">Name: *</label>
            <input type="text" class="form-control" id="name" placeholder="Name" name="name" value="@ViewBag.name">
            <small id="infoName" class="form-text text-muted">@ViewBag.errorName</small>
        </div><br />
        <div class="form-group">
            <label for="vorname">Vorname: *</label>
            <input type="text" class="form-control" id="vorname" placeholder="Vorname" name="vorname" value="@ViewBag.vorname">
            <small id="infoVorname" class="form-text text-muted">@ViewBag.errorVorname</small>
        </div><br />
        <div class="form-group">
            <label for="email">Email: *</label>
            <input type="email" class="form-control" id="email" placeholder="Email" name="email" value="@ViewBag.email">
            <small id="infoEmail" class="form-text text-muted">@ViewBag.errorEmail</small>
        </div><br />
        <div class="form-group">
            <label for="betreff">Betreff: *</label>
            <input type="text" class="form-control" id="betreff" placeholder="Betreff" name="betreff" value="@ViewBag.betreff">
            <small id="infoVorname" class="form-text text-muted">@ViewBag.errorBetreff</small>
        </div><br />
        <div class="form-group">
            <label for="meldung">Ihre Meldung: *</label>
            <textarea class="form-control" id=" meldung" rows="5" name="meldung">@ViewBag.meldung</textarea>
            <small id="infoPflicht" class="form-text text-muted">@ViewBag.errorMeldung</small>
        </div>
        <small id="infoPflicht" class="form-text text-muted">* Pflichtfelder</small>
        <br />
        <button type="submit" style="background-color:orangered;border-color:black;" class="btn btn-primary">Absenden</button>
    </fieldset>
</form>
```

## Verifikation

Z1: Wird mit dem eingebettetem Code validiert.

Z2: Wird mit der Video-Demonstration (ab 0:40) validiert.


LZ 22: Wird im Projekt (Zip-Download) unter HomeController.cs von Linie 23 bis 71 validiert.

LZ 23: Wird in der Demonstration (ab 0:55) und dem Programmcode unter HomeController.cs von Linie 64 validiert.

# Reflektion zum Arbeitsprozess

In diesem Auftrag bin ich eigentlich auf keine Probleme gestossen, da ich diesen schon einmal während der Unterrichtsstunde geübt habe. Wenn man hier 1zu1 das Vorgehen darstellt, ist es relativ einfach, sowas zu erstellen. Das Erstellen eines Projektes haben wir schon sehr oft in der Stunde geübt, weshalb dies gar kein Problem mehr ist. Die Controller, Ansichten und Templates sollte man auch auswendig können, was ich auch kann.

Ich könnte aber einige Probleme erläutern, die beim ersten Mal beim Erstellen eines Formulars vorkamen. Zwei spezifische Probleme, die noch relevant sind, waren das Beibehalten der eingegebenen Daten und das Weiterleiten auf die "Dankeschön"-Ansicht.
Das grössere Problem, dem ich begegnet bin, war das neue Laden der Webseite nach dem Absenden des Formulars (mit Fehleingaben). Ich wollte nämlich, dass die Werte, die man vorher eingegeben hatte, noch angezeigt werden. Nun, da ich bei dem ein Problem hatte, funktionierte dies bei mir nicht. Um das Problem zu lösen, musste man lediglich im HTML-Code unter diesem Input einen "value" eingeben. In diesem "value" wurde ein ViewBag, also eine Razor-Syntax, eingefügt, die beim Absenden des Formulars abgespeichert wurde und den Wert wieder in den Input einfügt. Somit wurde schon einmal das erste Problem gelöst.
Mit etwas Internetrecherche konnte ich eine Lösung für das zweite Problem finden: Mit "return RedirectToAction("Ansicht");" wurde dann die zweite Ansicht angezeigt, wenn man keine Fehleingaben machte.

Ansonsten fand ich dieses Modul eigentlich recht angenehm, da es eine gute Auffrischung des ersten IMS-Jahres (Modul 101) war. Ich habe neu gelernt, dass es eine weitere Möglichkeit gibt, Webseiten zu programmieren. Es ist zwar etwas komplexer, aber ich denke, dass das praktische Arbeiten daran noch Spass macht und mit ich etwas Übung dies locker kann.
