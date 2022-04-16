<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle"> Design </mat-card-title>
<markdown ngPreserveWhitespaces>

<p> Gli schemi seguenti mostrano l&#39;interazione tra i componenti software. </p>

<ul>
<li>
<p> ClientApp è un&#39;applicazione a pagina singola Angular Typescript che viene eseguita nel browser. Fornisce l&#39;interfaccia utente. </p>
</li>
<li>
<p> WebApp è un&#39;applicazione <a href="https://github.com/aspnet/home">Asp.Net Core</a> C# che viene eseguita sul server. Risponde alle chiamate WebApi. </p>
</li>
<li>
<p> WorkflowApp è un&#39;applicazione <a href="https://github.com/dotnet/core">DotNet Core</a> C# che viene eseguita sul server. Esegue l&#39;elaborazione in batch di registrazioni e trascrizioni. Potrebbe anche essere convertito in una libreria che viene eseguita come parte del processo WebApp. </p>
</li>
<li>
<p> Gli altri componenti del server sono librerie DotNet Core C #. Sono utilizzati sia da WebApp che da WorkflowApp. </p>
</li>
</ul><hr /><h2> Sistema di design </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

<p> I componenti nel diagramma sopra sono: </p>

<table style="width:100%">
<tr><th colspan="2"> applicazioni </th></tr>
<tr><td> ClientApp </td><td> SPA angolare </td></tr>
<tr><td> WebApp </td><td> Processo del server Web Asp.Net </td></tr>
<tr><td> WorkflowApp </td><td> Processo di controllo del server del flusso di lavoro </td></tr>
<tr><th colspan="2"> biblioteche </th></tr>
<tr><td> GetOnlineFiles </td><td> Recupera trascrizioni e registrazioni online </td></tr>
<tr><td> ProcessRecording </td><td> Estrai e trascrivi l&#39;audio. Crea segmenti di lavoro. </td></tr>
<tr><td> ProcessTranscript </td><td> Trasforma le trascrizioni non elaborate </td></tr>
<tr><td> LoadDatabase </td><td> Popolare il database con i dati della trascrizione completata </td></tr>
<tr><td> OnlineAccess </td><td> Routine per recuperare file da siti remoti </td></tr>
<tr><td> GoogleCloudAccess </td><td> Routine per accedere ai servizi Google Cloud </td></tr>
<tr><td> FileDataRepositories </td><td> Archivia e ottieni i dati del file di lavoro JSON </td></tr>
<tr><td> DatabaseRepositories </td><td> Archivia e recupera i dati del modello dal database </td></tr>
<tr><td> DatabaseAccess </td><td> Accedi al database usando Entity Framework </td></tr>
</table>
<hr /><h2> Progettazione di ClientApp </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

<p> La struttura di ClientApp è mostrata al meglio dalla sua struttura a componenti angolari </p>

<table style="width:100%">
<tr><th colspan="2"> Componenti dell&#39;app </th></tr>
<tr><td> Intestazione </td><td> Intestazione </td></tr>
<tr><td> Sidenav </td><td> Navigazione nella barra laterale </td></tr>
<tr><td> Pannello di controllo </td><td> Contenitore per componenti del cruscotto </td></tr>
<tr><td> Documentazione </td><td> Contenitore per pagine di documentazione </td></tr>
<tr><th colspan="2"> Componenti del cruscotto </th></tr>
<tr><td> Fixasr </td><td> Correggi il testo del riconoscimento vocale automatico </td></tr>
<tr><td> Aggiungi i tag </td><td> Aggiungi tag alle trascrizioni </td></tr>
<tr><td> ViewMeeting </td><td> Visualizza le trascrizioni completate </td></tr>
<tr><td> Problemi </td><td> Visualizza informazioni sui problemi </td></tr>
<tr><td> avvisi </td><td> Visualizza e imposta informazioni sugli avvisi </td></tr>
<tr><td> funzionari </td><td> Visualizza informazioni sui funzionari </td></tr>
<tr><td> (Altri)) </td><td> Altri componenti da implementare </td></tr>
<tr><th colspan="2"> Servizi </th></tr>
<tr><td> VirtualMeeting </td><td> Esegui riunione virtuale </td></tr>
<tr><td> Chiacchierare </td><td> Componente chat utente </td></tr>
</table>
<hr /><h2> WebApp Design </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

