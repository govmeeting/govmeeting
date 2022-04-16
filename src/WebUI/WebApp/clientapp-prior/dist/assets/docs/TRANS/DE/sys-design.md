<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle"> Design </mat-card-title>
<markdown ngPreserveWhitespaces>

<p> Die folgenden Diagramme zeigen die Interaktion zwischen Softwarekomponenten. </p>

<ul>
<li>
<p> ClientApp ist eine Angular Typescript-Einzelseitenanwendung, die im Browser ausgeführt wird. Es bietet die Benutzeroberfläche. </p>
</li>
<li>
<p> WebApp ist eine <a href="https://github.com/aspnet/home">Asp.Net Core</a> C# -Anwendung, die auf dem Server ausgeführt wird. Es reagiert auf WebApi-Aufrufe. </p>
</li>
<li>
<p> WorkflowApp ist eine <a href="https://github.com/dotnet/core">DotNet Core</a> C# -Anwendung, die auf dem Server ausgeführt wird. Es führt eine Stapelverarbeitung von Aufzeichnungen und Transkripten durch. Es kann auch in eine Bibliothek konvertiert werden, die als Teil des WebApp-Prozesses ausgeführt wird. </p>
</li>
<li>
<p> Die anderen Serverkomponenten sind DotNet Core C# -Bibliotheken. Sie werden sowohl von WebApp als auch von WorkflowApp verwendet. </p>
</li>
</ul><hr /><h2> System-Design </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

<p> Die Komponenten im obigen Diagramm sind: </p>

<table style="width:100%">
<tr><th colspan="2"> Anwendungen </th></tr>
<tr><td> ClientApp </td><td> Angular SPA </td></tr>
<tr><td> Web-App </td><td> Asp.Net-Webserverprozess </td></tr>
<tr><td> WorkflowApp </td><td> Workflow-Server-Steuerungsprozess </td></tr>
<tr><th colspan="2"> Bibliotheken </th></tr>
<tr><td> GetOnlineFiles </td><td> Rufen Sie Online-Transkripte und -Aufzeichnungen ab </td></tr>
<tr><td> ProcessRecording </td><td> Audio extrahieren und transkribieren. Erstellen Sie Arbeitssegmente. </td></tr>
<tr><td> ProcessTranscript </td><td> Transformieren Sie rohe Transkripte </td></tr>
<tr><td> LoadDatabase </td><td> Füllen Sie die Datenbank mit Daten aus dem fertigen Transkript </td></tr>
<tr><td> Online-Zugang </td><td> Routinen zum Abrufen von Dateien von Remotestandorten </td></tr>
<tr><td> GoogleCloudAccess </td><td> Routinen für den Zugriff auf Google Cloud-Dienste </td></tr>
<tr><td> FileDataRepositories </td><td> Speichern und Abrufen von JSON-Arbeitsdateidaten </td></tr>
<tr><td> DatabaseRepositories </td><td> Speichern und Abrufen von Modelldaten aus der Datenbank </td></tr>
<tr><td> DatabaseAccess </td><td> Zugriff auf die Datenbank mit Entity Framework </td></tr>
</table>
<hr /><h2> ClientApp Design </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

<p> Die Struktur der ClientApp lässt sich am besten anhand ihrer Angular Component-Struktur veranschaulichen </p>

<table style="width:100%">
<tr><th colspan="2"> App-Komponenten </th></tr>
<tr><td> Header </td><td> Header </td></tr>
<tr><td> Sidenav </td><td> Sidebar-Navigation </td></tr>
<tr><td> Instrumententafel </td><td> Container für Dashboard-Komponenten </td></tr>
<tr><td> Dokumentation </td><td> Container für Dokumentationsseiten </td></tr>
<tr><th colspan="2"> Dashboard-Komponenten </th></tr>
<tr><td> Fixasr </td><td> Korrigieren Sie den Text für die automatische Spracherkennung </td></tr>
<tr><td> Tags hinzufügen </td><td> Hinzufügen von Tags zu Transkripten </td></tr>
<tr><td> ViewMeeting </td><td> Vollständige Transkripte anzeigen </td></tr>
<tr><td> Probleme </td><td> Informationen zu Problemen anzeigen </td></tr>
<tr><td> Warnungen </td><td> Anzeigen und Festlegen von Informationen zu Warnungen </td></tr>
<tr><td> Beamte </td><td> Informationen zu Beamten anzeigen </td></tr>
<tr><td> (Andere)) </td><td> Andere zu implementierende Komponenten </td></tr>
<tr><th colspan="2"> Dienstleistungen </th></tr>
<tr><td> VirtualMeeting </td><td> Führen Sie ein virtuelles Meeting aus </td></tr>
<tr><td> Plaudern </td><td> Benutzer-Chat-Komponente </td></tr>
</table>
<hr /><h2> WebApp-Design </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

