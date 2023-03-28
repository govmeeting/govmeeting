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
<p> Le tabelle nel database sono costituite da: </p>
<ol>
<li> Tabelle di autenticazione. </li></ol>
<p> Questi sono stati creati automaticamente da Microsoft Identity Service quando "Autenticazione = Account utente individuali" è stato verificato alla prima creazione del progetto. </p>
<ol start="2">
<li> Tabelle governative. </li></ol>
<p> Questi sono creati dalla funzione "Prima il codice" di Entity Framework. EF legge le classi C# nella libreria del progetto "Database / Modello" e genera automaticamente lo schema e le tabelle del database. </p>

<p> Vedere la pagina del documento "Installazione" per la creazione e l&#39;utilizzo del database. </p>
<h1> Schema </h1><h2> Tabella "Entità governativa" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th><th> Esempio 3 </th></tr>
<tr><td> Chiave primaria </td><td> chiave unica </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Nome </td><td> nome dell&#39;entità </td><td> Senato </td><td> montaggio </td><td> Consiglio di pianificazione </td></tr>
<tr><td> Nazione </td><td> posizione del paese </td><td> Stati Uniti d&#39;America </td><td> Stati Uniti d&#39;America </td><td> Stati Uniti d&#39;America </td></tr>
<tr><td> Stato </td><td> posizione dello stato </td><td></td><td> Iowa </td><td> New Jersey </td></tr>
<tr><td> contea </td><td> posizione della contea o della regione </td><td></td><td></td><td> Gloucester </td></tr>
<tr><td> Comunale </td><td> città o paese </td><td></td><td></td><td> Monroe Township </td></tr>
</table>

<p>
* Altri esempi per la tabella delle entità governative </p>

<table><tr><th> Campo </th><th> Esempio 4 </th><th> Esempio 5 </th></tr>
<tr><td> Chiave primaria </td><td> 4 </td><td> 5 </td></tr>
<tr><td> Nome </td><td> Vidhan Sabha </td><td> Consiglio municipale </td></tr>
<tr><td> Nazione </td><td> India </td><td> India </td></tr>
<tr><td> Stato </td><td> Andhra Pradesh </td><td> Andhra Pradesh </td></tr>
<tr><td> contea </td><td></td><td> Distretto di Kadapa </td></tr>
<tr><td> Comunale </td><td></td><td> Rayachoty </td></tr>
</table>

<p> Si noti che se l&#39;entità governativa è a livello nazionale, il suo stato, contea e sedi municipali sono nulle. Se l&#39;entità si trova a livello statale, la sua contea e le posizioni municipali sono nulle, ecc. </p>

