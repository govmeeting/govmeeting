<p> Nachfolgend finden Sie eine Funktionsbeschreibung der Hauptteile der Software. </p>
<h2> Einzelregistrierung </h2>
<ul>
<li> Bei der Registrierung geben Benutzer ihren Heimatort an (Stadt, Dorf, Postleitzahl usw.). </li>
<li> Basierend auf ihrem Standort bestimmt das System die maßgeblichen Einheiten, zu denen sie gehören. (Land, Bundesland, Landkreis, Stadt usw.) </li>
</ul><h2> Registrierung von Regierungsstellen </h2>
<ul>
<li> Ein Benutzer kann jede der maßgeblichen Einheiten registrieren, zu denen er gehört. </li>
<li> Zu den eingegebenen Informationen gehören: 
<ul>
<li> Webadresse </li>
<li> Namen der Regierungsbeamten </li>
<li> URLs, unter denen Transkripte oder Besprechungsaufzeichnungen gefunden werden können </li>
</ul></li>
<li> Anderen Benutzern für diesen Speicherort werden bereits eingegebene Daten angezeigt. Sie können über die Richtigkeit aller Datenelemente abstimmen und alternative Werte eingeben. </li>
<li> Für jeden Datenwert werden Stimmen gesammelt. Die Werte mit den meisten Stimmen werden zu offiziellen Werten. <a href="https://github.com/govmeeting/govmeeting/issues/62">Github-Ausgabe Nr. 62</a> </li>
</ul><h2> Aufzeichnungen oder Transkripte importieren </h2>
<ul>
<li> Das System lädt regelmäßig vorhandene Online-Aufzeichnungen oder Transkripte von den in der Registrierung der Regierungsbehörde angegebenen Orten herunter. </li>
<li> Benutzer haben auch die Möglichkeit, Aufzeichnungen oder Transkripte hochzuladen. </li>
<li> Viele Orte stellen weder Transkripte noch Aufzeichnungen ihrer Treffen zur Verfügung. Govmeeting bietet eine Smartphome-App, mit der Benutzer eine Besprechungsaufzeichnung persönlich aufzeichnen und hochladen können. <a href="https://github.com/govmeeting/govmeeting/issues/18">Github Ausgabe Nr. 18</a> </li>
</ul><h2> Vorhandene Transkripte vorverarbeiten </h2>
<ul>
<li> Konvertieren Sie Transkripte in einfachen Text. Häufig liegen vorhandene Transkripte in anderen Formaten wie PDF vor. Diese werden in einfachen Text konvertiert, damit sie leichter verarbeitet werden können. </li>
<li> Extrahieren Sie Informationen wie Sprecher- und Abschnittsnamen. </li>
</ul><h2> Transkribieren Sie Aufzeichnungen mit Spracherkennung </h2>
<ul>
<li> Konvertieren Sie Aufnahmen in die primären Webvideoformate (mp4, ogg und webm). Dadurch sind sie auf allen Arten von Geräten leichter zugänglich. </li>
<li> Extrahieren und Zusammenführen von Audiospuren, wenn mehrere vorhanden sind. </li>
<li> Laden Sie die Audiodatei in den Google Cloud-Speicher hoch, um die Transkription vorzubereiten. </li>
<li> Rufen Sie die asynchrone Google Speech API auf, um die automatische Spracherkennung durchzuführen. </li>
<li> Führen Sie eine Lautsprecherwechselerkennung durch. Hierfür gibt es eine Google-API. </li>
<li> Sprecheridentifikation hinzufügen. Dies verwendet eine Sprachverarbeitungssoftware auf dem Server. </li>
<li> Stellen Sie die Informationen zur weiteren Verarbeitung in ein JSON-Format. </li>
<li> Teilen Sie die Video-, Audio- und Transkriptionsdateien in 3-Minuten-Arbeitssegmente auf, sodass mehrere Freiwillige gleichzeitig am Korrekturlesen arbeiten können. </li>
</ul><h2> Korrekturlesen von transkribiertem Text [Manueller Schritt] </h2>
<ul>
<li> Korrekturlesen von Text auf Fehler. Bereitstellung einer benutzerfreundlichen Oberfläche zur schnellen Korrektur von Fehlern. </li>
<li> Korrigieren Sie Informationen wie Sprecher- und Abschnittsnamen. </li>
</ul>
<p> Govmeeting versucht, die Verarbeitung so automatisch wie möglich zu gestalten. Aber Computer sind noch nicht so intelligent, wie wir es gerne hätten. Menschen werden immer noch benötigt, um ihre Fehler zu korrigieren. Aber mit jedem Tag werden Computer intelligenter und diese Arbeit sollte immer weniger werden. </p>
<h2> Issue-Tags hinzufügen [Manueller Schritt] </h2>
<ul>
<li> Eine der wichtigsten Aufgaben ist das korrekte Hinzufügen von Tags oder Metadaten zum Transkript. Dies ermöglicht: 
<ul>
<li> Informationen leicht zu finden. </li>
<li> ein Transkript, das schnell indiziert und durchsucht werden kann </li>
<li> Warnungen, die vom Benutzer zu bestimmten Themen festgelegt werden müssen </li>
</ul></li>
<li> Die Namen der Probleme müssen von Personen und nicht von Computern zugewiesen werden. Dies ist der beste Weg, um sicherzustellen, dass sie sinnvoll sind. </li>
<li> Es ist wichtig, dass eine sehr einfach zu bedienende und schnelle Benutzeroberfläche bereitgestellt wird. </li>
</ul>
<p> In Zukunft kann dieser Schritt möglicherweise auch hauptsächlich von einem Computer ausgeführt werden. Aber es ist nicht alles schlecht, manuelle Arbeit von Freiwilligen der Gemeinde zu benötigen. Es hilft, Menschen für eine gemeinsame Sache zu vereinen. Wenn dies eine kleine Stadt mit 35.000 Einwohnern ist, sollte es nicht so schwierig sein, ein Dutzend oder so anzuwerben, um jeden Monat eine kurze Zeitspanne zu haben. </p>
<h2> Füllen Sie die relationale Datenbank </h2>
<p> Die Daten werden in eine relationale Datenbank gestellt, sodass nach mehreren Kriterien schnell auf sie zugegriffen werden kann. </p>
<h2> Daten stehen jetzt zur Verwendung zur Verfügung </h2>
<ul>
<li> Ein browe- und durchsuchbares Transkript ist jetzt verfügbar </li>
<li> Eine Zusammenfassung der auf dem Treffen erörterten Themen wird an die Antragsteller gesendet. </li>
<li> Benachrichtigungen zu bestimmten Themen werden an diejenigen gesendet, die sie anfordern. </li>
</ul><h2> Virtuelles Treffen ist arrangiert. </h2>
<ul>
<li> Eine Agenda wird basierend auf den Themen des realen Meetings erstellt. </li>
<li> Einladungen werden an Community-Mitglieder gesendet. </li>
<li> In der Einladung sind Anfragen nach möglichen zusätzlichen Tagesordnungspunkten enthalten. </li>
<li> Wenn Antworten eingehen, wird ein Stimmzettel an diejenigen gesendet, die teilnehmen werden. Bei dieser Abstimmung können die Mitglieder über die vorgeschlagenen neuen Tagesordnungspunkte abstimmen. </li>
<li> Innerhalb weniger Tage findet ein virtuelles Meeting statt. </li>
</ul><h2> Workflow-Management </h2>
<p> Einige der oben genannten Workflow-Schritte werden automatisch vom Computer ausgeführt, andere manuell von Freiwilligen. Es gibt Stellen im Workflow, an denen eine reale Person überprüfen sollte, ob das Fortfahren in Ordnung ist: </p>

<ul>
<li> Stellen Sie sicher, dass URLs zum Abrufen von Transkripten und Aufzeichnungen gültig sind. </li>
<li> Stellen Sie sicher, dass der Inhalt der abgerufenen Dateien gültig erscheint. </li>
<li> Stellen Sie sicher, dass die Ausgabe der Vorverarbeitung gültig erscheint. </li>
<li> Stellen Sie sicher, dass die Konvertierung von Sprache in Text gültig ist. </li>
<li> Stellen Sie sicher, dass das Korrekturlesen des Transkripts abgeschlossen ist. </li>
<li> Stellen Sie sicher, dass das Hinzufügen von Tags zum Transkript abgeschlossen ist. </li>
<li> Stellen Sie sicher, dass die endgültigen Transkriptdaten vollständig und gültig sind. </li>
</ul>
<p> Es muss eine Möglichkeit geben, die Rechte eines oder mehrerer registrierter Benutzer eines Standorts auf eine "Manager" -Position zu erhöhen. </p>

<ul>
<li> Manager werden benachrichtigt, wenn eine Entscheidung im Workflow aussteht. </li>
<li> Ein Manager kann sich dann anmelden und die Genehmigung für die Fortsetzung des Workflows erteilen oder verweigern. </li>
</ul>
