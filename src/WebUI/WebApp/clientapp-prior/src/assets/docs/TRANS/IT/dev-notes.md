<h1> Elabora nuovi formati di trascrizione </h1>
<p> L&#39;obiettivo finale è quello di scrivere codice che elaborerà qualsiasi formato di trascrizione. Ma fino ad allora, dobbiamo scrivere un codice personalizzato per gestire ogni nuovo formato. Quando avremo abbastanza campioni di diversi formati, saremo in grado di scrivere il codice generico. </p>

<p> Questi sono i passaggi per la gestione di nuovi formati di trascrizione: </p>

<ul>
<li>
<p> Ottieni una trascrizione di esempio di una riunione del governo come file pdf o di testo. </p>
</li>
<li>
<p> Denominare il file come segue: "country_state_county_m townsality_agency_language-code_date.pdf". (o .txt) Ad esempio: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Creare una nuova classe con l&#39;interfaccia "ISpecificFix" nel progetto "ProcessTranscripts_Lib". </p>
</li>
<li>
<p> Denominare la classe "country_state_county_m townsality_agency_language-code". Per esempio: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Implementare il metodo class: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix () riceve il testo della trascrizione esistente e restituisce il testo nel seguente formato: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Una volta completata questa classe, WorkflowApp elaborerà le nuove trascrizioni quando compaiono in "DATAFILES / RECEIVED". </p>

<p> Appunti: </p>

<p> Usiamo System.Reflection per creare un&#39;istanza della classe corretta in base al nome del file da elaborare. </p>

<p> Vedi la classe "USA_PA_Philadelphia_Philadelphia_CityCouncil_en" in ProcessTranscripts_Lib per un esempio. Puoi capire meglio cosa sta facendo questa classe osservando le tracce del file di registro nella "cartella di lavoro" che viene passata come argomento a Fix (). </p>

<p> Non estraiamo ora le seguenti informazioni, ma alla fine vorremmo farlo. </p>

<ul>
<li> Funzionari presenti </li>
<li> Fatture e risoluzioni introdotte </li>
<li> Risultati della votazione </li>
</ul>
<p> Austin, Texas - USA ha anche trascrizioni di incontri pubblici online. È stata creata una classe chiamata "USA_TX_TravisCounty_Austin_CityCouncil_en" in ProcessTranscripts_Lib. Ma il metodo Fix () non è stato implementato. Le trascrizioni possono essere ottenute dal loro sito Web: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Modifica la dashboard del client </h1><h2> Aggiungi una scheda per la nuova funzionalità </h2>
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
<p> Nella parte superiore di molti dei file dei componenti in ClientApp, viene definito un const "NoLog". Cambia il suo valore da vero a falso per attivare la registrazione della console solo per quel componente. </p>
<h1> Costruisci script </h1>
<p> Gli script di build di Powershell sono disponibili in Utilità / PsScripts </p>

<ul>
<li> BuildPublishAndDeploy.ps1 -Chiama gli altri script per creare una versione e distribuirla. </li>
<li> Build-ClientApp.ps1: crea versioni di produzione di ClientApp </li>
<li> Publish-WebApp.ps1: crea una cartella "pubblica" di WebApp </li>
<li> Copy-ClientAssets.ps1 - Copia gli asset ClientApp nella cartella wwwroot di WebApp </li>
<li> Deploy-PublishFolder.ps1: distribuisce la cartella di pubblicazione su un host remoto </li>
<li> Creare il file README.md per Gethub dai file della documentazione </li>
</ul>
<p> Deploy-PublishFolder.ps1 distribuisce il software su govmeeting.org, utilizzando FTP. Le informazioni di accesso FTP si trovano nel file appsettings.Development.json nella cartella SECRETS. Contiene FTP e altri segreti da utilizzare nello sviluppo. Di seguito è la sezione di questo file utilizzato da FTP: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