<p> Sono necessari esempi per altri paesi. Se hai altri esempi, modifica questo documento ed invia una richiesta pull in Github. Se ci sono motivi per cui questo non funzionerà per alcuni paesi, si prega di inviare un problema a Github. </p>
<hr /><h2> Tavolo "riunioni" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th></tr>
<tr><td> Chiave primaria </td><td> chiave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> GovEntity </td><td> chiave per entità governativa </td><td> 2 (Senato degli Stati Uniti) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Tempo </td><td> tempo di incontro </td><td> 3 agosto &#39;14 19:30 </td><td> 2 maggio &#39;14 13:00 </td></tr>
<tr><td> Testo </td><td> testo di trascrizione </td><td> "L&#39;incontro arriverà all&#39;ordine ..." </td><td> "L&#39;assemblea si riunirà ..." </td></tr>
</table>
<hr /><h2> Tabella "rappresentativa" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th></tr>
<tr><td> Chiave primaria </td><td> chiave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Nome e cognome </td><td> nome e cognome </td><td> Rep. Steve Jones </td><td> Presidente Ravi Anand </td></tr>
<tr><td> Identifier </td><td> identificatore personale </td><td> (da decidere </td><td> (da decidere) </td></tr>
</table>

<p> I relatori alle riunioni potrebbero essere rappresentanti dell&#39;entità governativa o del pubblico in generale. In entrambi i casi, possono esserci le stesse persone che partecipano alle riunioni in più di un&#39;entità governativa. Vogliamo tracciare ciò che dice lo stesso rappresentante in ciascuno dei corpi di cui è membro. Pertanto abbiamo bisogno di un identificatore univoco per ciascun rappresentante. </p>

<p> Dovremo decidere quali informazioni sono necessarie per questa identificazione. Ovviamente non avremo il numero di identità nazionale di una persona di qualcosa del genere. Potrebbe essere necessario utilizzare una combinazione di più di un campo per identificare qualcuno. Ad esempio, indirizzo e nome. </p>

<p> Ci sarà una tabella "Rappresentante" che contiene un identificativo personale univoco per ciascun rappresentante. </p>
<hr /><h2> Tabella "RepresentativeToEntity" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th><th> Esempio 3 </th></tr>
<tr><td> Rappresentante </td><td> chiave per rappresentante </td><td> 1 </td><td> 2 </td><td> 2 </td></tr>
<tr><td> GovEntity </td><td> chiave per entità governativa </td><td> 5 </td><td> 7 </td><td> 9 </td></tr>
</table>

<p> Ci sarà anche una tabella, "RepresentativeToEntity", che collega i rappresentanti e le entità governative su cui servono. Si noti che lo stesso rappresentante può servire su più entità governative. </p>
<hr /><h2> Tavolo "Citizen" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th></tr>
<tr><td> Chiave primaria </td><td> chiave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Nome </td><td> nome </td><td> John J. </td><td> Rai S. </td></tr>
<tr><td> Incontro </td><td> chiave per l&#39;incontro </td><td> 2 (riunione del Senato degli Stati Uniti del 3 agosto 14) </td><td> 4 (Vidhan Sabha, riunione del 2 maggio 14) </td></tr>
</table>

<p> Ci sarà una tabella "Cittadino" per i membri del pubblico. La tabella Citizen conterrà una chiave esterna che punta alla riunione durante la quale questa persona ha parlato. </p>

<p> Dovremmo cercare di tenere traccia di ciò che dicono i membri del pubblico in tutte le riunioni a cui partecipano? Forse non è appropriato. </p>

<p> In caso contrario, non è necessario provare a identificare in modo univoco gli oratori pubblici. Il nome che la persona dà quando parla durante una riunione può essere usato per identificare qualcuno solo per quella riunione. Non è necessario correlare tale nome tra le riunioni. Potremmo anche preferire solo memorizzare il nome e il cognome iniziale. </p>
<hr /><h2> Tabella "Argomento" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th><th> Esempio 3 </th></tr>
<tr><td> Chiave primaria </td><td> chiave unica </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> GovEntity </td><td> chiave per entità governativa </td><td> 2 (Senato degli Stati Uniti) </td><td> 2 (Senato degli Stati Uniti) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> genere </td><td> Categoria o argomento </td><td> Categoria </td><td> Argomento </td><td> Categoria </td></tr>
<tr><td> Nome </td><td> nome argomento </td><td> Salute </td><td> Obamacare </td><td> formazione scolastica </td></tr>
</table>

<p> Ogni entità governativa (ad esempio il senato degli Stati Uniti o la Zoning Board di Monroe Township, NJ, USA) avrà i propri nomi univoci per le categorie e gli argomenti discussi durante le loro riunioni. Pertanto, la tabella Nome tag contiene una chiave esterna che punta all&#39;entità governativa. </p>
<hr />
<p> La trascrizione integrale della riunione è una stringa di testo. Le tabelle Posizione del relatore e Posizione del tag contengono puntatori nel testo, in particolare i punti di inizio e fine in cui cambia il relatore o il tag. Questi saranno puntatori di caratteri nella stringa di testo. </p>
<h2> Tabella "Tag degli altoparlanti" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th></tr>
<tr><td> PimaryKey </td><td> chiave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> altoparlante </td><td> chiave per l&#39;altoparlante </td><td> 1 (Rep. Jones) </td><td> 2 (Chair. Anand) </td></tr>
<tr><td> Incontro </td><td> chiave per l&#39;incontro </td><td> 1 (incontro 1) </td><td> 2 (incontro 2) </td></tr>
<tr><td> Inizio </td><td> punto in cui l&#39;altoparlante inizia a parlare </td><td> 521 </td><td> 12045 </td></tr>
<tr><td> Fine </td><td> punto quando l&#39;altoparlante smette di parlare </td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2> Tabella "Tag argomento" </h2>
<table><tr><th> Campo </th><th> Senso </th><th> Esempio 1 </th><th> Esempio 2 </th></tr>
<tr><td> Chiave primaria </td><td> chiave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Etichetta </td><td> chiave del tag </td><td> 1 (energia) </td><td> 2 (istruzione) </td></tr>
<tr><td> Incontro </td><td> chiave per l&#39;incontro </td><td> 1 (incontro 1) </td><td> 2 (incontro 2) </td></tr>
<tr><td> Inizio </td><td> punto all&#39;inizio dell&#39;argomento </td><td> 750 </td><td> 14500 </td></tr>
<tr><td> Fine </td><td> punto in cui l&#39;argomento si interrompe </td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2> Dimensione dei dati </h2>
<p> La dimensione del database della riunione finale è molto piccola. Ciò ci consentirà di creare applicazioni in cui gran parte dei dati vengono archiviati localmente sul computer o sullo smartphone di un utente, per prestazioni elevate e la possibilità di eseguire l&#39;applicazione offline. </p>
