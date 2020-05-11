<h1> Gérer les nouvelles transcriptions </h1><p> Certaines villes produisent des transcriptions des réunions. Cela nous permet de sauter la transcription de la réunion nous-mêmes. Mais cela pose un problème différent. Les transcriptions ne seront pas dans un format standard. </p><p> Notre logiciel devra: </p>
<ul>
<li> Extraire les informations. </li>
<li> Ajoutez des balises qui permettent d&#39;utiliser facilement les informations. </li>
</ul><p> Les informations normalement dans une transcription, que nous voulons extraire sont: </p>
<ul>
<li> Informations sur la réunion: heure, lieu, qu&#39;il s&#39;agisse d&#39;une réunion spéciale. </li>
<li> Officiels présents </li>
<li> En-têtes de section </li>
<li> Le nom de chaque conférencier et ce qu&#39;il a dit. </li>
</ul><p> Si aucun en-tête de section n&#39;est présent, le logiciel doit être suffisamment intelligent pour déterminer où commencent les sections communes: </p>
<ul>
<li> Appel de rôle </li>
<li> Invocation </li>
<li> Rapports des comités </li>
<li> Présentation des projets de loi </li>
<li> Résolutions </li>
<li> Commentaire du public </li>
</ul><p> Nous devrons voir dans quelle mesure nous pouvons également extraire les résultats du vote sur les projets de loi et les résolutions. Parfois, les résultats sont indiqués par des phrases telles que "Les oui l&#39;ont". D&#39;autres fois, un vote formel a lieu où le nom de chaque fonctionnaire est lu à haute voix et la personne répond par "oui" ou "non". </p><p> Les informations superflues doivent être supprimées. Par exemple: répétition des en-têtes ou pieds de page, numéros de ligne et numéros de page. </p><p> On espère qu&#39;un code général pourra être écrit pour extraire des informations d&#39;une nouvelle transcription qu&#39;il n&#39;a jamais eues. Cependant, jusque-là, un nouveau code devra être écrit pour gérer des cas spécifiques. </p><p> Étant donné que seules les grandes villes produisent des transcriptions: </p>
<ul>
<li> La plupart du temps, nous traiterons des enregistrements de réunions. </li>
<li> Dans une grande ville, il y a plus de programmeurs informatiques disponibles susceptibles d&#39;écrire un tel code. </li>
</ul><p> Nous pourrions construire un mécanisme de plug-in qui permettrait d&#39;ajouter des modules qui effectuent l&#39;extraction. Nous pourrions permettre aux plugins d&#39;être écrits dans de nombreux langages différents: Python, Java, PHP, Ruby - en plus des langages dans lesquels le système est actuellement écrit: Typescript et C #. </p><p> Actuellement, le logiciel ne gère qu&#39;un seul cas, Philadelphie, PA USA. La bibliothèque de projet "Backend \ ProcessMeetings \ ProcessTranscripts_lib" contient du code pour le traitement des transcriptions. </p><p> La classe "Specific_Philadelphia_PA_USA" appelle des routines à usage général pour traiter les transcriptions pour Philadelphie. </p><p> Il existe une classe de stub "Specific_Austin_TX_USA" destinée au traitement d&#39;une transcription à Austin, TX. Quelqu&#39;un voudra peut-être essayer de compléter ce code. Il y a une transcription de test dans le dossier Testdata. Mais il est probablement préférable d&#39;obtenir les dernières informations sur leur site Web: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p><h1> Modification du tableau de bord client </h1><h2> Ajouter une carte pour une nouvelle fonctionnalité </h2>
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
</ul><p> (Voir les autres exemples dans dash-main.html) </p><h2> Réorganiser les cartes </h2><ol>
<li> Ouvrez le fichier: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Modifiez les positions des cartes en modifiant la position des éléments gm-small-card ou gm-large-card dans ce fichier. </li></ol><h1> Enregistrement </h1><p> Les fichiers journaux pour WebApp et WorkflowApp se trouvent dans le dossier "logs" à la racine de la solution. </p>
<ul>
<li> "nlog-all- (date) .log" contient tous les messages du journal, y compris le système. </li>
<li> Le fichier "nlog-own- (date) .log" contient uniquement les messages d&#39;application. </li>
</ul><p> En haut de nombreux fichiers de composants dans ClientApp, un const "NoLog" est défini. Modifiez sa valeur de true à false pour activer la journalisation de la console uniquement pour ce composant. </p><h1> Créer des scripts </h1><p> Les scripts de construction Powershell se trouvent dans Utilitaires / PsScripts </p><h2> BuildPublishAndDeploy.ps1 </h2><p> Ce script appelle de nombreux autres scripts pour créer une version de production et la déploie. </p>
<ul>
<li> Build-ClientApp.ps1 - Construisez des versions de production de ClientApp </li>
<li> Publish-WebApp.ps1 - Créer un dossier "publier" de WebApp </li>
<li> Copy-ClientAssets.ps1 - Copier les actifs ClientApp dans le dossier wwwApp Webroot </li>
<li> Deploy-PublishFolder.ps1 - Déployer le dossier de publication sur un hôte distant </li>
<li> Créez le fichier README.md pour Gethub à partir des fichiers de documentation </li>
</ul><p> Deploy-PublishFolder.ps1 déploie le logiciel sur govmeeting.org, à l&#39;aide de FTP. Les informations de connexion FTP se trouvent dans le fichier appsettings.Development.json du dossier SECRETS. Il contient FTP et d&#39;autres secrets à utiliser dans le développement. Voici le format de ce fichier: </p><pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-id", "ClientSecret": "your-client-secret" } }, "ReCaptcha": { "SiteKey": "your-site-key", "Secret": "your-secret" }, "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } }</code> </pre>