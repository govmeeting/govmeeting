
<p><a name="Contents"></a></p>
<h1> Inhalt </h1>
<ul>
<li> <a href="about?id=setup#InstallTools">Installieren Sie Tools und klonen Sie das Repository</a> </li>
<li> <a href="about?id=setup#DevelopVsCode">Entwickeln Sie mit VsCode</a> </li>
<li> <a href="about?id=setup#DevelopVS">Entwickeln Sie mit Visual Studio</a> </li>
<li> <a href="about?id=setup#DevelopOther">Entwickeln Sie auf anderen Plattformen</a> </li>
<li> <a href="about?id=setup#Database">Datenbank</a> </li>
<li> <a href="about?id=setup#GoogleCloud">Google Cloud Platform-Konto</a> </li>
<li> <a href="about?id=setup#GoogleApi">Google API-Schlüssel</a> </li>
</ul>
<p> Diese Dokumentationsseiten finden Sie in FrontEnd / ClientApp / src / app / assets / docs. Bitte nehmen Sie dort Korrekturen vor und stellen Sie eine <a href="https://github.com/govmeeting/govmeeting">Pull-Anfrage auf Gitub.</a> </p>
<hr />
<p><a name="InstallTools"></a></p>
<h1> Installieren Sie Tools und klonen Sie das Repository <br/></h1>
<p> <a href="about?id=setup#Contents">[Inhalt]</a> </p>

<ul>
<li> Git installieren. <a href="https://gitforwindows.org">Git für Windows</a> , <a href="https://git-scm.com/download/mac">Git für Mac</a> </li>
<li> Installieren Sie <a href="https://nodejs.org/en/download/">Node.js.</a> </li>
<li> Installieren Sie das <a href="https://dotnet.microsoft.com/download">.Net Core SDK.</a> </li>
<li> "Fork" das Projekt auf Github </li>
<li> Klonen Sie das Projekt lokal </li>
<li> Erstellen Sie einen Geschwisterordner für das geklonte Repository mit dem Namen "SECRETS". </li>
</ul>
<p> Der Ordner "SECRETS" enthält Schlüssel und Kennwörter, die nicht im öffentlichen Repository gespeichert sind. Diese werden benötigt, um Google API-Dienste auszuführen. </p>
<hr />
<p><a name="DevelopVsCode"></a></p>
<h1> Entwickeln Sie mit VsCode <br/></h1>
<p> <a href="about?id=setup#Contents">[Inhalt]</a> </p>
<h2> Installieren Sie VsCode </h2>
<ul>
<li> Installieren Sie <a href="https://code.visualstudio.com/download">Visual Studio Code</a> und starten Sie es. </li>
<li> Öffnen Sie die Erweiterungen auf der linken Seite und installieren Sie: 
<ul>
<li> "Debugger for Chrome" von Microsoft </li>
<li> "C
# für Visual Studio Code" von Microsoft </li>
<li> "SQL Server (mssql)" von Microsoft </li>
<li> "Todo Tree" von Gruntfuggly - zeigt TODO-Zeilen im Code (optional) </li>
<li> "Powershell" von Microsoft - zum Debuggen von Powershell-Build-Skripten (optional) </li>
</ul></li>
</ul><h2> Debuggen / Ausführen von ClientApp & WebApp </h2>
<ul>
<li> Öffnen Sie den Govmeeting-Ordner in VsCode </li>
<li> Öffnen Sie einen Terminalbereich in VsCode </li>
<li> cd FrontEnd / ClientApp </li>
<li> npm installieren </li>
<li> npm starten </li>
<li> Legen Sie im Debug-Bereich die Startkonfiguration auf "WebApp & ClientApp-W" fest. </li>
<li> Drücken Sie F5 (Debug) oder Strg-F5 (ohne Debugging ausführen). </li>
</ul>
<p> Die ClientApp wird in einem Browser geöffnet. </p>

