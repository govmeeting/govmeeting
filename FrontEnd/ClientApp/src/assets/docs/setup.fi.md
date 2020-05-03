
<p><a name="Contents"></a></p>
<h1> Sisällys </h1>
<ul>
<li> <a href="about?id=setup#InstallTools">Asenna työkalut ja kloonivarasto</a> </li>
<li> <a href="about?id=setup#DevelopVsCode">Kehitä VsCode: lla</a> </li>
<li> <a href="about?id=setup#DevelopVS">Kehitä Visual Studion kanssa</a> </li>
<li> <a href="about?id=setup#DevelopOther">Kehitä muilla alustoilla</a> </li>
<li> <a href="about?id=setup#Database">Tietokanta</a> </li>
<li> <a href="about?id=setup#GoogleCloud">Google Cloud Platform -tili</a> </li>
<li> <a href="about?id=setup#GoogleApi">Google API -näppäimet</a> </li>
</ul>
<p> Nämä dokumentaatiosivut ovat FrontEnd / ClientApp / src / app / omaisuus / docs-kansiossa. Suorita korjaukset siellä ja <a href="https://github.com/govmeeting/govmeeting">lähetä vetopyyntö Gitubille.</a> </p>
<hr />
<p><a name="InstallTools"></a></p>
<h1> Asenna työkalut ja kloonivarasto <br/></h1>
<p> <a href="about?id=setup#Contents">[Sisällys]</a> </p>

<ul>
<li> Asenna git. <a href="https://gitforwindows.org">Git Windowsille</a> , <a href="https://git-scm.com/download/mac">Git Macille</a> </li>
<li> Asenna <a href="https://nodejs.org/en/download/">Node.js.</a> </li>
<li> Asenna <a href="https://dotnet.microsoft.com/download">.Net Core SDK.</a> </li>
<li> "Haarukka" projekti githubissa </li>
<li> Klooni projekti paikallisesti </li>
<li> Luo sisaruskansio kloonatulle arkistolle nimeltä "_SECRETS" </li>
</ul>
<p> "_SECRETS" -kansio on tarkoitettu avaimille ja salasanoille, joita ei ole tallennettu julkiseen arkistoon. Niitä tarvitaan Google API -palveluiden suorittamiseen. </p>
<hr />
<p><a name="DevelopVsCode"></a></p>
<h1> Kehitä VsCode: lla <br/></h1>
<p> <a href="about?id=setup#Contents">[Sisällys]</a> </p>
<h2> Asenna VsCode </h2>
<ul>
<li> Asenna <a href="https://code.visualstudio.com/download">Visual Studio -koodi</a> ja käynnistä se. </li>
<li> Avaa laajennukset vasemmalla sivupaneelilla ja asenna: 
<ul>
<li> Microsoftin "Debugger for Chrome" </li>
<li> "C
# Visual Studio -koodille" kirjoittanut Microsoft </li>
<li> Microsoftin "SQL Server (mssql)" </li>
<li> "Todo Tree" kirjoittanut Gruntfuggly - näyttää TODO-rivit koodissa (valinnainen) </li>
<li> Microsoftin "Powershell" - Powershell-rakennuskomentosarjojen virheenkorjaukseen (valinnainen) </li>
</ul></li>
</ul><h2> Debug / Suorita ClientApp & WebApp </h2>
<ul>
<li> Avaa Govmeeting-kansio VsCode-sovelluksessa </li>
<li> Avaa pääteruutu VsCode-sovelluksessa </li>
<li> cd FrontEnd / ClientApp </li>
<li> npm asenna </li>
<li> npm alku </li>
<li> Aseta vianetsintäpaneelissa käynnistysmääritykset "WebApp & ClientApp-W" </li>
<li> Paina F5 (virheenkorjaus) tai Ctrl-F5 (suorita ilman virheenkorjausta) </li>
</ul>
<p> ClientApp avautuu selaimessa. </p>

<ul>
<li> Napsauta mitä tahansa Tietoja-valikkokohdoista, niin näet ohjeet. </li>
<li> Napsauta sijaintivalikkokohta "Boothbayn satama". Näet kojetaulun auki tälle sijainnille. </li>
</ul>
<p> Varmistaaksesi, että ClientApp soittaa WebApp API: lle tietojen noutamiseksi. </p>

<ul>
<li> Napsauta "Oikoluku transkriptio". Näet videoruudun ja tekstitetyn tekstin. Napsauta videon toistopainiketta. </li>
<li> Napsauta "Lisää tunnisteita tekstitykseen". Näet kokouksen koodauksen merkitsemisen. </li>
<li> Napsauta "Näytä viimeisin kokous". Näet täydellisen kopion katselua varten. </li>
</ul>
<p> Suurin osa muista kojelautakorteista ei soita WebAppille, vaan palauttaa testitiedot. </p>

