<style>
  table {
  font-size: 100%;
}

table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
  font-weight: normal;
}
th, td {
  padding: 3px;
}
th {
  text-align: left;
}
th {
  text-align: center;
  font-weight: bold;
}
</style>
<p> Die Tabellen in der Datenbank bestehen aus: </p>
<ol>
<li> Authentifizierungstabellen. </li></ol>
<p> Diese wurden vom Microsoft Identity Service automatisch erstellt, wenn beim ersten Erstellen des Projekts "Authentifizierung = Einzelbenutzerkonten" aktiviert wurde. </p>
<ol start="2">
<li> Govmeeting-Tische. </li></ol>
<p> Diese werden mit der Funktion "Code First" von Entity Framework erstellt. EF liest die C# -Klassen in der Projektbibliothek "Datenbank / Modell" und generiert automatisch das Datenbankschema und die Tabellen. </p>

<p> Informationen zum Erstellen und Arbeiten mit der Datenbank finden Sie auf der Dokumentseite "Setup". </p>
<h1> Schema </h1><h2> Tabelle "Regierungsstelle" </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th><th> Beispiel 3 </th></tr>
<tr><td> Primärschlüssel </td><td> einzigartiger Schlüssel </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Name </td><td> Name des Unternehmens </td><td> Senat </td><td> Versammlung </td><td> Plantafel </td></tr>
<tr><td> Land </td><td> Land Standort </td><td> USA </td><td> USA </td><td> USA </td></tr>
<tr><td> Zustand </td><td> Zustand Standort </td><td></td><td> Iowa </td><td> New Jersey </td></tr>
<tr><td> Bezirk </td><td> Lage des Landkreises oder der Region </td><td></td><td></td><td> Gloucester </td></tr>
<tr><td> Kommunal </td><td> Stadt oder Gemeinde </td><td></td><td></td><td> Monroe Township </td></tr>
</table>

<p>
* Weitere Beispiele für die Government Entity-Tabelle </p>

<table><tr><th> Feld </th><th> Beispiel 4 </th><th> Beispiel 5 </th></tr>
<tr><td> Primärschlüssel </td><td> 4 </td><td> 5 </td></tr>
<tr><td> Name </td><td> Vidhan Sabha </td><td> Gemeinderat </td></tr>
<tr><td> Land </td><td> Indien </td><td> Indien </td></tr>
<tr><td> Zustand </td><td> Andhra Pradesh </td><td> Andhra Pradesh </td></tr>
<tr><td> Bezirk </td><td></td><td> Kadapa Bezirk </td></tr>
<tr><td> Kommunal </td><td></td><td> Rayachoty </td></tr>
</table>

<p> Beachten Sie, dass wenn sich die Regierungsstelle auf nationaler Ebene befindet, ihre staatlichen, regionalen und kommunalen Standorte null sind. Wenn sich das Unternehmen auf Landesebene befindet, sind seine Standorte in Landkreisen und Gemeinden null usw. </p>

