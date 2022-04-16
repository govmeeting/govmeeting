<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle"> Design </mat-card-title>
<markdown ngPreserveWhitespaces>

<p> Oheiset kaaviot esittävät ohjelmistokomponenttien vuorovaikutuksen. </p>

<ul>
<li>
<p> ClientApp on selaimessa toimiva kulman tyyppikirjoituksen yhden sivun sovellus. Se tarjoaa käyttöliittymän. </p>
</li>
<li>
<p> WebApp on <a href="https://github.com/aspnet/home">Asp.Net Core</a> C# -sovellus, joka toimii palvelimella. Se vastaa WebApi-puheluihin. </p>
</li>
<li>
<p> WorkflowApp on <a href="https://github.com/dotnet/core">DotNet Core</a> C# -sovellus, joka toimii palvelimella. Se suorittaa nauhoitusten ja tekstikirjojen eräkäsittelyä. Se voidaan myös muuntaa kirjastoksi, joka toimii osana WebApp-prosessia. </p>
</li>
<li>
<p> Muut palvelinkomponentit ovat DotNet Core C# -kirjastoja. Niitä käyttävät sekä WebApp että WorkflowApp. </p>
</li>
</ul><hr /><h2> Järjestelmäsuunnittelu </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

<p> Yllä olevan kaavion komponentit ovat: </p>

<table style="width:100%">
<tr><th colspan="2"> Sovellukset </th></tr>
<tr><td> ClientApp </td><td> Kulmainen SPA </td></tr>
<tr><td> WebApp </td><td> Asp.Net-verkkopalvelinprosessi </td></tr>
<tr><td> WorkflowApp </td><td> Työnkulun palvelimen ohjausprosessi </td></tr>
<tr><th colspan="2"> kirjastot </th></tr>
<tr><td> GetOnlineFiles </td><td> Hae online-kopioita ja -tallenteita </td></tr>
<tr><td> ProcessRecording </td><td> Pura ja kopioi ääni. Luo työsegmentit. </td></tr>
<tr><td> ProcessTranscript </td><td> Muunna raakatiedotteet </td></tr>
<tr><td> LoadDatabase </td><td> Täytä tietokanta täydellisen kopion tiedoista </td></tr>
<tr><td> OnlineAccess </td><td> Rutiinit tiedostojen noutamiseksi etäsivustoilta </td></tr>
<tr><td> GoogleCloudAccess </td><td> Rutiininomainen käyttö Google Cloud -palveluihin </td></tr>
<tr><td> FileDataRepositories </td><td> Tallenna ja hanki JSON-työtiedoston tiedot </td></tr>
<tr><td> DatabaseRepositories </td><td> Tallenna ja hanki mallitiedot tietokannasta </td></tr>
<tr><td> DatabaseAccess </td><td> Pääset tietokantaan Entity Framework -sovelluksen avulla </td></tr>
</table>
<hr /><h2> ClientApp-suunnittelu </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

<p> ClientApp-rakenne näkyy parhaiten sen kulmakomponenttirakenteella </p>

<table style="width:100%">
<tr><th colspan="2"> Sovelluksen komponentit </th></tr>
<tr><td> ylätunniste </td><td> ylätunniste </td></tr>
<tr><td> Sidenav </td><td> Sivupalkin navigointi </td></tr>
<tr><td> kojelauta </td><td> Kojelaudan komponenttien säilytysastia </td></tr>
<tr><td> Dokumentointi </td><td> Säiliö dokumentaatiosivuille </td></tr>
<tr><th colspan="2"> Kojelaudan komponentit </th></tr>
<tr><td> Fixasr </td><td> Korjaa automaattinen puheentunnistusteksti </td></tr>
<tr><td> Lisää tageja </td><td> Lisää tunnisteita kopioihin </td></tr>
<tr><td> ViewMeeting </td><td> Tarkastele valmiita kopioita </td></tr>
<tr><td> kysymykset </td><td> Tarkastele aiheita koskevia tietoja </td></tr>
<tr><td> hälytykset </td><td> Tarkastele ja aseta hälytysten tietoja </td></tr>
<tr><td> virkamiehet </td><td> Tarkastele tietoja virkamiehistä </td></tr>
<tr><td> (Muut)) </td><td> Muut toteutettavat komponentit </td></tr>
<tr><th colspan="2"> Palvelut </th></tr>
<tr><td> VirtualMeeting </td><td> Suorita virtuaalinen kokous </td></tr>
<tr><td> Chat </td><td> Käyttäjän chat-komponentti </td></tr>
</table>
<hr /><h2> WebApp-suunnittelu </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