<p> ClientApp palvelee webpack-dev-palvelin, joka aloitettiin "npm start". WebApp käyttää Kestrel-palvelinta, joka sisältyy Asp.Net Core -sovellukseen. Kestrel-palvelin vastaa Web-sovellusliittymäpuheluihin. Mutta se välittää sisäiset ClientApp-pyynnöt webpack-dev-palvelimelle. </p>
<h2> Debug / Run ClientApp itsenäinen </h2>
<ul>
<li> Muuta sovelluksessa.module.ts "isAspServerRunning" totta väärään. </li>
<li> npm alku </li>
<li> Aseta vianetsintäpaneelissa käynnistyskokoonpano "ClientApp" </li>
<li> Paina F5 (virheenkorjaus) tai Ctrl-F5 (suorita ilman virheenkorjausta) </li>
</ul>
<p> Kun "isAspServerRunning" on asetettu väärään, tynkäpalveluita käytetään WebApp-sovellusliittymän kutsumisen sijasta. Tästä on hyötyä, kun muokkaamme vain koodia ClientAppissa. </p>
<h2> Debug / Run WorkflowApp </h2>
<ul>
<li> Aseta virheenkorjauspaneelissa käynnistyskokoonpano "WorkflowApp" </li>
<li> Paina F5 (virheenkorjaus) tai Ctrl-F5 (suorita ilman virheenkorjausta) </li>
</ul>
<p> Kun WorkflowApp käynnistää sen: </p>

<ul>
<li> Kopioi jotkut testitiedostot Datafles / RECEIVED-kansioon: kopioidun PDF-tiedoston ja tallentavan MP4-tiedoston. </li>
<li> Prosessoi kopioidun PDF-tiedoston ja luo JSON-tiedoston, joka on valmis merkitsemään. </li>
<li> Käsittele tallentava MP4-tiedosto kopioimalla se pilvessä ja luo JSON-tiedoston, joka on valmis oikolukemaan. </li>
</ul>
<p> Tulokset löytyvät tiedostosta / PROSESSING. Sinun on kuitenkin ensin määritettävä <a href="about?id=setup#GoogleCloud">Google Cloud -tili</a> , jotta nauhoitus voidaan kirjoittaa. </p>
<hr />
<p><a name="DevelopVS"></a></p>
<h1> Kehitä Visual Studion kanssa <br/></h1>
<p> <a href="about?id=setup#Contents">[Sisällys]</a> </p>

<ul>
<li> Asenna ilmainen <a href="https://visualstudio.microsoft.com/free-developer-offers/">Visual Studio Community Edition.</a> </li>
<li> Valitse asennuksen aikana sekä "ASP.NET" että ".NET desktop" työkuormat. </li>
<li> Asenna laajennukset: (kaikki kirjoittanut Mads Kristensen) 
<ul>
<li> "NPM Task Runner" </li>
<li> "Command Task Runner" </li>
<li> "Merkintäeditori" </li>
</ul></li>
<li> Avaa ratkaisutiedosto "govmeeting.sln" </li>
</ul><h2> Debug / Suorita ClientApp & WebApp </h2>
<ul>
<li> Task Runner Explorer -sovelluksessa (ClientApp): 
<ul>
<li> suorita "asenna" </li>
<li> aja "Käynnistä" </li>
</ul></li>
<li> Aseta käynnistysprojektiksi "WebApp" </li>
<li> Paina F5 (virheenkorjaus) tai Ctrl-F5 (suorita ilman virheenkorjausta) </li>
<li> WebApp suoritetaan ja selain avautuu, jolloin näytetään ClientApp. </li>
</ul>
<p> HUOMAUTUS: Aikavälien asettamisessa on ongelma Visual Studion Angular ClientApp -sovelluksessa. Katso: <a href="https://github.com/govmeeting/govmeeting/issues/80">Github-numero
# 80</a> </p>
<h2> Debug WorkflowApp </h2>
<ul>
<li> Avaa vianetsintäpaneeli. </li>
<li> Aseta käynnistysprojektiksi "WorkflowApp" </li>
<li> Paina F5 (virheenkorjaus) tai Ctrl-F5 (suorita ilman virheenkorjausta) </li>
</ul>
<p> Huomaa: Katso WorkflowApp -sovelluksen huomautukset kohdasta "Visual Studio -koodi" </p>
<hr />
<p><a name="DevelopOther"></a></p>
<h1> Kehitä muilla alustoilla <br/></h1>
<p> <a href="about?id=setup#Contents">[Sisällys]</a> </p>

