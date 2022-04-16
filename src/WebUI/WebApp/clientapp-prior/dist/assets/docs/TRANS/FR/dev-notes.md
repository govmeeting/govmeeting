<h1> Traiter de nouveaux formats de transcription </h1>
<p> Le but ultime est d&#39;écrire du code qui traitera n&#39;importe quel format de transcription. Mais jusque-là, nous devons écrire du code personnalisé pour gérer chaque nouveau format. Lorsque nous aurons suffisamment d&#39;échantillons de différents formats, nous serons mieux en mesure d&#39;écrire le code générique. </p>

<p> Voici les étapes de gestion des nouveaux formats de transcription: </p>

<ul>
<li>
<p> Obtenez un exemple de transcription d&#39;une réunion du gouvernement sous forme de fichier PDF ou texte. </p>
</li>
<li>
<p> Nommez le fichier comme suit: "country_state_county_municipality_agency_language-code_date.pdf". (ou .txt) Par exemple: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Créez une nouvelle classe avec l&#39;interface "ISpecificFix" dans le projet "ProcessTranscripts_Lib". </p>
</li>
<li>
<p> Nommez la classe "country_state_county_municipality_agency_language-code". Par exemple: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Implémentez la méthode de classe: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix () reçoit le texte de transcription existant et renvoie le texte au format suivant: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Lorsque cette classe est terminée, WorkflowApp traitera les nouvelles transcriptions lorsqu&#39;elles apparaîtront dans "DATAFILES / RECEIVED". </p>

<p> Remarques: </p>

<p> Nous utilisons System.Reflection pour instancier la classe correcte en fonction du nom du fichier à traiter. </p>

<p> Voir la classe "USA_PA_Philadelphia_Philadelphia_CityCouncil_en" dans ProcessTranscripts_Lib pour un exemple. Vous pouvez mieux comprendre ce que fait cette classe en examinant les traces du fichier journal dans le "dossier de travail" qui est passé en argument à Fix (). </p>

<p> Nous n&#39;extrayons pas les informations suivantes maintenant, mais nous voudrons éventuellement le faire. </p>

<ul>
<li> Officiels présents </li>
<li> Projets de loi et résolutions présentés </li>
<li> Résultats du vote </li>
</ul>
<p> Austin, TX - USA a également des transcriptions des réunions publiques en ligne. Une classe a été créée appelée "USA_TX_TravisCounty_Austin_CityCouncil_en" dans ProcessTranscripts_Lib. Mais la méthode Fix () n&#39;a pas été implémentée. Les transcriptions peuvent être obtenues sur leur site Web: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Modifier le tableau de bord client </h1><h2> Ajouter une carte pour une nouvelle fonctionnalité </h2>
<ul>
<li> À l&#39;invite du terminal, accédez au dossier: FrontEnd / ClientApp </li>
<li> Entrez: ng générer le composant votre-fonctionnalité </li>
<li> Ajoutez vos fonctionnalités aux fichiers dans: FrontEnd / ClientApp / src / app / your-feature </li>
<li> Insérez un nouvel élément gm-small-card ou gm-large-card dans app / dash-main / dash-main.html. </li>
<li> Modifiez l&#39;icône, la couleur, le titre, etc. de l&#39;élément de carte. </li>
<li> Si vous avez besoin d&#39;accéder au nom de l&#39;emplacement et de l&#39;agence actuellement sélectionnés dans votre contrôleur: 
<ul>
<li> Ajoutez l&#39;emplacement et les attributs d&#39;entrée d&#39;agence à votre élément d&#39;entité </li>
<li> Ajoutez des propriétés de localisation et d&#39;agence @Input dans votre contrôleur. </li>
</ul></li>
</ul>
<p> (Voir les autres exemples dans dash-main.html) </p>
<h2> Réorganiser les cartes </h2><ol>
<li> Ouvrez le fichier: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Modifiez les positions des cartes en modifiant la position des éléments gm-small-card ou gm-large-card dans ce fichier. </li></ol><h1> Enregistrement </h1>
<p> Les fichiers journaux pour WebApp et WorkflowApp se trouvent dans le dossier "logs" à la racine de la solution. </p>

<ul>
<li> "nlog-all- (date) .log" contient tous les messages du journal, y compris le système. </li>
<li> Le fichier "nlog-own- (date) .log" contient uniquement les messages d&#39;application. </li>
</ul>
<p> En haut de nombreux fichiers de composants dans ClientApp, un const "NoLog" est défini. Modifiez sa valeur de true à false pour activer la journalisation de la console uniquement pour ce composant. </p>
<h1> Créer des scripts </h1>
<p> Les scripts de construction Powershell se trouvent dans Utilitaires / PsScripts </p>

<ul>
<li> BuildPublishAndDeploy.ps1 -Call les autres scripts pour créer une version et la déployer. </li>
<li> Build-ClientApp.ps1 - Construisez des versions de production de ClientApp </li>
<li> Publish-WebApp.ps1 - Créer un dossier "publier" de WebApp </li>
<li> Copy-ClientAssets.ps1 - Copier les actifs ClientApp dans le dossier wwwApp Webroot </li>
<li> Deploy-PublishFolder.ps1 - Déployer le dossier de publication sur un hôte distant </li>
<li> Créez le fichier README.md pour Gethub à partir des fichiers de documentation </li>
</ul>
<p> Deploy-PublishFolder.ps1 déploie le logiciel sur govmeeting.org, à l&#39;aide de FTP. Les informations de connexion FTP se trouvent dans le fichier appsettings.Development.json du dossier SECRETS. Il contient FTP et d&#39;autres secrets à utiliser dans le développement. Voici la section de ce fichier utilisée par FTP: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