<p> Ognuna delle API Web è piccola e chiama i repository per inserire o ottenere dati dal database o dal filesystem. </p>

<table style="width:100%">
<tr><th colspan="2"> Controller </th></tr>
<tr><td> Fixasr </td><td> Salvare e ottenere la revisione della versione più recente della trascrizione. </td></tr>
<tr><td> Aggiungi i tag </td><td> Salva e ottieni la versione più recente della trascrizione taggata. </td></tr>
<tr><td> Viewmeeting </td><td> Ottieni l&#39;ultimo trnascript completato. </td></tr>
<tr><td> Govbodies </td><td> Salvare e ottenere i dati degli enti governativi registrati. </td></tr>
<tr><td> incontri </td><td> Salva e ottieni informazioni sulla riunione. </td></tr>
<tr><td> video </td><td> Guarda il video della riunione. </td></tr>
<tr><td> account </td><td> Elaborare la registrazione e l&#39;accesso dell&#39;utente. </td></tr>
<tr><td> Gestire </td><td> Gli utenti possono gestire i loro profili. </td></tr>
<tr><td> Admin </td><td> L&#39;amministratore può gestire utenti, politiche e reclami </td></tr>
<tr><th colspan="2"> Servizi </th></tr>
<tr><td> E-mail </td><td> Gestire la conferma dell&#39;email di registrazione. </td></tr>
<tr><td> Messaggio </td><td> Gestire la conferma della registrazione tramite messaggio di testo. </td></tr>
</table>
<hr /><h2> WorkflowApp Design </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

<p> Lo stato del flusso di lavoro per una riunione specifica viene mantenuto nel relativo record della riunione nel database. Ciascuno dei componenti del flusso di lavoro funziona in modo indipendente. Ciascuno viene chiamato a sua volta per verificare la disponibilità di lavoro. Ogni componente interrogherà il database per le riunioni che corrispondono ai propri criteri per il lavoro disponibile. Se viene trovato lavoro, lo eseguiranno e aggiorneranno lo stato della riunione nel database. </p>

<p> Al fine di costruire un sistema robusto, in grado di recuperare dagli errori, dovremo considerare i passaggi del flusso di lavoro come "transazioni". Una transazione viene completata completamente o per niente. Se si verificano errori irreversibili durante una fase di elaborazione, lo stato per quella riunione torna all&#39;ultimo stato valido. Il codice attualmente non implementa le transazioni. (Problema di Gitub da seguire) </p>

<p> Di seguito è riportato lo pseudo codice per i componenti </p>