<ul>
<li> Klicken Sie auf einen der Menüpunkte "Info", um die Dokumentation anzuzeigen. </li>
<li> Klicken Sie auf den Standortmenüpunkt "Boothbay Harbor". Sie sehen, dass das Dashboard für diesen Speicherort geöffnet ist. </li>
</ul>
<p> So überprüfen Sie, ob ClientApp die WebApp-API aufruft, um Daten abzurufen. </p>

<ul>
<li> Klicken Sie auf "Korrekturlesen". Sie sehen einen Videobereich und transkribierten Text. Klicken Sie auf die Schaltfläche zur Videowiedergabe. </li>
<li> Klicken Sie auf "Tags zum Transkript hinzufügen". Sie sehen eine Abschrift eines Meetings, das markiert werden soll. </li>
<li> Klicken Sie auf "Letzte Besprechung anzeigen". Sie sehen ein fertiges Transkript zur Ansicht. </li>
</ul>
<p> Die meisten anderen Dashboard-Karten rufen WebApp nicht auf, sondern geben Testdaten zurück. </p>

<p> ClientApp wird vom Webpack-Dev-Server bereitgestellt, der mit "npm start" gestartet wurde. WebApp verwendet den in Asp.Net Core enthaltenen Kestrel-Server. Der Kestrel-Server antwortet auf Web-API-Aufrufe. Interne ClientApp-Anforderungen werden jedoch an den Webpack-Dev-Server weitergeleitet. </p>
<h2> Debuggen / Ausführen von ClientApp eigenständig </h2>
<ul>
<li> Ändern Sie in app.module.ts "isAspServerRunning" von "true" in "false". </li>
<li> npm starten </li>
<li> Legen Sie im Debug-Bereich die Startkonfiguration auf "ClientApp" fest. </li>
<li> Drücken Sie F5 (Debug) oder Strg-F5 (ohne Debugging ausführen). </li>
</ul>
<p> Wenn "isAspServerRunning" auf "false" gesetzt ist, werden Stub-Services verwendet, anstatt die WebApp-API aufzurufen. Dies ist nützlich, wenn wir nur Code in ClientApp ändern. </p>
<h2> Debuggen / Ausführen von WorkflowApp </h2>
<ul>
<li> Legen Sie im Debug-Bereich die Startkonfiguration auf "WorkflowApp" fest. </li>
<li> Drücken Sie F5 (Debug) oder Strg-F5 (ohne Debugging ausführen). </li>
</ul>
<p> Wenn die WorkflowApp gestartet wird: </p>

<ul>
<li> Kopiert einige Testdateien in den Ordner Datafles / RECEIVED: eine Transkriptions-PDF-Datei und eine MP4-Aufzeichnungsdatei. </li>
<li> Verarbeitet die Transkriptions-PDF-Datei und erstellt eine JSON-Datei, die zum Taggen bereit ist. </li>
<li> Verarbeiten Sie die MP4-Aufzeichnungsdatei, indem Sie sie in der Cloud transkribieren, und erstellen Sie eine JSON-Datei, die zum Korrekturlesen bereit ist. </li>
</ul>
<p> Die Ergebnisse finden Sie unter Datendateien / VERARBEITUNG. Sie müssen jedoch zuerst ein <a href="about?id=setup#GoogleCloud">Google Cloud-Konto einrichten</a> , damit die Aufzeichnung transkribiert werden kann. </p>
<hr />
<p><a name="DevelopVS"></a></p>
<h1> Entwickeln Sie mit Visual Studio <br/></h1>
<p> <a href="about?id=setup#Contents">[Inhalt]</a> </p>