<p> Jokainen Web-sovellusliittymä on pieni ja soittaa säilytystiloille ladataksesi tai hakeaksesi tietoja tietokannasta tai tiedostojärjestelmästä. </p>

<table style="width:100%">
<tr><th colspan="2"> ohjaimet </th></tr>
<tr><td> Fixasr </td><td> Tallenna ja saat uusimman version tekstikirjasta. </td></tr>
<tr><td> Lisää tageja </td><td> Tallenna ja hae uusin versio merkinnästä. </td></tr>
<tr><td> Viewmeeting </td><td> Hanki viimeisin valmis trnascript. </td></tr>
<tr><td> Govbodies </td><td> Tallenna ja hanki rekisteröidyt hallintoelimen tiedot. </td></tr>
<tr><td> kokoukset </td><td> Tallenna ja hanki kokoustiedot. </td></tr>
<tr><td> Video </td><td> Hanki video kokouksesta. </td></tr>
<tr><td> Tili </td><td> Käsittele käyttäjän rekisteröinti ja sisäänkirjautuminen. </td></tr>
<tr><td> hoitaa </td><td> Käyttäjät voivat hallita profiilejaan. </td></tr>
<tr><td> admin </td><td> Järjestelmänvalvoja voi hallita käyttäjiä, käytäntöjä ja vaatimuksia </td></tr>
<tr><th colspan="2"> Palvelut </th></tr>
<tr><td> Sähköposti </td><td> Käsittele rekisteröinnin sähköpostitse vahvistus. </td></tr>
<tr><td> Viesti </td><td> Käsittele rekisteröinnin vahvistus tekstiviestitse. </td></tr>
</table>
<hr /><h2> WorkflowApp -suunnittelu </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

<p> Tietyn kokouksen työnkulun tila pidetään sen kokousrekisterissä tietokannassa. Jokainen työnkulun komponentti toimii itsenäisesti. Heidät kutsutaan vuorostaan tarkistamaan käytettävissä oleva työ. Jokainen komponentti kysyy tietokannasta kokouksia, jotka vastaavat heidän käytettävissä olevan työn kriteerejä. Jos työtä löytyy, he suorittavat sen ja päivittävät kokouksen tilan tietokannassa. </p>

<p> Jotta voimme rakentaa vankan järjestelmän, joka pystyy palautumaan virheistä, meidän on käsiteltävä työnkulun vaiheita "tapahtumina". Tapahtuma joko saatetaan loppuun kokonaan tai ei lainkaan. Jos prosessointivaiheen aikana tapahtuu korjaamattomia virheitä, kyseisen kokouksen tila palautuu viimeiseen voimassa olevaan tilaan. Koodilla ei tällä hetkellä toteuteta tapahtumia. (Seuraava Gitub-kysymys) </p>

<p> Pseudokoodi annetaan komponenteille alla </p>