<p> Beispiele für andere Länder werden benötigt. Wenn Sie andere Beispiele haben, bearbeiten Sie dieses Dokument und stellen Sie eine Pull-Anfrage in Github. Wenn es Gründe gibt, warum dies in einigen Ländern nicht funktioniert, senden Sie bitte eine Ausgabe an einen Github. </p>
<hr /><h2> "Besprechungstisch </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th></tr>
<tr><td> Primärschlüssel </td><td> einzigartiger Schlüssel </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Regierung </td><td> Schlüssel zur Regierungsstelle </td><td> 2 (US-Senat) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Zeit </td><td> Zeit des Treffens </td><td> 3. August &#39;14 19:30 </td><td> 2. Mai &#39;14 13:00 </td></tr>
<tr><td> Text </td><td> Transkriptionstext </td><td> "Das Treffen wird auf Bestellung kommen. ..." </td><td> "Die Versammlung wird einberufen. ..." </td></tr>
</table>
<hr /><h2> Tabelle "Repräsentant" </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th></tr>
<tr><td> Primärschlüssel </td><td> einzigartiger Schlüssel </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Vollständiger Name </td><td> vollständiger Name </td><td> Abgeordneter Steve Jones </td><td> Vorsitzender Ravi Anand </td></tr>
<tr><td> Kennung </td><td> persönliche Kennung </td><td> (ausgewählt sein </td><td> (ausgewählt sein) </td></tr>
</table>

<p> Die Redner bei den Sitzungen könnten Vertreter des Leitungsorgans oder der Öffentlichkeit sein. In beiden Fällen können dieselben Personen an Sitzungen in mehr als einer Regierungsstelle teilnehmen. Wir werden nachverfolgen wollen, was derselbe Vertreter in jedem der Gremien sagt, in denen er / sie Mitglied ist. Daher benötigen wir für jeden Vertreter eine eindeutige Kennung. </p>

<p> Wir müssen entscheiden, welche Informationen für diese Identifizierung erforderlich sind. Wir werden offensichtlich nicht die nationale Identitätsnummer einer Person von so etwas haben. Möglicherweise müssen wir eine Kombination aus mehr als einem Feld verwenden, um jemanden zu identifizieren. Zum Beispiel Adresse und Name. </p>

<p> Es wird eine "Repräsentant" -Tabelle geben, die eine eindeutige persönliche Kennung für jeden Repräsentanten enthält. </p>
<hr /><h2> Tabelle "RepresentativeToEntity" </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th><th> Beispiel 3 </th></tr>
<tr><td> Vertreter </td><td> Schlüssel zum Vertreter </td><td> 1 </td><td> 2 </td><td> 2 </td></tr>
<tr><td> Regierung </td><td> Schlüssel zur Regierungsstelle </td><td> 5 </td><td> 7 </td><td> 9 </td></tr>
</table>

<p> Es wird auch eine Tabelle mit dem Titel "RepresentativeToEntity" geben, in der Vertreter und die Regierungsstellen, denen sie angehören, miteinander verbunden sind. Beachten Sie, dass derselbe Vertreter für mehrere Regierungsstellen tätig sein kann. </p>
<hr /><h2> "Bürger" -Tisch </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th></tr>
<tr><td> Primärschlüssel </td><td> einzigartiger Schlüssel </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Name </td><td> Name </td><td> John J. </td><td> Rai S. </td></tr>
<tr><td> Treffen </td><td> Schlüssel zum Treffen </td><td> 2 (Sitzung des US-Senats am 3. August 14) </td><td> 4 (Vidhan Sabha Treffen am 2. Mai &#39;14) </td></tr>
</table>

<p> Es wird einen "Citizen" -Tisch für die Öffentlichkeit geben. Die Bürgertabelle enthält einen Fremdschlüssel, der auf die Besprechung verweist, bei der diese Person gesprochen hat. </p>

<p> Sollten wir versuchen zu verfolgen, was Mitglieder der Öffentlichkeit über alle Sitzungen, an denen sie teilnehmen, sagen? Vielleicht ist das nicht angebracht. </p>

<p> Wenn nicht, muss nicht versucht werden, öffentliche Redner eindeutig zu identifizieren. Der Name, den die Person gibt, wenn sie bei einer Besprechung spricht, kann verwendet werden, um jemanden nur für diese Besprechung zu identifizieren. Wir müssen diesen Namen nicht über Besprechungen hinweg korrelieren. Wir können es sogar vorziehen, nur den Vor- und Nachnamen zu speichern. </p>
<hr /><h2> "Thema" Tabelle </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th><th> Beispiel 3 </th></tr>
<tr><td> Primärschlüssel </td><td> einzigartiger Schlüssel </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Regierung </td><td> Schlüssel zur Regierungsstelle </td><td> 2 (US-Senat) </td><td> 2 (US-Senat) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Art </td><td> Kategorie oder Thema </td><td> Kategorie </td><td> Thema </td><td> Kategorie </td></tr>
<tr><td> Name </td><td> Themenname </td><td> Gesundheit </td><td> Obamacare </td><td> Bildung </td></tr>
</table>

<p> Jede Regierungsstelle (zum Beispiel der US-Senat oder das Zoning Board in Monroe Township, New Jersey, USA) hat ihre eigenen eindeutigen Namen für Kategorien und Themen, die auf ihren Sitzungen erörtert werden. Daher enthält die Tag-Name-Tabelle einen Fremdschlüssel, der auf die Regierungseinheit verweist. </p>
<hr />
<p> Das vollständige Protokoll des Meetings besteht aus einer Textfolge. Die Tabellen Speaker Location und Tag Location enthalten Zeiger in den Text, nämlich die Start- und Endpunkte, an denen sich entweder der Sprecher oder das Tag ändert. Dies sind Zeichenzeiger in die Textzeichenfolge. </p>
<h2> Tabelle "Lautsprecher-Tags" </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th></tr>
<tr><td> PimaryKey </td><td> einzigartiger Schlüssel </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Lautsprecher </td><td> Schlüssel zum Lautsprecher </td><td> 1 (Rep. Jones) </td><td> 2 (Vorsitzender. Anand) </td></tr>
<tr><td> Treffen </td><td> Schlüssel zum Treffen </td><td> 1 (Sitzung 1) </td><td> 2 (Sitzung 2) </td></tr>
<tr><td> Start </td><td> Punkt, an dem der Sprecher zu sprechen beginnt </td><td> 521 </td><td> 12045 </td></tr>
<tr><td> Ende </td><td> Punkt, an dem der Sprecher aufhört zu sprechen </td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2> Tabelle "Themen-Tags" </h2>
<table><tr><th> Feld </th><th> Bedeutung </th><th> Beispiel 1 </th><th> Beispiel 2 </th></tr>
<tr><td> Primärschlüssel </td><td> einzigartiger Schlüssel </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Etikett </td><td> Schlüssel des Tags </td><td> 1 (Energie) </td><td> 2 (Ausbildung) </td></tr>
<tr><td> Treffen </td><td> Schlüssel zum Treffen </td><td> 1 (Sitzung 1) </td><td> 2 (Sitzung 2) </td></tr>
<tr><td> Start </td><td> Punkt, an dem das Thema beginnt </td><td> 750 </td><td> 14500 </td></tr>
<tr><td> Ende </td><td> Punkt, an dem das Thema aufhört </td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2> Datengröße </h2>
<p> Die Größe der Datenbank für die endgültige Besprechung ist sehr klein. Auf diese Weise können wir Anwendungen erstellen, bei denen ein Großteil der Daten lokal auf dem Computer oder Smartphone eines Benutzers gespeichert wird - für eine hohe Leistung und die Möglichkeit, die Anwendung offline auszuführen. </p>
