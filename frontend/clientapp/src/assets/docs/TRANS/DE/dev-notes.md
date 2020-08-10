<h1> Verarbeiten Sie neue Transkriptformate </h1>
<p> Das ultimative Ziel ist es, Code zu schreiben, der jedes Transkriptformat verarbeitet. Bis dahin müssen wir jedoch benutzerdefinierten Code schreiben, um jedes neue Format zu verarbeiten. Wenn wir genügend Beispiele für verschiedene Formate haben, können wir den generischen Code besser schreiben. </p>

<p> Dies sind die Schritte zum Umgang mit neuen Transkriptformaten: </p>

<ul>
<li>
<p> Erhalten Sie ein Beispielprotokoll einer Regierungssitzung als PDF- oder Textdatei. </p>
</li>
<li>
<p> Benennen Sie die Datei wie folgt: "country_state_county_municipality_agency_language-code_date.pdf". (oder .txt) Zum Beispiel: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Erstellen Sie im Projekt "ProcessTranscripts_Lib" eine neue Klasse mit der Schnittstelle "ISpecificFix". </p>
</li>
<li>
<p> Nennen Sie die Klasse "country_state_county_municipality_agency_language-code". Zum Beispiel: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Implementieren Sie die Klassenmethode: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix () empfängt den vorhandenen Transkripttext und gibt den Text im folgenden Format zurück: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Wenn diese Klasse abgeschlossen ist, verarbeitet WorkflowApp die neuen Transkripte, wenn sie in "DATAFILES / RECEIVED" angezeigt werden. </p>

<p> Anmerkungen: </p>

<p> Wir verwenden System.Reflection, um die richtige Klasse basierend auf dem Namen der zu verarbeitenden Datei zu instanziieren. </p>

<p> Ein Beispiel finden Sie in der Klasse "USA_PA_Philadelphia_Philadelphia_CityCouncil_en" in ProcessTranscripts_Lib. Sie können besser verstehen, was diese Klasse tut, indem Sie sich die Protokolldateispuren im "Arbeitsordner" ansehen, der als Argument an Fix () übergeben wird. </p>

<p> Wir extrahieren die folgenden Informationen jetzt nicht, aber wir werden dies eventuell tun wollen. </p>

<ul>
<li> Anwesende Beamte </li>
<li> Gesetzentwürfe und Beschlüsse eingeführt </li>
<li> Abstimmungsergebnisse </li>
</ul>
<p> Austin, TX - USA hat auch Abschriften von öffentlichen Versammlungen online. In ProcessTranscripts_Lib wurde eine Klasse mit dem Namen "USA_TX_TravisCounty_Austin_CityCouncil_en" erstellt. Die Fix () -Methode wurde jedoch nicht implementiert. Transkripte können von ihrer Website bezogen werden: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Ändern Sie das Client-Dashboard </h1><h2> Fügen Sie eine Karte für eine neue Funktion hinzu </h2>
<ul>
<li> Wechseln Sie an einer Terminal-Eingabeaufforderung in den Ordner: FrontEnd / ClientApp </li>
<li> Geben Sie Folgendes ein: ng Komponente Ihrer Funktion generieren </li>
<li> Fügen Sie Ihre Funktionalität zu den Dateien in: FrontEnd / ClientApp / src / app / your-feature hinzu </li>
<li> Fügen Sie ein neues gm-small-card- oder gm-large-card-Element in app / dash-main / dash-main.html ein. </li>
<li> Ändern Sie das Symbol, die Symbolfarbe, den Titel usw. des Kartenelements. </li>
<li> Wenn Sie Zugriff auf den Namen des aktuell ausgewählten Standorts und der Agentur in Ihrem Controller benötigen: 
<ul>
<li> Fügen Sie Ihrem Feature-Element die Standort- und Agentureingabeattribute hinzu </li>
<li> Fügen Sie Ihrem Controller Standort- und Agentureigenschaften @Input hinzu. </li>
</ul></li>
</ul>
<p> (Siehe die anderen Beispiele in dash-main.html) </p>
<h2> Karten neu anordnen </h2><ol>
<li> Öffnen Sie die Datei: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Ändern Sie die Kartenpositionen, indem Sie die Position der gm-small-card- oder gm-large-card-Elemente in dieser Datei ändern. </li></ol><h1> Protokollierung </h1>
<p> Die Protokolldateien für WebApp und WorkflowApp befinden sich im Ordner "logs" im Stammverzeichnis der Lösung. </p>

<ul>
<li> "nlog-all- (date) .log" enthält alle Protokollmeldungen einschließlich des Systems. </li>
<li> Die Datei "nlog-own- (date) .log" enthält nur die Anwendungsnachrichten. </li>
</ul>
<p> Oben in vielen Komponentendateien in ClientApp wird eine Konstante "NoLog" definiert. Ändern Sie den Wert von true in false, um die Konsolenprotokollierung nur für diese Komponente zu aktivieren. </p>
<h1> Skripte erstellen </h1>
<p> Powershell-Build-Skripte finden Sie in Utilities / PsScripts </p>

<ul>
<li> BuildPublishAndDeploy.ps1 - Rufen Sie die anderen Skripts auf, um eine Version zu erstellen und bereitzustellen. </li>
<li> Build-ClientApp.ps1 - Erstellen Sie Produktionsversionen von ClientApp </li>
<li> Publish-WebApp.ps1 - Erstellen Sie einen "Publish" -Ordner von WebApp </li>
<li> Copy-ClientAssets.ps1 - Kopieren Sie ClientApp-Assets in den WebApp-Ordner wwwroot </li>
<li> Deploy-PublishFolder.ps1 - Stellen Sie den Veröffentlichungsordner auf einem Remote-Host bereit </li>
<li> Erstellen Sie die Datei README.md für Gethub aus den Dokumentationsdateien </li>
</ul>
<p> Deploy-PublishFolder.ps1 stellt die Software über FTP auf govmeeting.org bereit. Die FTP-Anmeldeinformationen befinden sich in der Datei appsettings.Development.json im Ordner SECRETS. Es enthält FTP und andere Geheimnisse zur Verwendung in der Entwicklung. Unten finden Sie den Abschnitt dieser Datei, der von FTP verwendet wird: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