<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Kaikille järjestelmän hallintoyksiköille </li>
<ul>
<li> Tarkista palautettavien kokousten aikataulut </li>
<li> Hae joko tallennus- tai tekstitiedosto </li>
<li> Laita tiedosto DATAFILES \ vastaanotettu -kansioon </li>
</ul>
<li> Tiedostot voidaan myös sijoittaa Vastaanotettu-kansioon käyttäjän lähettämällä. </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li> DATAFILES \ Received-tiedostoja ja tietokantatietuetta ei ole: </li>
<ul>
<li> Määritä tiedostotyyppi </li>
<li> Luo tietokantatietue </li>
<li> asetettu tila = vastaanotettu, hyväksytty = väärä </li>
<li> Lähetä johtajan viesti: "Vastaanotettu" </li>
</ul>
</ul>
<li> TranscribeRecordings </li>
<ul>
<li> Äänityksille, joiden lähdetyyppi = tallennus, tila = vastaanotettu, hyväksytty = totta </li>
<ul>
<li> Luo työkansio </li>
<li> asetettu tila = kirjoitus, hyväksytty = väärä </li>
<li> Tallenna tekstitys </li>
<li> asetettu tila = kirjoitettu, hyväksytty = väärä </li>
<li> Lähetä johtajan viesti: "Kirjattu" </li>
</ul>
</ul>
<li> ProcessTranscripts </li>
<ul>
<li> Transkriptioille, joiden lähdetyyppi = transkriptio, tila = vastaanotettu, hyväksytty = totta </li>
<ul>
<li> Luo työkansio </li>
<li> asetettu tila = käsittely, hyväksytty = väärä </li>
<li> Prosessin kopio </li>
<li> asetettu tila = käsitelty, hyväksytty = väärä </li>
<li> Lähetä johtajan viesti: "Käsitelty" </li>
</ul>
</ul>
<li> ProofreadRecording </li>
<ul>
<li> Tallenteille, joiden tila = transkriboitu / hyväksytty = totta </li>
<ul>
<li> Luo työkansio </li>
<li> asetettu tila = oikoluku, hyväksytty = väärä </li>
<li> Manuaalinen oikoluku tapahtuu nyt </li>
</ul>
<li> Tallennuksille, joiden tila = oikoluku </li>
<ul>
<li> Tarkista, näyttääkö oikoluku täydellinen. Jos niin: </li>
<li> asetettu tila = oikolukema, hyväksytty = väärä </li>
<li> lähetä johtajalle viesti: "Oikolukema" </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li> Tallennuksille, joiden tila = korjausluku, hyväksytty = tosi TAI selityksiin, joiden tila = käsitelty, hyväksytty = totta </li>
<ul>
<li> Luo työkansio </li>
<li> asetettu tila = merkitseminen, hyväksytty = väärä </li>
<li> Manuaalinen koodaus tapahtuu nyt </li>
</ul>
</ul>
<ul>
<li> Transkriptioille, joiden tila = merkintä </li>
<ul>
<li> Tarkista, näkyykö merkintä täydellisenä. Jos niin: </li>
<li> asetettu tila = merkitty, hyväksytty = väärä </li>
<li> lähetä johtajalle viesti: "Tagged" </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Kokouksissa, joissa status = merkitty, hyväksytty = totta 
<ul>
<li> asetettu tila = lataus, hyväksytty = väärä </li>
<li> lataa kokouksen sisältö tietokantaan </li>
<li> asetettu tila = ladattu, hyväksytty = väärä </li>
<li> Lähetä johtajan viesti: "Ladattu" </li>
</ul>
</ul>
</ul><hr /><h2> Käyttäjäsalaisuudet </h2>
<p> Kun kloonat govmeeting-arkiston Githubista, saat kaiken paitsi "SECRETS" -kansion. Tämä kansio sijaitsee arkiston ulkopuolella. Se sisältää seuraavat "salaiset" tiedot: </p>

<ul>
<li> ClientId ja ClientSecret Googlen ulkoiselle valtuutuspalvelulle. </li>
<li> SiteKey ja Secret Google ReCaptcha -palvelulle. </li>
<li> Google Cloud Platformin käyttöoikeustiedot. </li>
<li> Tietokannan yhteysmerkkijono. </li>
<li> Järjestelmänvalvojan käyttäjänimi ja salasana. </li>
</ul>
<p> SECRETS-kansio voi sisältää neljä tiedostoa. </p>

<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> appsettings.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul>
<p> TranscribeAudio.json sisältää Google Cloud Platform -käyttöoikeustiedot. Jokainen kolme muuta tiedostoa voi sisältää asetukset jokaiselle muulle salaisuudelle. appsettings.Production.json tulisi sisältää kaikki tuotantoasetukset. Kaikki tiedostossa olevat asetukset korvaavat Server / WebApp / app.settings.json -palvelimen asetukset. Tämä tiedosto sisältyy arkistoon. </p>

<p> Jos haluat, että paikallisella koneellasi on pääsy Google-palveluihin, sinun on luotava paikallinen kansio "../SECRETS suhteessa missä arkisto sijaitsee. Sitten voit esimerkiksi lisätä tiedoston" appsettings.Development ". json "siihen, joka sisältää avaimet, jotka saat Googlelta. Katso: <a href="home#google-api-keys">Google API -avaimet</a> </p>
<hr /><h1> Dokumentointi </h1>
<p> Alun perin tämä dokumentaatio säilytettiin Github Wikin sivuilla. Mutta päätettiin siirtää sivut itse pääprojektiin kahdesta syystä: </p>

<ul>
<li> Et voi tehdä muutospyyntöä Github Wiki -sivuilla. Tämän vuoksi yhteisön jäsenten on vaikea muuttaa dokumentaatiota. </li>
<li> Dokumentaatio pysyy todennäköisesti synkronoituna koodin kanssa, jos se on yhdessä koodin kanssa samassa arkistossa. Yksi koodimuutosten PR voi sisältää siihen liittyviä dokumentaatiomuutoksia. </li>
</ul>
<p> Asiakirjat on kirjoitettu Markdownissa ja sijaitsevat Frontend / ClientApp / src / app / omaisuus / docs-kansiossa. </p>

</markdown>

<p> &lt;/ Matto-kortti&gt; </p>