<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Per tutte le entità governative nel sistema </li>
<ul>
<li> Controlla i programmi per le riunioni da recuperare </li>
<li> Recupera il file di registrazione o di trascrizione </li>
<li> Inserisci il file nella cartella DATAFILES \ Received </li>
</ul>
<li> I file possono anche essere inseriti nella cartella Ricevuti al caricamento dell&#39;utente. </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li> Per i file in File di dati \ Ricevuti e il record del database non esiste: </li>
<ul>
<li> Determina il tipo di file </li>
<li> Crea record di database </li>
<li> imposta stato = ricevuto, approvato = falso </li>
<li> Invia messaggio gestore: "Ricevuto" </li>
</ul>
</ul>
<li> TranscribeRecordings </li>
<ul>
<li> Per registrazioni con sourcetype = registrazione, status = ricevuto, approvato = vero </li>
<ul>
<li> Crea cartella di lavoro </li>
<li> set status = trascrizione, approvato = false </li>
<li> Trascrivi la registrazione </li>
<li> set status = trascritto, approvato = false </li>
<li> Invia messaggio gestore: "Trascritto" </li>
</ul>
</ul>
<li> ProcessTranscripts </li>
<ul>
<li> Per trascrizioni con sourcetype = trascrizione, status = ricevuto, approvato = vero </li>
<ul>
<li> Crea cartella di lavoro </li>
<li> set status = elaborazione, approvato = false </li>
<li> Trascrizione del processo </li>
<li> set status = elaborato, approvato = false </li>
<li> Invia messaggio gestore: "Elaborato" </li>
</ul>
</ul>
<li> ProofreadRecording </li>
<ul>
<li> Per registrazioni con stato = trascritto / approvato = vero </li>
<ul>
<li> Crea cartella di lavoro </li>
<li> set status = correzione di bozze, approvato = false </li>
<li> La correzione manuale ora avrà luogo </li>
</ul>
<li> Per registrazioni con status = correzione di bozze </li>
<ul>
<li> Controlla se la correzione di bozze sembra completa. Se è così: </li>
<li> set status = correzione di bozze, approvato = false </li>
<li> invia messaggio gestore (i): "Correzione bozze" </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li> Per registrazioni con status = correzione di bozze, approvato = vero O per trascrizioni con stato = elaborato, approvato = vero </li>
<ul>
<li> Crea cartella di lavoro </li>
<li> set status = tagging, approvato = false </li>
<li> La codifica manuale ora avrà luogo </li>
</ul>
</ul>
<ul>
<li> Per trascrizioni con status = tagging </li>
<ul>
<li> Controlla se la codifica appare completa. Se è così: </li>
<li> set status = taggato, approvato = falso </li>
<li> invia messaggio gestore (i): "Taggato" </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Per riunioni con stato = taggato, approvato = vero 
<ul>
<li> set status = caricamento, approvato = false </li>
<li> caricare i contenuti della riunione nel database </li>
<li> set status = caricato, approvato = false </li>
<li> Invia messaggio gestore: "Caricato" </li>
</ul>
</ul>
</ul><hr /><h2> Segreti dell&#39;utente </h2>
<p> Quando clonate il repository governativo da Github, ottenete tutto tranne la cartella "SECRETS". Questa cartella si trova all&#39;esterno del repository. Contiene le seguenti informazioni "segrete": </p>

<ul>
<li> ClientId e ClientSecret per il servizio di autorizzazione esterno di Google. </li>
<li> Chiave del sito e segreto per il servizio Google ReCaptcha. </li>
<li> Credenziali per la piattaforma Google Cloud. </li>
<li> Stringa di connessione al database. </li>
<li> Nome utente e password dell&#39;amministratore. </li>
</ul>
<p> La cartella SECRETS può contenere quattro file. </p>

<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> appsettings.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul>
<p> TranscribeAudio.json contiene le credenziali di Google Cloud Platform. Ognuno degli altri tre file può contenere impostazioni per ciascuno degli altri segreti. appsettings.Production.json dovrebbe contenere tutte le impostazioni per la produzione. Qualunque sia l&#39;impostazione in questi file, sostituirà quella che si trova in Server / WebApp / app.settings.json. Questo file è incluso nel repository. </p>

<p> Se desideri che il tuo computer locale abbia accesso ai servizi di Google, devi creare una cartella locale "../SECRETS in relazione alla posizione del repository. Quindi, ad esempio, puoi aggiungere un file" appsettings.Development. json ", che contiene le chiavi ottenute da Google. Vedere: <a href="home#google-api-keys">Chiavi API di Google</a> </p>
<hr /><h1> Documentazione </h1>
<p> Originariamente questa documentazione era conservata nelle pagine Wiki di Github. Ma è stato deciso di spostare le pagine nel progetto principale stesso, per due motivi: </p>

<ul>
<li> Non è possibile effettuare una richiesta pull per le modifiche nelle pagine Wiki di Github. Ciò rende difficile per i membri della comunità modificare la documentazione. </li>
<li> Molto probabilmente la documentazione rimarrà sincronizzata con il codice se è insieme al codice nello stesso repository. Un singolo PR per le modifiche al codice può includere le modifiche alla documentazione ad esso associate. </li>
</ul>
<p> La documentazione è scritta in Markdown e si trova in Frontend / ClientApp / src / app / assets / docs. </p>

</markdown>

<p> &lt;/ Mat-card&gt; </p>