<ul>
<li> Installieren Sie die kostenlose <a href="https://visualstudio.microsoft.com/free-developer-offers/">Visual Studio Community Edition.</a> </li>
<li> Wählen Sie während der Installation sowohl die Workloads "ASP.NET" als auch ".NET Desktop" aus. </li>
<li> Erweiterungen installieren: (alle von Mads Kristensen) 
<ul>
<li> "NPM Task Runner" </li>
<li> "Command Task Runner" </li>
<li> "Markdown Editor" </li>
</ul></li>
<li> Öffnen Sie die Lösungsdatei "govmeeting.sln" </li>
</ul><h2> Debuggen / Ausführen von ClientApp & WebApp </h2>
<ul>
<li> Im Task Runner Explorer (ClientApp): 
<ul>
<li> Führen Sie "install" aus. </li>
<li> Führen Sie "Start" aus </li>
</ul></li>
<li> Startprojekt auf "WebApp" setzen </li>
<li> Drücken Sie F5 (Debug) oder Strg-F5 (ohne Debugging ausführen). </li>
<li> Die WebApp wird ausgeführt und ein Browser mit der ClientApp wird geöffnet. </li>
</ul>
<p> ANMERKUNG: Beim Festlegen von Haltepunkten in der Angular ClientApp in Visual Studio ist ein Problem aufgetreten. Siehe: <a href="https://github.com/govmeeting/govmeeting/issues/80">Github-Ausgabe Nr. 80</a> </p>
<h2> Debuggen Sie WorkflowApp </h2>
<ul>
<li> Öffnen Sie das Debug-Panel. </li>
<li> Startprojekt auf "WorkflowApp" setzen </li>
<li> Drücken Sie F5 (Debug) oder Strg-F5 (ohne Debugging ausführen). </li>
</ul>
<p> Hinweis: Siehe Hinweise zu WorkflowApp unter "Visual Studio Code". </p>
<hr />
<p><a name="DevelopOther"></a></p>
<h1> Entwickeln Sie auf anderen Plattformen <br/></h1>
<p> <a href="about?id=setup#Contents">[Inhalt]</a> </p>

<p> Setzen Sie in Ihrem Profil die Umgebungsvariable ASPNETCORE_ENVIRONMENT auf "Entwicklung". Dies wird von WebApp und WorkflowApp verwendet. </p>
<h2> Erstellen und Ausführen von ClientApp </h2>
<p> Ausführen: </p>

<ul>
<li> CD-Frontend / ClientApp </li>
<li> npm installieren </li>
<li> npm starten </li>
</ul>
<p> Gehen Sie in Ihrem Browser zu localhost: 4200. Die Client-App wird geladen. Einige Funktionen funktionieren erst, wenn WebApp ausgeführt wird. </p>
<h2> Erstellen und Ausführen von WebApp mit ClientApp </h2>
<p> Ausführen: </p>

<ul>
<li> (oben ausführen: "ClientApp erstellen und starten") </li>
<li> cd ../../Backend/WebApp </li>
<li> dotnet build webapp.csproj </li>
<li> dotnet run bin / debug / dotnet2.2 / webapp.dll </li>
</ul>
<p> Gehen Sie in Ihrem Browser zu localhost: 5000. Die Client-App wird geladen. </p>
<h2> Erstellen und Ausführen von ClientApp eigenständig </h2>
<ul>
<li> Ändern Sie in app.module.ts "isAspServerRunning" von "true" in "false". </li>
<li> (oben ausführen: "ClientApp erstellen und starten") </li>
</ul><h2> Erstellen und Ausführen von WorkflowApp </h2>
<p> Ausführen: </p>

<ul>
<li> cd Backend / WorkflowApp </li>
<li> dotnet build workflowapp.csproj </li>
<li> dotnet run bin / debug / dotnet2.0 / workflowapp.dll </li>
</ul>
<p> Hinweis: Siehe Hinweise zu WorkflowApp unter "Visual Studio Code". </p>
<!-- END OF README SECTION --><hr />
<p><a name="Database"></a></p>
<h1> Datenbank <br/></h1>
<p> <a href="about?id=setup#Contents">[Inhalt]</a> </p>