<p> Jede der Web-APIs ist klein und ruft die Repositorys auf, um Daten aus der Datenbank oder dem Dateisystem abzulegen oder abzurufen. </p>

<table style="width:100%">
<tr><th colspan="2"> Controller </th></tr>
<tr><td> Fixasr </td><td> Speichern und erhalten Sie die neueste Version des Transkripts, das Korrektur gelesen wird. </td></tr>
<tr><td> Tags hinzufügen </td><td> Speichern Sie die neueste Version des zu markierenden Transkripts und erhalten Sie sie. </td></tr>
<tr><td> Viewmeeting </td><td> Holen Sie sich das letzte fertiggestellte Trnascript. </td></tr>
<tr><td> Govbodies </td><td> Speichern und registrieren Sie registrierte Regierungsdaten. </td></tr>
<tr><td> Treffen </td><td> Speichern und Abrufen von Besprechungsinformationen. </td></tr>
<tr><td> Video </td><td> Holen Sie sich ein Video von einem Meeting. </td></tr>
<tr><td> Konto </td><td> Benutzerregistrierung und Login verarbeiten. </td></tr>
<tr><td> Verwalten </td><td> Benutzer können ihre Profile verwalten. </td></tr>
<tr><td> Administrator </td><td> Der Administrator kann Benutzer, Richtlinien und Ansprüche verwalten </td></tr>
<tr><th colspan="2"> Dienstleistungen </th></tr>
<tr><td> Email </td><td> Behandeln Sie die Bestätigung der Registrierungs-E-Mail. </td></tr>
<tr><td> Botschaft </td><td> Registrierungsbestätigung per SMS bearbeiten. </td></tr>
</table>
<hr /><h2> WorkflowApp-Design </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

<p> Der Status des Workflows für eine bestimmte Besprechung wird in der Besprechungsaufzeichnung in der Datenbank gespeichert. Jede der Workflow-Komponenten arbeitet unabhängig. Sie werden jeweils nacheinander aufgerufen, um nach verfügbaren Arbeiten zu suchen. Jede Komponente fragt die Datenbank nach Besprechungen ab, die ihren Kriterien für verfügbare Arbeit entsprechen. Wenn Arbeit gefunden wird, führen sie diese aus und aktualisieren den Status des Meetings in der Datenbank. </p>

<p> Um ein robustes System aufzubauen, das sich von Fehlern erholen lässt, müssen wir Schritte im Workflow als "Transaktionen" behandeln. Eine Transaktion wird entweder vollständig oder gar nicht abgeschlossen. Wenn während eines Verarbeitungsschritts nicht behebbare Fehler auftreten, wird der Status für diese Besprechung auf den letzten gültigen Status zurückgesetzt. Der Code implementiert derzeit keine Transaktionen. (Gitub-Problem folgt) </p>

<p> Der Pseudocode für die Komponenten ist unten angegeben </p>