<p> Aseta profiilissasi ympäristömuuttuja, ASPNETCORE_ENVIRONMENT, "Kehitys" -kohtaan. Tätä käyttävät WebApp ja WorkflowApp. </p>
<h2> Luo ja aja ClientApp </h2>
<p> Suorittaa: </p>

<ul>
<li> cd Frontend / ClientApp </li>
<li> npm asenna </li>
<li> npm alku </li>
</ul>
<p> Siirry selaimeesi localhost: 4200. Asiakassovellus latautuu. Jotkut ominaisuudet eivät toimi, ennen kuin WebApp on käynnissä. </p>
<h2> Luo ja aja WebApp ClientApp -sovelluksen avulla </h2>
<p> Suorittaa: </p>

<ul>
<li> (tee yllä: "Rakenna ja käynnistä ClientApp") </li>
<li> cd ../../Backend/WebApp </li>
<li> dotnet build webapp.csproj </li>
<li> dotnet suorita bin / debug / dotnet2.2 / webapp.dll </li>
</ul>
<p> Siirry selaimeesi localhost: 5000. Asiakassovellus latautuu. </p>
<h2> Luo ja aja ClientApp itsenäisesti </h2>
<ul>
<li> Muuta sovelluksessa.module.ts "isAspServerRunning" totta väärään. </li>
<li> (tee yllä: "Rakenna ja käynnistä ClientApp") </li>
</ul><h2> Rakenna ja suorita WorkflowApp </h2>
<p> Suorittaa: </p>

<ul>
<li> cd-taustakuva / WorkflowApp </li>
<li> dotnet build workflowapp.csproj </li>
<li> dotnet suorita bin / debug / dotnet2.0 / workflowapp.dll </li>
</ul>
<p> Huomaa: Katso WorkflowApp -sovelluksen huomautukset kohdasta "Visual Studio -koodi" </p>
<!-- END OF README SECTION --><hr />
<p><a name="Database"></a></p>
<h1> Tietokanta <br/></h1>
<p> <a href="about?id=setup#Contents">[Sisällys]</a> </p>

<p> Sinun ei ehkä tarvitse asentaa ja määrittää tietokantaa kehityksen suorittamiseksi. On testikantoja, jotka korvaavat kutsutietokannan. Katso jäljempänä "Test Stubs". </p>
<h2> Asenna palveluntarjoaja </h2>
<p> Jos käytät Visual Studio- tai Visual Studio -koodia, Sql Server Express LocalDb -palveluntarjoaja on jo asennettu. Muussa tapauksessa tee alla oleva "LocalDb-palveluntarjoajan asennus". </p>
<h3> LocalDb-palveluntarjoajan asennus </h3>
<p> Siirry <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">Sql Server Expressiin.</a> Lataa Windows: SQL Serverin Express-erikoispaino. Valitse asennuksen aikana "Custom" ja sitten "LocalDb". </p>

<p> LocalDb on saatavana myös MacO: ille ja Linuxille. Jos asennat sen jommallakummalle alustalle, päivitä tämä asiakirja vaiheilla ja tee Pull-pyyntö. </p>
<h3> Muut palveluntarjoajat </h3>
<p> LocalSb: n lisäksi EF Core tukee <a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli">muita palveluntarjoajia,</a> joita voit käyttää kehittämiseen, mukaan lukien SqlLite. Sinun on muokattava DbContext-asetukset startup.cs: ssä ja yhteysjono sovelluksissa.json. </p>
<h2> Rakenna tietokantakaavio </h2>
<p> Tietokanta on rakennettu Entity Framework Core "code first" -ominaisuuden kautta. Se tutkii tietomallin C# -luokat ja luo automaattisesti kaikki taulukot ja suhteet. Siinä on kaksi vaihetta: (1) Luo "siirto" -koodi päivityksen tekemistä varten ja (2) suorita päivitys. </p>

