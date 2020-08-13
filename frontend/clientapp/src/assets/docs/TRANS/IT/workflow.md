<p> Di seguito è una descrizione funzionale delle parti principali del software. </p>
<h2> Registrazione individuale </h2>
<ul>
<li> Durante la registrazione, gli utenti specificano la loro posizione di residenza (città, città, villaggio, codice postale, ecc.). </li>
<li> In base alla loro posizione, il sistema determina le entità governative a cui appartengono. (paese, stato, contea, città / città ecc.) </li>
</ul><h2> Registrazione dell&#39;ente governativo </h2>
<ul>
<li> Un utente può registrare qualsiasi entità governativa a cui appartiene. </li>
<li> Le informazioni inserite includeranno: 
<ul>
<li> URL del sito </li>
<li> Nomi dei funzionari di governo </li>
<li> URL in cui è possibile trovare trascrizioni o registrazioni delle riunioni </li>
</ul></li>
<li> Altri utenti per questa posizione vedranno i dati già inseriti. Possono votare l&#39;accuratezza di qualsiasi elemento di dati e inserire valori alternativi. </li>
<li> I voti si accumuleranno per ciascun valore di dati. I valori con il maggior numero di voti diventano i valori ufficiali. <a href="https://github.com/govmeeting/govmeeting/issues/62">Numero Github n. 62</a> </li>
</ul><h2> Importa registrazioni o trascrizioni </h2>
<ul>
<li> Il sistema scaricherà le registrazioni o le trascrizioni online esistenti in modo regolare dalle posizioni specificate nella Registrazione dell&#39;ente governativo. </li>
<li> Gli utenti hanno anche la possibilità di caricare registrazioni o trascrizioni. </li>
<li> Molti luoghi non forniscono trascrizioni né registrazioni delle loro riunioni. Govmeeting fornirà un&#39;app per smartphone che gli utenti possono utilizzare per registrare e caricare personalmente una registrazione della riunione. <a href="https://github.com/govmeeting/govmeeting/issues/18">Numero 18 di Github</a> </li>
</ul><h2> Transcript esistenti pre-process </h2>
<ul>
<li> Converti le trascrizioni in testo semplice. Spesso le trascrizioni esistenti sono in altri formati come PDF. Questi vengono convertiti in testo normale in modo che sia elaborato più facilmente. </li>
<li> Estrai informazioni come i relatori e i nomi delle sezioni. </li>
</ul><h2> Trascrivere le registrazioni usando il riconoscimento vocale </h2>
<ul>
<li> Converti le registrazioni nei formati video Web principali (mp4, ogg e webm.) Ciò le rende più accessibili su tutti i tipi di dispositivi. </li>
<li> Estrai e unisci le tracce audio se più di una. </li>
<li> Carica il file audio nello spazio di archiviazione di Google Cloud per preparare la trascrizione. </li>
<li> Chiama l&#39;API di Google Speech asincrona per eseguire il riconoscimento vocale automatico. </li>
<li> Eseguire il riconoscimento del cambio degli altoparlanti. C&#39;è un&#39;API di Google per questo. </li>
<li> Aggiungi l&#39;identificazione del relatore. Questo utilizzerà software di elaborazione vocale sul server. </li>
<li> Inserisci le informazioni in un formato JSON per ulteriori elaborazioni. </li>
<li> Dividi i file video, audio e trancript in segmenti di lavoro di 3 minuti, in modo che più volontari possano lavorare contemporaneamente alla correzione di bozze. </li>
</ul><h2> Correggi testo trascritto [passaggio manuale] </h2>
<ul>
<li> Testo di correzione per errori. Fornire un&#39;interfaccia intuitiva per la correzione rapida degli errori. </li>
<li> Informazioni corrette come nomi dei relatori e delle sezioni. </li>
</ul>
<p> Govmeeting tenta di rendere l&#39;elaborazione il più automatica possibile. Ma i computer non sono ancora così intelligenti come vorremmo. Gli umani sono ancora necessari per correggere i loro errori. Ma ogni giorno, i computer diventano più intelligenti e questo lavoro dovrebbe continuare a diventare sempre meno. </p>
<h2> Aggiungi tag problema [Passaggio manuale] </h2>
<ul>
<li> Uno dei lavori più importanti è l&#39;aggiunta corretta di tag o metadati alla trascrizione. Questo è ciò che consente: 
<ul>
<li> informazioni facilmente reperibili. </li>
<li> una trascrizione da indicizzare e sfogliare rapidamente </li>
<li> avvisi che l&#39;utente deve impostare su questioni specifiche </li>
</ul></li>
<li> I nomi dei problemi devono essere assegnati da persone e non da computer. Questo è il modo migliore per assicurarsi che siano significativi. </li>
<li> È importante fornire un&#39;interfaccia utente molto facile da usare e rapida. </li>
</ul>
<p> In futuro, forse questo passaggio può essere eseguito principalmente da un computer. Ma non è affatto male avere bisogno di un po &#39;di lavoro manuale da parte dei volontari della comunità. Aiuta a unire le persone per una causa comune. Se questa è una piccola città di 35.000 abitanti, non dovrebbe essere così difficile arruolarne una dozzina circa per concedere un breve periodo di tempo ogni mese. </p>
<h2> Popolare database relazionale </h2>
<p> I dati vengono inseriti in un database relazionale in modo che sia possibile accedervi rapidamente utilizzando più criteri. </p>
<h2> I dati sono ora disponibili per l&#39;uso </h2>
<ul>
<li> È ora disponibile una trascrizione che consente la ricerca e la ricerca </li>
<li> Un riepilogo delle questioni discusse durante la riunione viene inviato a coloro che lo richiedono. </li>
<li> Gli avvisi vengono inviati su problemi specifici a coloro che lo richiedono. </li>
</ul><h2> La riunione virtuale è organizzata. </h2>
<ul>
<li> Viene creato un ordine del giorno basato sulle questioni del vero incontro. </li>
<li> Gli inviti vengono inviati ai membri della comunità. </li>
<li> Nell&#39;invito sono incluse le richieste di possibili punti all&#39;ordine del giorno aggiuntivi. </li>
<li> Alla ricezione delle risposte, viene inviata una scheda elettorale a coloro che parteciperanno. In questo scrutinio, i membri possono votare quali nuovi punti dell&#39;ordine del giorno suggeriti includere. </li>
<li> Entro pochi giorni si tiene una riunione virtuale. </li>
</ul><h2> Gestione del flusso di lavoro </h2>
<p> Alcuni dei passaggi del flusso di lavoro sopra riportati vengono eseguiti automaticamente dal computer e alcuni vengono eseguiti manualmente da volontari. Ci sono posti nel flusso di lavoro in cui una persona reale dovrebbe verificare che sia OK procedere: </p>

<ul>
<li> Verifica che gli URL per il recupero di trascrizioni e registrazioni appaiano validi. </li>
<li> Verificare che il contenuto dei file recuperati appaia valido. </li>
<li> Verificare che l&#39;output della preelaborazione sia valido. </li>
<li> Verificare che la conversione da parlato a testo appaia valida. </li>
<li> Verifica che la correzione della trascrizione appaia completata. </li>
<li> Verifica che l&#39;aggiunta di tag alla trascrizione appaia completata. </li>
<li> Verificare che i dati della trascrizione finale siano completi e validi. </li>
</ul>
<p> È necessario un modo per elevare i diritti di uno o più utenti registrati di una posizione in una posizione di "responsabile". </p>

<ul>
<li> I manager verrebbero avvisati ogni volta che una decisione è in sospeso nel flusso di lavoro. </li>
<li> Un manager potrebbe quindi accedere e negare o approvare il proseguimento del flusso di lavoro. </li>
</ul>
