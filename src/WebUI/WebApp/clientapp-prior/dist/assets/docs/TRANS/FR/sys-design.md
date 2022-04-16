<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle"> Conception </mat-card-title>
<markdown ngPreserveWhitespaces>

<p> Les diagrammes ci-dessous montrent l&#39;interaction entre les composants logiciels. </p>
<ul>
<li><p> ClientApp est une application de page unique Angular Typescript qui s&#39;exécute dans le navigateur. Il fournit l&#39;interface utilisateur. </p></li>
<li><p> WebApp est une application <a href="https://github.com/aspnet/home">Asp.Net Core</a> C# qui s&#39;exécute sur le serveur. Il répond aux appels WebApi. </p></li>
<li><p> WorkflowApp est une <a href="https://github.com/dotnet/core">application DotNet Core</a> C# qui s&#39;exécute sur le serveur. Il fait le traitement par lots des enregistrements et des transcriptions. Il peut également être converti en une bibliothèque qui s&#39;exécute dans le cadre du processus WebApp. </p></li>
<li><p> Les autres composants du serveur sont des bibliothèques DotNet Core C #. Ils sont utilisés à la fois par WebApp et WorkflowApp. </p></li>
</ul><hr /><h2> Conception du système </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>
<p> Les composants du schéma ci-dessus sont: </p>
<table style="width:100%">
<tr><th colspan="2"> Applications </th></tr>
<tr><td> ClientApp </td><td> SPA angulaire </td></tr>
<tr><td> WebApp </td><td> Processus du serveur Web Asp.Net </td></tr>
<tr><td> WorkflowApp </td><td> Processus de contrôle du serveur de workflow </td></tr>
<tr><th colspan="2"> Bibliothèques </th></tr>
<tr><td> GetOnlineFiles </td><td> Récupérer les transcriptions et enregistrements en ligne </td></tr>
<tr><td> ProcessRecording </td><td> Extraire et transcrire l&#39;audio. Créez des segments de travail. </td></tr>
<tr><td> ProcessTranscript </td><td> Transformez les transcriptions brutes </td></tr>
<tr><td> LoadDatabase </td><td> Remplissez la base de données avec les données de la transcription terminée </td></tr>
<tr><td> Accès en ligne </td><td> Routines pour récupérer des fichiers à partir de sites distants </td></tr>
<tr><td> GoogleCloudAccess </td><td> Routines pour accéder aux services Google Cloud </td></tr>
<tr><td> FileDataRepositories </td><td> Stocker et obtenir les données du fichier de travail JSON </td></tr>
<tr><td> Référentiels </td><td> Stockez et obtenez les données du modèle à partir de la base de données </td></tr>
<tr><td> DatabaseAccess </td><td> Accéder à la base de données à l&#39;aide d&#39;Entity Framework </td></tr>
</table>
<hr /><h2> ClientApp Design </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>
<p> La structure de ClientApp est mieux illustrée par sa structure de composant angulaire </p>
<table style="width:100%">
<tr><th colspan="2"> Composants d&#39;application </th></tr>
<tr><td> Entête </td><td> Entête </td></tr>
<tr><td> Sidenav </td><td> Navigation dans la barre latérale </td></tr>
<tr><td> Tableau de bord </td><td> Conteneur pour les composants du tableau de bord </td></tr>
<tr><td> Documentation </td><td> Conteneur pour les pages de documentation </td></tr>
<tr><th colspan="2"> Composants du tableau de bord </th></tr>
<tr><td> Fixasr </td><td> Correction du texte de reconnaissance vocale automatique </td></tr>
<tr><td> Ajouter des balises </td><td> Ajouter des balises aux transcriptions </td></tr>
<tr><td> ViewMeeting </td><td> Voir les transcriptions terminées </td></tr>
<tr><td> Problèmes </td><td> Afficher des informations sur les problèmes </td></tr>
<tr><td> Alertes </td><td> Afficher et définir des informations sur les alertes </td></tr>
<tr><td> Officiels </td><td> Afficher des informations sur les officiels </td></tr>
<tr><td> (Autres)) </td><td> Autres composants à mettre en œuvre </td></tr>
<tr><th colspan="2"> Prestations de service </th></tr>
<tr><td> VirtualMeeting </td><td> Organiser une réunion virtuelle </td></tr>
<tr><td> Bavarder </td><td> Composant de chat utilisateur </td></tr>
</table>
<hr /><h2> Conception WebApp </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>
<p> Chacune des API Web est petite et appelle les référentiels pour placer ou obtenir des données à partir de la base de données ou du système de fichiers. </p>
<table style="width:100%">
<tr><th colspan="2"> Contrôleurs </th></tr>
<tr><td> Fixasr </td><td> Enregistrez et obtenez la version la plus récente de la transcription en cours de relecture. </td></tr>
<tr><td> Ajouter des balises </td><td> Enregistrez et obtenez la version la plus récente de la transcription balisée. </td></tr>
<tr><td> Réunion </td><td> Obtenez le dernier trnascript complété. </td></tr>
<tr><td> Govbodies </td><td> Enregistrez et obtenez les données des organismes gouvernementaux enregistrés. </td></tr>
<tr><td> Réunions </td><td> Enregistrez et obtenez des informations sur la réunion. </td></tr>
<tr><td> Vidéo </td><td> Obtenez une vidéo de la réunion. </td></tr>
<tr><td> Compte </td><td> Traitez l&#39;enregistrement et la connexion des utilisateurs. </td></tr>
<tr><td> Gérer </td><td> Les utilisateurs peuvent gérer leurs profils. </td></tr>
<tr><td> Admin </td><td> L&#39;administrateur peut gérer les utilisateurs, les politiques et les réclamations </td></tr>
<tr><th colspan="2"> Prestations de service </th></tr>
<tr><td> Email </td><td> Gérer la confirmation de l&#39;inscription par e-mail. </td></tr>
<tr><td> Message </td><td> Gérer la confirmation d&#39;inscription par SMS. </td></tr>
</table>
<hr /><h2> Conception de WorkflowApp </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>
<p> L&#39;état du flux de travail pour une réunion spécifique est conservé dans son enregistrement de réunion dans la base de données. Chacun des composants de workflow fonctionne indépendamment. Ils sont chacun appelés à tour de rôle pour vérifier le travail disponible. Chaque composant interrogera la base de données pour les réunions correspondant à leurs critères de travail disponible. Si du travail est trouvé, ils l&#39;exécuteront et mettront à jour l&#39;état de la réunion dans la base de données. </p><p> Afin de construire un système robuste, capable de récupérer des défaillances, nous devrons traiter les étapes du flux de travail comme des "transactions". Une transaction se termine entièrement ou pas du tout. S&#39;il y a des échecs irrécupérables pendant une étape de traitement, l&#39;état de cette réunion revient au dernier état valide. Le code n&#39;implémente pas actuellement de transactions. (Problème Gitub à suivre) </p><p> Un pseudo code est donné ci-dessous pour les composants </p>
<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Pour toutes les entités gouvernementales du système </li>
<ul>
<li> Vérifier le ou les horaires des réunions à récupérer </li>
<li> Récupérer un fichier d&#39;enregistrement ou de transcription </li>
<li> Placer le fichier dans le dossier DATAFILES \ Received </li>
</ul>
<li> Les fichiers peuvent également être placés dans le dossier Reçu par téléchargement par l&#39;utilisateur. </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li> Pour les fichiers dans DATAFILES \ Received et l&#39;enregistrement de base de données n&#39;existe pas: </li>
<ul>
<li> Déterminer le type de fichier </li>
<li> Créer un enregistrement de base de données </li>
<li> définir l&#39;état = reçu, approuvé = faux </li>
<li> Envoyer un message au (x) responsable (s): "Reçu" </li>
</ul>
</ul>
<li> TranscribeRecordings </li>
<ul>
<li> Pour les enregistrements avec sourcetype = enregistrement, statut = reçu, approuvé = vrai </li>
<ul>
<li> Créer un dossier de travail </li>
<li> définir le statut = transcription, approuvé = faux </li>
<li> Transcrire l&#39;enregistrement </li>
<li> définir le statut = transcrit, approuvé = faux </li>
<li> Envoyer un message au (x) gestionnaire (s): "Transcrit" </li>
</ul>
</ul>
<li> ProcessTranscripts </li>
<ul>
<li> Pour les transcriptions avec sourcetype = transcription, status = reçu, approuvé = vrai </li>
<ul>
<li> Créer un dossier de travail </li>
<li> définir le statut = traitement, approuvé = faux </li>
<li> Transcription du processus </li>
<li> définir l&#39;état = traité, approuvé = faux </li>
<li> Envoyer un message au (x) gestionnaire (s): "Processed" </li>
</ul>
</ul>
<li> Relecture </li>
<ul>
<li> Pour les enregistrements avec statut = transcrit / approuvé = vrai </li>
<ul>
<li> Créer un dossier de travail </li>
<li> définir le statut = relecture, approuvé = faux </li>
<li> La relecture manuelle aura désormais lieu </li>
</ul>
<li> Pour les enregistrements avec status = relecture </li>
<ul>
<li> Vérifiez si la relecture semble terminée. Si c&#39;est le cas: </li>
<li> définir l&#39;état = relecture, approuvé = faux </li>
<li> envoyer un message au (x) gestionnaire (s): "Relire" </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li> Pour les enregistrements avec statut = relecture, approuvé = vrai OU pour les transcriptions avec statut = traité, approuvé = vrai </li>
<ul>
<li> Créer un dossier de travail </li>
<li> définir l&#39;état = marquage, approuvé = faux </li>
<li> Le marquage manuel aura désormais lieu </li>
</ul>
</ul>
<ul>
<li> Pour les transcriptions avec status = tagging </li>
<ul>
<li> Vérifiez si le marquage semble terminé. Si c&#39;est le cas: </li>
<li> définir le statut = balisé, approuvé = faux </li>
<li> envoyer un message au (x) gestionnaire (s): "Tagged" </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Pour les réunions avec status = tagué, approuvé = vrai 
<ul>
<li> définir l&#39;état = chargement, approuvé = faux </li>
<li> charger le contenu de la réunion dans la base de données </li>
<li> définir l&#39;état = chargé, approuvé = faux </li>
<li> Envoyer un message au (x) gestionnaire (s): "Loaded" </li>
</ul>
</ul>
</ul><hr /><h2> Secrets des utilisateurs </h2><p> Lorsque vous clonez le référentiel govmeeting de Github, vous obtenez tout sauf le dossier "SECRETS". Ce dossier se trouve en dehors du référentiel. Il contient les informations "secrètes" suivantes: </p>
<ul>
<li> ClientId et ClientSecret pour le service d&#39;autorisation externe de Google. </li>
<li> SiteKey et Secret pour le service Google ReCaptcha. </li>
<li> Informations d&#39;identification pour Google Cloud Platform. </li>
<li> Chaîne de connexion à la base de données. </li>
<li> Nom d&#39;utilisateur et mot de passe administrateur. </li>
</ul><p> Le dossier SECRETS peut contenir quatre fichiers. </p>
<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> appsettings.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul><p> TranscribeAudio.json contient les informations d&#39;identification de Google Cloud Platform. Chacun des trois autres fichiers peut contenir des paramètres pour chacun des autres secrets. appsettings.Production.json doit contenir tous les paramètres de production. Quels que soient les paramètres contenus dans ces fichiers, ils remplaceront ceux qui se trouvent dans Server / WebApp / app.settings.json. Ce fichier est inclus dans le référentiel. </p><p> Si vous souhaitez que votre ordinateur local ait accès aux services Google, vous devez créer un dossier local "../SECRETS par rapport à l&#39;emplacement du référentiel. Ensuite, vous pouvez par exemple ajouter un fichier" appsettings.Development. json ", qui contient les clés que vous obtenez auprès de Google. Voir: <a href="home#google-api-keys">Google API Keys</a> </p><hr /><h1> Documentation </h1><p> À l&#39;origine, cette documentation était conservée dans les pages Github Wiki. Mais il a été décidé de déplacer les pages dans le projet principal lui-même, pour deux raisons: </p>
<ul>
<li> Vous ne pouvez pas faire une demande Pull pour des modifications sur les pages Wiki Github. Il est donc difficile pour les membres de la communauté de modifier la documentation. </li>
<li> La documentation restera plus probablement synchronisée avec le code si elle est avec le code dans le même référentiel. Un seul PR pour les modifications de code peut inclure les modifications de documentation qui lui sont associées. </li>
</ul><p> La documentation est écrite dans Markdown et située dans Frontend / ClientApp / src / app / assets / docs. </p>
</markdown>
<p> &lt;/mat-card&gt; </p>