<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Für alle staatlichen Stellen im System </li>
<ul>
<li> Überprüfen Sie die Zeitpläne für die abzurufenden Besprechungen </li>
<li> Rufen Sie entweder die Aufnahme- oder die Transkriptionsdatei ab </li>
<li> Legen Sie die Datei im Ordner Datendateien \ Empfangen ab </li>
</ul>
<li> Dateien können auch per Benutzer-Upload in den Ordner "Empfangen" gestellt werden. </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li> Für Dateien in Datendateien \ Empfangen und Datenbankdatensatz existiert nicht: </li>
<ul>
<li> Bestimmen Sie den Dateityp </li>
<li> Datenbankdatensatz erstellen </li>
<li> Status setzen = empfangen, genehmigt = falsch </li>
<li> Manager-Nachricht (en) senden: "Erhalten" </li>
</ul>
</ul>
<li> TranscribeRecordings </li>
<ul>
<li> Für Aufnahmen mit Sourcetype = Aufnahme, Status = empfangen, genehmigt = wahr </li>
<ul>
<li> Arbeitsordner erstellen </li>
<li> set status = transkribieren, genehmigt = falsch </li>
<li> Aufnahme transkribieren </li>
<li> Status setzen = transkribiert, genehmigt = falsch </li>
<li> Manager-Nachricht (en) senden: "Transkribiert" </li>
</ul>
</ul>
<li> ProcessTranscripts </li>
<ul>
<li> Für Transkripte mit Sourcetype = Transkript, Status = empfangen, genehmigt = wahr </li>
<ul>
<li> Arbeitsordner erstellen </li>
<li> Status setzen = Verarbeitung, genehmigt = falsch </li>
<li> Transkript verarbeiten </li>
<li> Status setzen = verarbeitet, genehmigt = falsch </li>
<li> Manager-Nachricht (en) senden: "Verarbeitet" </li>
</ul>
</ul>
<li> Korrekturlesen </li>
<ul>
<li> Für Aufnahmen mit Status = transkribiert / genehmigt = wahr </li>
<ul>
<li> Arbeitsordner erstellen </li>
<li> set status = Korrekturlesen, genehmigt = falsch </li>
<li> Das manuelle Korrekturlesen findet nun statt </li>
</ul>
<li> Für Aufnahmen mit Status = Korrekturlesen </li>
<ul>
<li> Überprüfen Sie, ob das Korrekturlesen abgeschlossen ist. Wenn ja: </li>
<li> set status = Korrekturlesen, genehmigt = falsch </li>
<li> Manager-Nachricht senden: "Korrekturlesen" </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li> Für Aufnahmen mit Status = Korrektur gelesen, genehmigt = wahr ODER für Transkripte mit Status = verarbeitet, genehmigt = wahr </li>
<ul>
<li> Arbeitsordner erstellen </li>
<li> Setze Status = Tagging, Genehmigt = Falsch </li>
<li> Die manuelle Kennzeichnung erfolgt nun </li>
</ul>
</ul>
<ul>
<li> Für Transkripte mit Status = Tagging </li>
<ul>
<li> Überprüfen Sie, ob die Kennzeichnung vollständig angezeigt wird. Wenn ja: </li>
<li> set status = markiert, genehmigt = falsch </li>
<li> Manager-Nachricht (en) senden: "Tagged" </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Für Besprechungen mit Status = markiert, genehmigt = wahr 
<ul>
<li> Status setzen = Laden, genehmigt = falsch </li>
<li> Laden Sie den Inhalt der Besprechung in die Datenbank </li>
<li> set status = geladen, genehmigt = falsch </li>
<li> Manager-Nachricht (en) senden: "Geladen" </li>
</ul>
</ul>
</ul><hr /><h2> Benutzergeheimnisse </h2>
<p> Wenn Sie das Govmeeting-Repository von Github klonen, erhalten Sie alles außer dem Ordner "SECRETS". Dieser Ordner befindet sich außerhalb des Repositorys. Es enthält die folgenden "geheimen" Informationen: </p>

<ul>
<li> ClientId und ClientSecret für den externen Autorisierungsdienst von Google. </li>
<li> SiteKey und Secret für den Google ReCaptcha-Dienst. </li>
<li> Anmeldeinformationen für die Google Cloud Platform. </li>
<li> Datenbankverbindungszeichenfolge. </li>
<li> Administrator-Benutzername und Passwort. </li>
</ul>
<p> Der Ordner SECRETS kann vier Dateien enthalten. </p>

<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> appsettings.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul>
<p> TranscribeAudio.json enthält die Anmeldeinformationen der Google Cloud Platform. Jede der anderen drei Dateien kann Einstellungen für jedes der anderen Geheimnisse enthalten. appsettings.Production.json sollte alle Einstellungen für die Produktion enthalten. Unabhängig von den Einstellungen in dieser Datei werden die Einstellungen in Server / WebApp / app.settings.json überschrieben. Diese Datei ist im Repository enthalten. </p>

<p> Wenn Ihr lokaler Computer Zugriff auf die Google-Dienste haben soll, müssen Sie einen lokalen Ordner "../SECRETS" in Bezug auf den Speicherort des Repositorys erstellen. Anschließend können Sie beispielsweise eine Datei "appsettings.Development" hinzufügen. json "dazu, das Schlüssel enthält, die Sie von Google erhalten. Siehe: <a href="home#google-api-keys">Google API-Schlüssel</a> </p>
<hr /><h1> Dokumentation </h1>
<p> Ursprünglich wurde diese Dokumentation auf den Github-Wiki-Seiten aufbewahrt. Es wurde jedoch aus zwei Gründen beschlossen, die Seiten in das Hauptprojekt selbst zu verschieben: </p>

<ul>
<li> Sie können keine Pull-Anfrage für Änderungen auf Github-Wiki-Seiten stellen. Dies macht es für Mitglieder der Community schwierig, die Dokumentation zu ändern. </li>
<li> Die Dokumentation bleibt mit größerer Wahrscheinlichkeit mit dem Code synchron, wenn sie sich mit dem Code im selben Repository befindet. Ein einzelner PR für Codeänderungen kann die damit verbundenen Dokumentationsänderungen enthalten. </li>
</ul>
<p> Die Dokumentation ist in Markdown geschrieben und befindet sich in Frontend / ClientApp / src / app / assets / docs. </p>

</markdown>

<p> &lt;/ mat-card&gt; </p>
