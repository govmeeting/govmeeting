<h1> Gestisci nuove trascrizioni </h1>
<p> Alcune città producono trascrizioni di incontri. Questo ci consente di saltare da soli la trascrizione dell&#39;incontro. Ma presenta un problema diverso. Le trascrizioni non saranno in un formato standard. </p>

<p> Il nostro software dovrà: </p>

<ul>
<li> Estrarre le informazioni. </li>
<li> Aggiungi tag che consentono di utilizzare facilmente le informazioni. </li>
</ul>
<p> Le informazioni normalmente in una trascrizione, che vogliamo estrarre sono: </p>

<ul>
<li> Informazioni sulla riunione: ora, luogo, se si tratta di una riunione speciale. </li>
<li> Funzionari presenti </li>
<li> Intestazioni di sezione </li>
<li> Il nome di ogni oratore e cosa hanno detto. </li>
</ul>
<p> Se non sono presenti intestazioni di sezione, il software dovrebbe essere abbastanza intelligente da determinare dove iniziano le sezioni comuni: </p>

<ul>
<li> Chiamata di ruolo </li>
<li> Invocazione </li>
<li> Rapporti del comitato </li>
<li> Introduzione di fatture </li>
<li> risoluzioni </li>
<li> Commento pubblico </li>
</ul>
<p> Dobbiamo vedere quanto bene possiamo anche estrarre i risultati delle votazioni su progetti di legge e risoluzioni. A volte, i risultati sono indicati da frasi come "Gli ayes ce l&#39;hanno". Altre volte, viene preso un voto formale in cui il nome di ciascun funzionario viene letto ad alta voce e la persona risponde con "sì" o "no". </p>

<p> Le informazioni superflue devono essere rimosse. Ad esempio: ripetizione di intestazioni o piè di pagina, numeri di riga e numeri di pagina. </p>

<p> Si spera che sia possibile scrivere un codice generale in grado di estrarre informazioni dalla nuova trascrizione che non ha mai fatto. Tuttavia, fino ad allora, sarà necessario scrivere un nuovo codice per gestire casi specifici. </p>

<p> Dato che normalmente sono solo le città più grandi a produrre trascrizioni: </p>

<ul>
<li> Il più delle volte ci occuperemo delle registrazioni delle riunioni. </li>
<li> In una città più grande, ci sono più probabili programmatori di computer disponibili in grado di scrivere tale codice. </li>
</ul>
<p> Potremmo creare un meccanismo plug-in che consenta di aggiungere moduli che eseguano l&#39;estrazione. Potremmo consentire ai plugin di essere scritti in molte lingue diverse: Python, Java, PHP, Ruby - in aggiunta alle lingue in cui il sistema è attualmente scritto: Typescript e C #. </p>

<p> Attualmente il software gestisce solo un caso, Philadelphia, Pennsylvania, Stati Uniti. La libreria del progetto "Backend \ ProcessMeetings \ ProcessTranscripts_lib" contiene codice per l&#39;elaborazione delle trascrizioni. </p>

<p> La classe "Specific_Philadelphia_PA_USA" chiama alcune routine di uso generale per elaborare trascrizioni per Philadelphia. </p>

<p> Esiste una classe di stub "Specific_Austin_TX_USA" destinata al processo di una trascrizione di Austin, TX. Forse qualcuno vorrebbe prendere una pugnalata per completare questo codice. C&#39;è una trascrizione di prova nella cartella Testdata. Ma è probabilmente meglio ottenere le ultime notizie dal loro sito Web: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Modifica del dashboard client </h1><h2> Aggiungi una scheda per la nuova funzionalità </h2>
<ul>
<li> Alla richiesta di un terminale, passare alla cartella: FrontEnd / ClientApp </li>
<li> Immettere: ng genera componente your-feature </li>
<li> Aggiungi la tua funzionalità ai file in: FrontEnd / ClientApp / src / app / your-feature </li>
<li> Inserisci un nuovo elemento gm-small-card o gm-large-card in app / dash-main / dash-main.html. </li>
<li> Modifica l&#39;icona, il colore dell&#39;icona, il titolo, ecc. Dell&#39;elemento della carta. </li>
<li> Se è necessario accedere al nome della posizione e dell&#39;agenzia attualmente selezionate nel controller: 
<ul>
<li> Aggiungi la posizione e gli attributi di input dell&#39;agenzia all&#39;elemento della funzione </li>
<li> Aggiungi la posizione e le proprietà dell&#39;agenzia @Input nel controller. </li>
</ul></li>
</ul>
<p> (Vedi gli altri esempi in dash-main.html) </p>
<h2> Riorganizza le carte </h2><ol>
<li> Apri il file: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Cambia le posizioni delle carte cambiando la posizione degli elementi gm-small-card o gm-large-card in questo file. </li></ol><h1> Registrazione </h1>
<p> I file di registro per WebApp e WorkflowApp si trovano nella cartella "registri" nella radice della soluzione. </p>

<ul>
<li> "nlog-all- (date) .log" contiene tutti i messaggi di registro incluso il sistema. </li>
<li> Il file "nlog-own- (date) .log" contiene solo i messaggi dell&#39;applicazione. </li>
</ul>
<p> Nella parte superiore di molti file dei componenti in ClientApp, viene definito un const "NoLog". Cambia il suo valore da vero a falso per attivare la registrazione della console solo per quel componente. </p>
<h1> Costruisci script </h1>
<p> Gli script di build di Powershell sono disponibili in Utilità / PsScripts </p>
<h2> BuildPublishAndDeploy.ps1 </h2>
<p> Questo script chiama molti degli altri script per creare una versione di produzione e distribuirla. </p>

<ul>
<li> Build-ClientApp.ps1: crea versioni di produzione di ClientApp </li>
<li> Publish-WebApp.ps1: crea una cartella "pubblica" di WebApp </li>
<li> Copy-ClientAssets.ps1 - Copia gli asset ClientApp nella cartella wwwroot di WebApp </li>
<li> Deploy-PublishFolder.ps1: distribuisce la cartella di pubblicazione su un host remoto </li>
<li> Creare il file README.md per Gethub dai file della documentazione </li>
</ul>
<p> Deploy-PublishFolder.ps1 distribuisce il software su govmeeting.org, utilizzando FTP. Le informazioni di accesso FTP si trovano nel file appsettings.Development.json nella cartella SECRETS. Contiene FTP e altri segreti da utilizzare nello sviluppo. Di seguito è riportato il formato di questo file: </p>
<pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-id", "ClientSecret": "your-client-secret" } }, "ReCaptcha": { "SiteKey": "your-site-key", "Secret": "your-secret" }, "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } }</code> </pre>