<p> Möglicherweise müssen Sie die Datenbank nicht installieren und einrichten, um die Entwicklung durchzuführen. Es gibt Teststubs, die das Aufrufen der Datenbank ersetzen. Siehe "Test Stubs" weiter unten. </p>
<h2> Provider installieren </h2>
<p> Wenn Sie Visual Studio oder Visual Studio Code verwenden, ist der SQL Server Express LocalDb-Anbieter bereits installiert. Andernfalls führen Sie unten "Installation des LocalDb-Anbieters" durch. </p>
<h3> Installation des LocalDb-Providers </h3>
<p> Gehen Sie zu <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">SQL Server Express.</a> Laden Sie für Windows die Spezialversion "Express" von SQL Server herunter. Wählen Sie während der Installation "Benutzerdefiniert" und dann "LocalDb". </p>

<p> LocalDb ist auch für MacOs und Linux verfügbar. Wenn Sie es für eine der Plattformen installieren, aktualisieren Sie dieses Dokument mit den Schritten und führen Sie eine Pull-Anforderung durch. </p>
<h3> Andere Anbieter </h3>
<p> Neben LocalSb unterstützt EF Core <a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli">andere Anbieter,</a> die Sie für die Entwicklung verwenden können, einschließlich SqlLite. Sie müssen das DbContext-Setup in startup.cs und die Verbindungszeichenfolge in appsettings.json ändern. </p>
<h2> Datenbankschema erstellen </h2>
<p> Die Datenbank wird über die Funktion "Code first" von Entity Framework Core erstellt. Es untersucht die C# -Klassen im Datenmodell und erstellt automatisch alle Tabellen und Beziehungen. Es gibt zwei Schritte: (1) Erstellen Sie den "Migrations" -Code für das Update und (2) führen Sie das Update aus. </p>

<ul>
<li> CD-Backend / WebApp </li>
<li> dotnet ef migrations fügt das erste --project .. \ Database \ DatabaseAccess_Lib hinzu </li>
<li> dotnet ef database update --project .. \ Database \ DatabaseAccess_Lib </li>
</ul><h2> Durchsuchen Sie die erstellte Datenbank </h2><h3> In VsCode </h3>
<p> Fügen Sie Ihrer Benutzereinstellung.json in VsCode Folgendes hinzu: </p>
<pre> <code> "mssql.connections": [ { "server": "(localdb)\\mssqllocaldb", "database": "Govmeeting", "authenticationType": "Integrated", "profileName": "GMProfile", "password": "" } ],</code> </pre>
<ul>
<li> Drücken Sie Strg-Alt-D oder das SQL Server-Symbol am linken Rand. </li>
<li> Öffnen Sie die GMProfile-Verbindung, um Datenbankobjekte anzuzeigen und damit zu arbeiten. </li>
<li> Öffnen Sie "Tabellen". Sie sollten alle Tabellen sehen, die beim Erstellen des obigen Schemas erstellt wurden. Dies umfasst die AspNetxxxx-Tabellen für die Autorisierung und die Tabellen für das Govmeeting-Datenmodell. </li>
</ul><h3> In Visual Studio </h3>
<ul>
<li> Gehen Sie zum Menüpunkt: Ansicht -&gt; SQL Server-Objekt-Explorer. </li>
<li> Erweitern Sie SQL Server -&gt; (localdb) \ MSSQLLocalDb -&gt; Datenbanken -&gt; Govmeeting </li>
<li> Öffnen Sie "Tabellen". Sie sollten alle Tabellen sehen, die beim Erstellen des obigen Schemas erstellt wurden. Dies umfasst die AspNetxxxx-Tabellen für die Autorisierung und die Tabellen für das Govmeeting-Datenmodell. </li>
</ul><h3> Andere Plattformen </h3>
<p> Es gibt das plattformübergreifende und Open Source <a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha">SQL Operations Studio,</a> "ein Datenverwaltungstool, das die Arbeit mit SQL Server, Azure SQL DB und SQL DW unter Windows, MacOS und Linux ermöglicht." Sie können <a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha">SQL Operations Studio hier kostenlos</a> herunterladen <a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha">.</a> </p>