<ul>
<li> cd-taustakuva / WebApp </li>
<li> dotnet ef -siirrot lisäävät alkuperäisen - projektin .. \ Database \ DatabaseAccess_Lib </li>
<li> dotnet ef-tietokannan päivitys - projekti .. \ Database \ DatabaseAccess_Lib </li>
</ul><h2> Tutustu luotuun tietokantaan </h2><h3> VsCodessa </h3>
<p> Lisää seuraava käyttäjän asetuksiin.json VsCodessa: </p>
<pre> <code> "mssql.connections": [ { "server": "(localdb)\\mssqllocaldb", "database": "Govmeeting", "authenticationType": "Integrated", "profileName": "GMProfile", "password": "" } ],</code> </pre>
<ul>
<li> Paina ctrl-alt-D tai paina Sql-palvelimen kuvaketta vasemmalla reunalla. </li>
<li> Avaa GMProfile-yhteys tarkastellaksesi ja työskennelläksesi tietokantaobjekteilla. </li>
<li> Avaa "Pöydät". Sinun pitäisi nähdä kaikki taulukot, jotka on luotu rakennettaessa yllä olevaa kaavaa. Tähän sisältyy AspNetxxxx-taulukot autorizatonille ja Govmeeting-tietomallin taulukot. </li>
</ul><h3> Visual Studiossa </h3>
<ul>
<li> Siirry valikkokohtaan: Näytä -&gt; SQL Server Object Explorer. </li>
<li> Laajenna SQL Server -&gt; (localdb) \ MSSQLLocalDb -&gt; Tietokannat -&gt; Govmeeting </li>
<li> Avaa "Pöydät". Sinun pitäisi nähdä kaikki taulukot, jotka on luotu rakennettaessa yllä olevaa kaavaa. Tähän sisältyy AspNetxxxx-taulukot autorizatonille ja Govmeeting-tietomallin taulukot. </li>
</ul><h3> Muut alustat </h3>
<p> Siellä on monialustainen ja avoimen lähdekoodin <a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha">SQL Operations Studio,</a> "tiedonhallintatyökalu, joka mahdollistaa työskentelyn SQL Serverin, Azure SQL DB: n ja SQL DW: n kanssa Windowsista, macOS: sta ja Linuxista". Voit ladata <a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha">SQL Operations Studion ilmaiseksi täältä.</a> </p>

<p> Jos käytät tätä tai muuta työkalua SQL Server-tietokantojen tutkimiseen, päivitä nämä ohjeet. </p>
<h2> Testinipit </h2>
<p> Koodia, jolla tallennetaan / haetaan transkriptitietoja tietokantaan, ei ole vielä kirjoitettu. Siksi DatabaseRepositories_Lib käyttää staattista testitietoa sen sijaan. WebApp / appsettings.json -ominaisuuden "UseDatabaseStubs" -asetukseksi on määritetty "true", joka käskee sen kutsua tynkärutiineja. </p>

<p> WebApp-käyttäjän rekisteröinti- ja kirjautumiskoodi kuitenkin käyttää tietokantaa. Se käyttää Asp.Net-käyttäjän todennustaulukoita. WebApp todentaa APIA-puhelut ClientAppista nykyisen kirjautuneen käyttäjän perusteella. </p>

<p> Voit käyttää WebAppin esisuorittimen arvoa "NOAUTH" ohittaaksesi todennuksen. Käytä yhtä näistä menetelmistä: </p>

<ul>
<li> Poista tiedosto FixasrController.cs tai AddtagsController.cs kansiossa tiedoston yläosassa olevan #if NOAUTH -rivin kommentti. </li>
<li> Jos haluat poistaa sen käytöstä kaikilta ohjaimilta, lisää tämä WebApp.csproj: iin: </li>
</ul><pre> <code> &lt;PropertyGroup Condition="&#39;$(Configuration)|$(Platform)&#39;==&#39;Debug|AnyCPU&#39;&gt; &lt;DefineConstants&gt;NOAUTH&lt;/DefineConstants&gt; &lt;/PropertyGroup&gt;</code> </pre>
<ul>
<li> Siirry Visual Studiossa WebApp-omaisuussivuille -&gt; Rakenna -&gt; ja kirjoita NOAUTH "Ehdollinen kokoamissymboli" -ruutuun. </li>
</ul><hr />
<p><a name="GoogleCloud"></a></p>
<h1> Google Cloud Platform -tili <br/></h1>
<p> <a href="about?id=setup#Contents">[Sisällys]</a> </p>

<p> Jotta voit käyttää Google Speech -sovellusliittymiä puheeksi muuntamiseen, tarvitset Google Cloud Platform (GCP) -tilin. Suurimmassa osassa Govmeetingin kehitystyötä voit käyttää olemassa olevia testitietoja. Mutta jos haluat kirjoittaa uusia nauhoituksia, saat GCP: n. Google-sovellusliittymä pystyy kopioimaan nauhoituksia yli 120 kielellä ja muunnelmissa. </p>

<p> Google tarjoaa kehittäjille ilmaisen tilin, joka sisältää hyvityksen (tällä hetkellä 300 dollaria). Puheen sovellusliittymän käytön nykyiset kustannukset ovat ilmaisia jopa 60 minuutin muuntamiselle kuukaudessa. Sen jälkeen "parannetun mallin" (jota tarvitsemme) hinta on 0,009 dollaria per 15 sekuntia. (2,16 dollaria tunnissa) </p>

