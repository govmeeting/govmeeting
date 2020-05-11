<p><a name="Contents"></a></p><h1> Contenu </h1>
<ul>
<li> <a href="about?id=setup#InstallTools">Installer les outils et cloner le référentiel</a> </li>
<li> <a href="about?id=setup#DevelopVsCode">Développer avec VsCode</a> </li>
<li> <a href="about?id=setup#DevelopVS">Développer avec Visual Studio</a> </li>
<li> <a href="about?id=setup#DevelopOther">Développer sur d&#39;autres plateformes</a> </li>
<li> <a href="about?id=setup#Database">Base de données</a> </li>
<li> <a href="about?id=setup#GoogleCloud">Compte Google Cloud Platform</a> </li>
<li> <a href="about?id=setup#GoogleApi">Clés API Google</a> </li>
</ul><p> Ces pages de documentation se trouvent dans FrontEnd / ClientApp / src / app / assets / docs. Veuillez y apporter des corrections et émettre une <a href="https://github.com/govmeeting/govmeeting">demande d&#39;extraction sur Gitub.</a> </p><hr /><p><a name="InstallTools"></a></p><h1> Installer les outils et cloner le référentiel <br/></h1><p> <a href="about?id=setup#Contents">[Contenu]</a> </p>
<ul>
<li> Installez git. <a href="https://gitforwindows.org">Git pour Windows</a> , <a href="https://git-scm.com/download/mac">Git pour Mac</a> </li>
<li> Installez <a href="https://nodejs.org/en/download/">Node.js.</a> </li>
<li> Installez <a href="https://dotnet.microsoft.com/download">.Net Core SDK.</a> </li>
<li> "Fork" le projet sur github </li>
<li> Clonez le projet localement </li>
<li> Créez un dossier frère dans le référentiel cloné nommé "SECRETS" </li>
</ul><p> Le dossier "SECRETS" est destiné aux clés et mots de passe qui ne sont pas stockés dans le référentiel public. Ceux-ci seraient nécessaires pour exécuter les services Google API. </p><hr /><p><a name="DevelopVsCode"></a></p><h1> Développer avec VsCode <br/></h1><p> <a href="about?id=setup#Contents">[Contenu]</a> </p><h2> Installer VsCode </h2>
<ul>
<li> Installez <a href="https://code.visualstudio.com/download">Visual Studio Code</a> et démarrez-le. </li>
<li> Ouvrez les extensions du panneau latéral gauche et installez: 
<ul>
<li> «Débogueur pour Chrome» par Microsoft </li>
<li> "C
# pour Visual Studio Code" par Microsoft </li>
<li> «SQL Server (mssql)» par Microsoft </li>
<li> "Todo Tree" par Gruntfuggly - affiche les lignes TODO dans le code (facultatif) </li>
<li> "Powershell" par Microsoft - pour le débogage des scripts de génération Powershell (facultatif) </li>
</ul></li>
</ul><h2> Déboguer / exécuter ClientApp et WebApp </h2>
<ul>
<li> Ouvrez le dossier Govmeeting dans VsCode </li>
<li> Ouvrez un volet terminal dans VsCode </li>
<li> cd FrontEnd / ClientApp </li>
<li> installation de npm </li>
<li> npm start </li>
<li> Dans le panneau de débogage, définissez la configuration de lancement "WebApp & ClientApp-W" </li>
<li> Appuyez sur F5 (débogage) ou Ctrl-F5 (exécution sans débogage) </li>
</ul><p> ClientApp s&#39;ouvrira dans un navigateur. </p>
<ul>
<li> Cliquez sur l&#39;un des éléments de menu "À propos" pour voir la documentation. </li>
<li> Cliquez sur l&#39;élément du menu de localisation "Boothbay Harbor". Vous verrez le tableau de bord ouvert pour cet emplacement. </li>
</ul><p> Pour vérifier que ClientApp appelle l&#39;API WebApp pour récupérer des données. </p>
<ul>
<li> Cliquez sur "Relire la transcription". Vous verrez un volet vidéo et un texte transcrit. Cliquez sur le bouton de lecture vidéo. </li>
<li> Cliquez sur "Ajouter des balises à la transcription". Vous verrez une transcription d&#39;une réunion à étiqueter. </li>
<li> Cliquez sur "Afficher la dernière réunion". Vous verrez une transcription complète à visualiser. </li>
</ul><p> La plupart des autres cartes de tableau de bord n&#39;appellent pas WebApp mais renvoient des données de test. </p><p> ClientApp est servi par le serveur webpack-dev démarré avec "npm start". WebApp utilise le serveur Kestrel inclus dans Asp.Net Core. Le serveur Kestrel répond aux appels d&#39;API Web. Mais il envoie des requêtes clientApp internes au serveur webpack-dev-server. </p><h2> Déboguer / exécuter ClientApp de façon autonome </h2>
<ul>
<li> Dans app.module.ts, changez "isAspServerRunning" de true en false. </li>
<li> npm start </li>
<li> Dans le panneau de débogage, définissez la configuration de lancement "ClientApp" </li>
<li> Appuyez sur F5 (débogage) ou Ctrl-F5 (exécution sans débogage) </li>
</ul><p> Lorsque "isAspServerRunning" est défini sur false, les services de stub sont utilisés, au lieu d&#39;appeler l&#39;API WebApp. Ceci est utile lorsque nous ne modifions que du code dans ClientApp. </p><h2> Déboguer / exécuter WorkflowApp </h2>
<ul>
<li> Dans le panneau de débogage, définissez la configuration de lancement "WorkflowApp" </li>
<li> Appuyez sur F5 (débogage) ou Ctrl-F5 (exécution sans débogage) </li>
</ul><p> Lorsque WorkflowApp le démarre: </p>
<ul>
<li> Copie certains fichiers de test dans le dossier Datafles / RECEIVED: un fichier PDF de transcription et un fichier MP4 d&#39;enregistrement. </li>
<li> Traite le fichier PDF de transcription et crée un fichier JSON prêt à être balisé. </li>
<li> Traitez le fichier MP4 d&#39;enregistrement en le transcrivant dans le cloud et créez un fichier JSON prêt à être relu. </li>
</ul><p> Les résultats peuvent être trouvés dans DATAFILES / PROCESSING. Cependant, vous devrez d&#39;abord configurer un <a href="about?id=setup#GoogleCloud">compte Google Cloud</a> , pour que l&#39;enregistrement soit transcrit. </p><hr /><p><a name="DevelopVS"></a></p><h1> Développer avec Visual Studio <br/></h1><p> <a href="about?id=setup#Contents">[Contenu]</a> </p>
<ul>
<li> Installez la version gratuite de <a href="https://visualstudio.microsoft.com/free-developer-offers/">Visual Studio Community Edition.</a> </li>
<li> Lors de l&#39;installation, sélectionnez à la fois les charges de travail «ASP.NET» et «Bureau .NET». </li>
<li> Installer les extensions: (toutes par Mads Kristensen) 
<ul>
<li> "NPM Task Runner" </li>
<li> "Command Task Runner" </li>
<li> "Editeur Markdown" </li>
</ul></li>
<li> Ouvrez le fichier de solution "govmeeting.sln" </li>
</ul><h2> Déboguer / exécuter ClientApp et WebApp </h2>
<ul>
<li> Dans Task Runner Explorer (ClientApp): 
<ul>
<li> exécuter "installer" </li>
<li> exécuter "démarrer" </li>
</ul></li>
<li> Définissez le projet de démarrage sur "WebApp" </li>
<li> Appuyez sur F5 (débogage) ou Ctrl-F5 (exécution sans débogage) </li>
<li> WebApp s&#39;exécutera et un navigateur s&#39;ouvrira, affichant ClientApp. </li>
</ul><p> REMARQUE: il y a un problème avec la définition des points d&#39;arrêt dans Angular ClientApp dans Visual Studio. Voir: <a href="https://github.com/govmeeting/govmeeting/issues/80">Github numéro 80</a> </p><h2> Debug WorkflowApp </h2>
<ul>
<li> Ouvrez le panneau de débogage. </li>
<li> Définissez le projet de démarrage sur "WorkflowApp" </li>
<li> Appuyez sur F5 (débogage) ou Ctrl-F5 (exécution sans débogage) </li>
</ul><p> Remarque: Voir les notes pour WorkflowApp sous "Visual Studio Code" </p><hr /><p><a name="DevelopOther"></a></p><h1> Développer sur d&#39;autres plateformes <br/></h1><p> <a href="about?id=setup#Contents">[Contenu]</a> </p><p> Dans votre profil, définissez la variable d&#39;environnement, ASPNETCORE_ENVIRONMENT, sur "Développement". Ceci est utilisé par WebApp et WorkflowApp. </p><h2> Générez et exécutez ClientApp </h2><p> Exécuter: </p>
<ul>
<li> cd Frontend / ClientApp </li>
<li> installation de npm </li>
<li> npm start </li>
</ul><p> Accédez à localhost: 4200 dans votre navigateur. L&#39;application cliente se charge. Certaines fonctionnalités ne fonctionneront pas tant que WebApp n&#39;est pas en cours d&#39;exécution. </p><h2> Créez et exécutez WebApp avec ClientApp </h2><p> Exécuter: </p>
<ul>
<li> (faites ci-dessus: "Build & start ClientApp") </li>
<li> cd ../../Backend/WebApp </li>
<li> dotnet build webapp.csproj </li>
<li> dotnet run bin / debug / dotnet2.2 / webapp.dll </li>
</ul><p> Accédez à localhost: 5000 dans votre navigateur. L&#39;application cliente se charge. </p><h2> Créer et exécuter ClientApp de façon autonome </h2>
<ul>
<li> Dans app.module.ts, changez "isAspServerRunning" de true en false. </li>
<li> (faites ci-dessus: "Build & start ClientApp") </li>
</ul><h2> Créer et exécuter WorkflowApp </h2><p> Exécuter: </p>
<ul>
<li> cd Backend / WorkflowApp </li>
<li> dotnet build workflowapp.csproj </li>
<li> dotnet run bin / debug / dotnet2.0 / workflowapp.dll </li>
</ul><p> Remarque: Voir les notes pour WorkflowApp sous "Visual Studio Code" </p><!-- END OF README SECTION --><hr /><p><a name="Database"></a></p><h1> Base de données <br/></h1><p> <a href="about?id=setup#Contents">[Contenu]</a> </p><p> Vous n&#39;aurez peut-être pas besoin d&#39;installer et de configurer la base de données pour effectuer le développement. Il existe des talons de test qui remplacent l&#39;appel de la base de données. Voir «Bouts de test» ci-dessous. </p><h2> Installer le fournisseur </h2><p> Si vous utilisez Visual Studio ou Visual Studio Code, le fournisseur Sql Server Express LocalDb est déjà installé. Sinon, effectuez "Installation du fournisseur LocalDb" ci-dessous. </p><h3> Installation du fournisseur LocalDb </h3><p> Accédez à <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">Sql Server Express.</a> Pour Windows, téléchargez l&#39;édition spécialisée "Express" de SQL Server. Pendant l&#39;installation, choisissez "Personnalisé" et sélectionnez "LocalDb". </p><p> LocalDb est également disponible pour MacOs et Linux. Si vous l&#39;installez pour l&#39;une ou l&#39;autre plate-forme, veuillez mettre à jour ce document avec les étapes et faire une demande de pull. </p><h3> Autres fournisseurs </h3><p> Outre LocalSb, EF Core prend en charge d&#39; <a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli">autres fournisseurs</a> que vous pouvez utiliser pour le développement, notamment SqlLite. Vous devrez modifier la configuration de DbContext dans startup.cs et la chaîne de connexion dans appsettings.json. </p><h2> Créer un schéma de base de données </h2><p> La base de données est construite via la fonctionnalité "code first" d&#39;Entity Framework Core. Il examine les classes C# dans le modèle de données et crée automatiquement toutes les tables et relations. Il y a deux étapes: (1) Créer le code "migrations" pour effectuer la mise à jour et (2) exécuter la mise à jour. </p>
<ul>
<li> cd Backend / WebApp </li>
<li> dotnet ef migrations add initial --project .. \ Database \ DatabaseAccess_Lib </li>
<li> mise à jour de la base de données dotnet ef --projet .. \ Database \ DatabaseAccess_Lib </li>
</ul><h2> Explorez la base de données créée </h2><h3> Dans VsCode </h3><p> Ajoutez ce qui suit à votre settings.json utilisateur dans VsCode: </p><pre> <code> "mssql.connections": [ { "server": "(localdb)\\mssqllocaldb", "database": "Govmeeting", "authenticationType": "Integrated", "profileName": "GMProfile", "password": "" } ],</code> </pre>
<ul>
<li> Appuyez sur ctrl-alt-D ou appuyez sur l&#39;icône Sql Server sur la marge gauche. </li>
<li> Ouvrez la connexion GMProfile pour afficher et travailler avec des objets de base de données. </li>
<li> Ouvrez "Tables". Vous devriez voir toutes les tables créées lorsque vous avez créé le schéma ci-dessus. Cela inclut les tables AspNetxxxx pour l&#39;autorisation et les tables pour le modèle de données Govmeeting. </li>
</ul><h3> Dans Visual Studio </h3>
<ul>
<li> Accédez à l&#39;élément de menu: Affichage -&gt; Explorateur d&#39;objets SQL Server. </li>
<li> Développez SQL Server -&gt; (localdb) \ MSSQLLocalDb -&gt; Bases de données -&gt; Govmeeting </li>
<li> Ouvrez "Tables". Vous devriez voir toutes les tables créées lorsque vous avez créé le schéma ci-dessus. Cela inclut les tables AspNetxxxx pour l&#39;autorisation et les tables pour le modèle de données Govmeeting. </li>
</ul><h3> Autres plateformes </h3><p> Il existe la plateforme multiplateforme et open source <a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha">SQL Operations Studio,</a> "un outil de gestion des données qui permet de travailler avec SQL Server, Azure SQL DB et SQL DW à partir de Windows, macOS et Linux". Vous pouvez télécharger gratuitement <a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha">SQL Operations Studio ici.</a> </p><p> Si vous utilisez cet outil ou un autre pour explorer les bases de données SQL Server, veuillez mettre à jour ces instructions. </p><h2> Bouts de test </h2><p> Le code pour stocker / récupérer les données de transcription dans la base de données n&#39;est pas encore écrit. Par conséquent, DatabaseRepositories_Lib utilise à la place des données de test statiques. Dans WebApp / appsettings.json, la propriété "UseDatabaseStubs" est définie sur "true", lui indiquant d&#39;appeler les routines de talon. </p><p> Cependant, le code d&#39;enregistrement et de connexion utilisateur dans WebApp utilise la base de données. Il accède aux tables d&#39;authentification des utilisateurs Asp.Net. WebApp authentifie les appels d&#39;API de ClientApp en fonction de l&#39;utilisateur actuellement connecté. </p><p> Vous pouvez utiliser la valeur de pré-processeur "NOAUTH" dans WebApp pour contourner l&#39;authentification. Utilisez l&#39;une de ces méthodes: </p>
<ul>
<li> Dans FixasrController.cs ou AddtagsController.cs, décommentez la ligne "#if NOAUTH" en haut du fichier. </li>
<li> Pour le désactiver pour tous les contrôleurs, ajoutez ceci à WebApp.csproj: </li>
</ul><pre> <code> &lt;PropertyGroup Condition="&#39;$(Configuration)|$(Platform)&#39;==&#39;Debug|AnyCPU&#39;&gt; &lt;DefineConstants&gt;NOAUTH&lt;/DefineConstants&gt; &lt;/PropertyGroup&gt;</code> </pre>
<ul>
<li> Dans Visual Studio, accédez aux pages de propriétés WebApp -&gt; Build -&gt; et entrez NOAUTH dans la zone "Symboles de compilation conditionnelle". </li>
</ul><hr /><p><a name="GoogleCloud"></a></p><h1> Compte Google Cloud Platform <br/></h1><p> <a href="about?id=setup#Contents">[Contenu]</a> </p><p> Pour utiliser les API Google Speech pour la conversion de la parole en texte, vous avez besoin d&#39;un compte Google Cloud Platform (GCP). Pour la plupart des travaux de développement dans Govmeeting, vous pouvez utiliser les données de test existantes. Mais si vous voulez transcrire de nouveaux enregistrements, vous aurez un GCP. L&#39;API Google est capable de transcrire des enregistrements dans plus de 120 langues et variantes. </p><p> Google offre aux développeurs un compte gratuit qui comprend un crédit (actuellement 300 $). Le coût actuel d&#39;utilisation de l&#39;API Speech est gratuit pour jusqu&#39;à 60 minutes de conversion par mois. Après cela, le coût du "modèle amélioré" (ce dont nous avons besoin) est de 0,009 $ par 15 secondes. (2,16 $ par heure) </p>
<ul>
<li><p> Ouvrez un compte avec <a href="https://cloud.google.com/free/">Google Cloud Platform</a> </p></li>
<li><p> Accédez au <a href="http://console.cloud.google.com">tableau de bord Google Cloud</a> et créez un projet. </p></li>
<li><p> Accédez à la <a href="http://console.developers.google.com">console du développeur Google</a> et activez les API Speech & Cloud Storage </p></li>
<li><p> Générez des informations d&#39;identification de "compte de service" pour ce projet. Cliquez sur Credentials dans la console du développeur. </p></li>
<li><p> Accordez à ce compte les autorisations "Editeur" sur le projet. Cliquez sur le compte. Sur la page suivante, cliquez sur Autorisations. </p></li>
<li><p> Téléchargez le fichier JSON d&#39;informations d&#39;identification. </p></li>
<li><p> Placez le fichier dans le dossier <code>SECRETS</code> que vous avez créé lorsque vous avez cloné le référentiel. </p></li>
<li><p> Renommez le fichier <code>TranscribeAudio.json</code> . </p></li>
</ul><p> REMARQUE: les étapes ci-dessus peuvent avoir légèrement changé. Si oui, veuillez mettre à jour ce document. </p><h2> Tester la transcription de la parole en texte </h2>
<ul>
<li><p> Définissez le projet de démarrage dans Visual Studio sur <code>Backend/WorkflowApp</code> . Appuyez sur F5. </p></li>
<li><p> Copiez (ne déplacez pas) l&#39;un des exemples de fichiers MP4 de testdata vers DATAFILES / RECEIVED. </p></li>
</ul><p> Le programme va maintenant reconnaître qu&#39;un nouveau fichier est apparu et commencer à le traiter. Le fichier MP4 sera déplacé vers "TERMINE" une fois terminé. Vous verrez les résultats dans des sous-dossiers, qui ont été créés dans le répertoire "DATAFILES". </p><p> Dans appsettings.json, il existe une propriété "RecordingSizeForDevelopment". Il est actuellement réglé sur "180". Cela provoque la routine de transcription dans ProcessRecording_Lib pour traiter uniquement les 180 premières secondes de l&#39;enregistrement. </p><hr /><p><a name="GoogleApi"></a></p><h1> Clés API Google <br/></h1><p> <a href="about?id=setup#Contents">[Contenu]</a> </p><p> Vous aurez besoin de ces clés si vous souhaitez utiliser ou travailler sur certaines fonctionnalités du processus d&#39;enregistrement et de connexion. </p>
<ul>
<li> Les clés ReCaptcha sont nécessaires pour utiliser ReCaptcha lors de l&#39;enregistrement de l&#39;utilisateur. Ils peuvent être obtenus auprès de <a href="https://developers.google.com/recaptcha/">Google reCaptcha</a> . </li>
<li> Les informations d&#39;identification OAuth 2.0 sont utilisées pour se connecter à un utilisateur externe sans que l&#39;utilisateur ait besoin de créer un compte personnel sur le site. Accédez à la <a href="https://console.developers.google.com/">console Google API</a> pour obtenir des informations d&#39;identification telles qu&#39;un ID client et un secret client. </li>
</ul><p> Créez un fichier nommé "appsettings.Development.json" dans le dossier "SECRETS". Il doit contenir les clés que vous venez d&#39;obtenir: </p><pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-Id", "ClientSecret": "your-client-secret" } }, "ReCaptcha:SiteKey": "your-site-key", "ReCaptcha:Secret": "your-secret" }</code> </pre><hr /><h2> Testez reCaptcha </h2>
<ul>
<li> Exécutez le projet WebApp. </li>
<li> Cliquez sur "S&#39;inscrire" en haut à droite. </li>
<li> L&#39;option reCaptcha devrait apparaître. </li>
</ul><hr /><h2> Tester l&#39;authentification Google </h2>
<ul>
<li> Exécutez le projet WebApp. </li>
<li> Cliquez sur "Connexion" en haut à droite. </li>
<li> Sous "Utiliser un autre service pour vous connecter", choisissez "Google". </li>
</ul>