<p> Wenn Sie dieses oder ein anderes Tool zum Durchsuchen von SQL Server-Datenbanken verwenden, aktualisieren Sie diese Anweisungen. </p>
<h2> Test Stubs </h2>
<p> Der Code zum Speichern / Abrufen von Transkriptdaten in der Datenbank ist noch nicht geschrieben. Daher verwendet DatabaseRepositories_Lib stattdessen statische Testdaten. In WebApp / appsettings.json wird die Eigenschaft "UseDatabaseStubs" auf "true" gesetzt, um die Stub-Routinen aufzurufen. </p>

<p> Der Benutzerregistrierungs- und Anmeldecode in WebApp verwendet jedoch die Datenbank. Es greift auf die Asp.Net-Benutzerauthentifizierungstabellen zu. WebApp authentifiziert API-Aufrufe von ClientApp basierend auf dem aktuell angemeldeten Benutzer. </p>

<p> Sie können den Vorprozessorwert "NOAUTH" in WebApp verwenden, um die Authentifizierung zu umgehen. Verwenden Sie eine der folgenden Methoden: </p>

<ul>
<li> Deaktivieren Sie in FixasrController.cs oder AddtagsController.cs die Zeile "#if NOAUTH" oben in der Datei. </li>
<li> Fügen Sie dies zu WebApp.csproj hinzu, um es für alle Controller zu deaktivieren: </li>
</ul><pre> <code> &lt;PropertyGroup Condition="&#39;$(Configuration)|$(Platform)&#39;==&#39;Debug|AnyCPU&#39;&gt; &lt;DefineConstants&gt;NOAUTH&lt;/DefineConstants&gt; &lt;/PropertyGroup&gt;</code> </pre>
<ul>
<li> Wechseln Sie in Visual Studio zu den WebApp-Eigenschaftsseiten -&gt; Erstellen -&gt; und geben Sie NOAUTH in das Feld "Bedingte Kompilierungssymbole" ein. </li>
</ul><hr />
<p><a name="GoogleCloud"></a></p>
<h1> Google Cloud Platform-Konto <br/></h1>
<p> <a href="about?id=setup#Contents">[Inhalt]</a> </p>

<p> Um die Google Speech APIs für die Konvertierung von Sprache in Text verwenden zu können, benötigen Sie ein GCP-Konto (Google Cloud Platform). Für die meisten Entwicklungsarbeiten in Govmeeting können Sie vorhandene Testdaten verwenden. Wenn Sie jedoch neue Aufnahmen transkribieren möchten, erhalten Sie eine GCP. Die Google API kann Aufzeichnungen in mehr als 120 Sprachen und Varianten transkribieren. </p>

<p> Google bietet Entwicklern ein kostenloses Konto mit einem Guthaben (derzeit 300 US-Dollar). Die aktuellen Kosten für die Verwendung der Sprach-API sind für bis zu 60 Minuten Konvertierung pro Monat kostenlos. Danach betragen die Kosten für das "erweiterte Modell" (was wir brauchen) 0,009 USD pro 15 Sekunden. (2,16 USD pro Stunde) </p>