<ul>
<li>
<p> Avaa tili <a href="https://cloud.google.com/free/">Google Cloud Platformilla</a> </p>
</li>
<li>
<p> Siirry <a href="http://console.cloud.google.com">Google Cloud Dashboardiin</a> ja luo projekti. </p>
</li>
<li>
<p> Siirry <a href="http://console.developers.google.com">Google-kehittäjäkonsoliin</a> ja ota Speech & Cloud Storage -sovellusliittymät käyttöön </p>
</li>
<li>
<p> Luo "palvelutilin" käyttöoikeustiedot tälle projektille. Napsauta Tunnistetiedot kehittäjäkonsolissa. </p>
</li>
<li>
<p> Anna tilille "Editor" -luvat projektille. Napsauta tiliä. Napsauta seuraavalla sivulla Käyttöoikeudet. </p>
</li>
<li>
<p> Lataa käyttöoikeustiedot JSON-tiedosto. </p>
</li>
<li>
<p> Laita tiedosto <code>_SECRETS</code> kansioon, jonka loit <code>_SECRETS</code> . </p>
</li>
<li>
<p> Nimeä tiedosto <code>TranscribeAudio.json</code> . </p>
</li>
</ul>
<p> HUOMAUTUS: Yllä olevat vaiheet ovat saattaneet muuttua hieman. Jos on, päivitä tämä asiakirja. </p>
<h2> Testaa puheen ja tekstin transkriptio </h2>
<ul>
<li>
<p> Aseta Visual Studion käynnistysprojektiksi <code>Backend/WorkflowApp</code> . Paina F5. </p>
</li>
<li>
<p> Kopioi (älä siirrä) yhtä MP4-mallitiedostoista testitiedoista Datafiles / RECEIVED-tiedostoon. </p>
</li>
</ul>
<p> Ohjelma tunnistaa nyt uuden tiedoston ja aloittaa sen käsittelyn. MP4-tiedosto siirretään kohtaan "VALMIS", kun se on valmis. Näet tulokset alikansioissa, jotka on luotu "Tiedostot" -hakemistoon. </p>

<p> Sovelluksessa appsettings.json on omaisuus "RecordingSizeForDevelopment". Sen asetukseksi on "180". Tämä saa aikaan, että ProcessRecording_Lib -sovelluksen kopiointirutiini käsittelee vain nauhoituksen ensimmäiset 180 sekuntia. </p>
<hr />
<p><a name="GoogleApi"></a></p>
<h1> Google API -näppäimet <br/></h1>
<p> <a href="about?id=setup#Contents">[Sisällys]</a> </p>

<p> Tarvitset näitä avaimia, jos haluat käyttää tai työskennellä rekisteröinti- ja kirjautumisprosessin tiettyjen ominaisuuksien kanssa. </p>

<ul>
<li> ReCaptcha-avaimia tarvitaan käyttämään ReCaptchaa käyttäjän rekisteröinnin aikana. Niitä voi hankkia <a href="https://developers.google.com/recaptcha/">Google reCaptcha -sivustolta</a> . </li>
<li> OAuth 2.0 -käyttöoikeuksia käytetään ulkoisen käyttäjän kirjautumiseen ilman, että käyttäjän on luotava henkilökohtainen tili sivustolle. Vieraile <a href="https://console.developers.google.com/">Google API -konsolissa</a> saadaksesi käyttäjätiedot, kuten asiakastunnuksen ja asiakassalaisuuden. </li>
</ul>
<p> Luo tiedosto "appsettings.Development.json" kansioon "_SECRETS". Sen tulisi sisältää juuri hankkimat avaimet: </p>
<pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-Id", "ClientSecret": "your-client-secret" } }, "ReCaptcha:SiteKey": "your-site-key", "ReCaptcha:Secret": "your-secret" }</code> </pre><hr /><h2> Testaa reCaptcha </h2>
<ul>
<li> Suorita WebApp-projekti. </li>
<li> Napsauta oikeassa yläkulmassa olevaa "Rekisteröidy" -painiketta. </li>
<li> ReCaptcha-vaihtoehdon tulisi näkyä. </li>
</ul><hr /><h2> Testaa Google-todennus </h2>
<ul>
<li> Suorita WebApp-projekti. </li>
<li> Napsauta oikeassa yläkulmassa olevaa Kirjaudu sisään. </li>
<li> Valitse "Käytä toista palvelua kirjautuaksesi sisään" -kohdassa "Google". </li>
</ul>