<ul>
<li>
<p> Eröffnen Sie ein Konto bei <a href="https://cloud.google.com/free/">Google Cloud Platform</a> </p>
</li>
<li>
<p> Gehen Sie zum <a href="http://console.cloud.google.com">Google Cloud Dashboard</a> und erstellen Sie ein Projekt. </p>
</li>
<li>
<p> Rufen Sie die <a href="http://console.developers.google.com">Google Developer&#39;s Console auf</a> und aktivieren Sie die Sprach- und Cloud-Speicher-APIs </p>
</li>
<li>
<p> Generieren Sie einen Berechtigungsnachweis "Dienstkonto" für dieses Projekt. Klicken Sie in der Entwicklerkonsole auf Anmeldeinformationen. </p>
</li>
<li>
<p> Geben Sie diesem Konto die Berechtigung "Editor" für das Projekt. Klicken Sie auf das Konto. Klicken Sie auf der nächsten Seite auf Berechtigungen. </p>
</li>
<li>
<p> Laden Sie die JSON-Datei mit den Anmeldeinformationen herunter. </p>
</li>
<li>
<p> Legen Sie die Datei in den Ordner <code>SECRETS</code> , den Sie beim <code>SECRETS</code> des <code>SECRETS</code> erstellt haben. </p>
</li>
<li>
<p> Benennen Sie die Datei <code>TranscribeAudio.json</code> . </p>
</li>
</ul>
<p> HINWEIS: Die obigen Schritte haben sich möglicherweise geringfügig geändert. Wenn ja, aktualisieren Sie bitte dieses Dokument. </p>
<h2> Testen Sie die Transkription von Sprache zu Text </h2>
<ul>
<li>
<p> Setzen Sie das Startprojekt in Visual Studio auf <code>Backend/WorkflowApp</code> . Drücken Sie F5. </p>
</li>
<li>
<p> Kopieren Sie eine der MP4-Beispieldateien von Testdaten in Datendateien / EMPFANGEN (nicht verschieben). </p>
</li>
</ul>
<p> Das Programm erkennt nun, dass eine neue Datei angezeigt wurde, und beginnt mit der Verarbeitung. Die MP4-Datei wird nach Abschluss auf "COMPLETED" verschoben. Sie sehen die Ergebnisse in Sufoldern, die im Verzeichnis "Datendateien" erstellt wurden. </p>

<p> In appsettings.json gibt es eine Eigenschaft "RecordingSizeForDevelopment". Es ist derzeit auf "180" eingestellt. Dadurch verarbeitet die Transkriptionsroutine in ProcessRecording_Lib nur die ersten 180 Sekunden der Aufzeichnung. </p>
<hr />
<p><a name="GoogleApi"></a></p>
<h1> Google API-Schlüssel <br/></h1>
<p> <a href="about?id=setup#Contents">[Inhalt]</a> </p>

<p> Sie benötigen diese Schlüssel, wenn Sie bestimmte Funktionen des Registrierungs- und Anmeldevorgangs verwenden oder bearbeiten möchten. </p>

<ul>
<li> ReCaptcha-Schlüssel werden benötigt, um ReCaptcha während der Benutzerregistrierung zu verwenden. Sie können bei <a href="https://developers.google.com/recaptcha/">Google reCaptcha bezogen werden</a> . </li>
<li> OAuth 2.0-Anmeldeinformationen werden verwendet, um externe Benutzer anzumelden, ohne dass der Benutzer ein persönliches Konto auf der Site erstellen muss. Besuchen Sie die <a href="https://console.developers.google.com/">Google API-Konsole</a> , um Anmeldeinformationen wie eine Client-ID und ein Client-Geheimnis abzurufen. </li>
</ul>
<p> Erstellen Sie eine Datei mit dem Namen "appsettings.Development.json" im Ordner "SECRETS". Es sollte die Schlüssel enthalten, die Sie gerade erhalten haben: </p>
<pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-Id", "ClientSecret": "your-client-secret" } }, "ReCaptcha:SiteKey": "your-site-key", "ReCaptcha:Secret": "your-secret" }</code> </pre><hr /><h2> Testen Sie reCaptcha </h2>
<ul>
<li> Führen Sie das WebApp-Projekt aus. </li>
<li> Klicken Sie oben rechts auf "Registrieren". </li>
<li> Die Option reCaptcha sollte angezeigt werden. </li>
</ul><hr /><h2> Testen Sie die Google-Authentifizierung </h2>
<ul>
<li> Führen Sie das WebApp-Projekt aus. </li>
<li> Klicken Sie oben rechts auf "Login". </li>
<li> Wählen Sie unter "Verwenden Sie einen anderen Dienst zum Anmelden" die Option "Google". </li>
</ul>