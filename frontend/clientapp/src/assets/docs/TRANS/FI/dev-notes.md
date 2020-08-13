<h1> Käsittele uudet tekstitysmuodot </h1>
<p> Perimmäisenä tavoitteena on kirjoittaa koodi, joka käsittelee kaikki transkriptimuodot. Mutta siihen asti meidän on kirjoitettava mukautettu koodi käsitelläksesi jokaista uutta muotoa. Kun meillä on tarpeeksi näytteitä eri muodoista, pystymme paremmin kirjoittamaan yleisen koodin. </p>

<p> Nämä ovat vaiheet uusien tekstikoodimuotojen käsittelemiseksi: </p>

<ul>
<li>
<p> Hanki esimerkki hallituksen kokouksen kopiosta pdf- tai tekstitiedostona. </p>
</li>
<li>
<p> Nimeä tiedosto seuraavasti: "country_state_county_municipality_agency_language-code_date.pdf". (tai .txt) Esimerkiksi: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Luo uusi luokka käyttöliittymällä "ISpecificFix" projektiin "ProcessTranscripts_Lib". </p>
</li>
<li>
<p> Anna luokalle nimi "country_state_county_municipality_agency_language-code". Esimerkiksi: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Toteuta luokkamenetelmä: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix () vastaanottaa olemassa olevan kopioidun tekstin ja palauttaa tekstin seuraavassa muodossa: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Kun tämä luokka on valmis, WorkflowApp käsittelee uudet tekstit, kun ne ilmestyvät DATAFILES / RECEIVED. </p>

<p> Huomautuksia: </p>

<p> Käytämme System.Reflection -sovellusta oikean luokan käsittelemiseen käsiteltävän tiedoston nimen perusteella. </p>

<p> Katso esimerkki ProcessTranscripts_Lib-luokasta "USA_PA_Philadelphia_Philadelphia_CityCouncil_fi". Voit ymmärtää paremmin, mitä tämä luokka tekee, tarkastelemalla lokitiedoston jälkiä "työkansiossa", joka välitetään argumentiksi Fix (): lle. </p>

<p> Emme ota seuraavia tietoja nyt, mutta haluamme tehdä sen lopulta. </p>

<ul>
<li> Läsnä olevat virkamiehet </li>
<li> Esitetyt lakiehdotukset ja päätökset </li>
<li> Äänestysten tulokset </li>
</ul>
<p> Austin, TX - USA: lla on myös online-julkisten kokousten kopioita. Luokka luotiin nimeltä "USA_TX_TravisCounty_Austin_CityCouncil_en" ProcessTranscripts_Lib -kansioon. Mutta Fix () -menetelmää ei toteutettu. Tekstejä voi ostaa heidän verkkosivustoltaan: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Muokkaa asiakashallintapaneelia </h1><h2> Lisää kortti uutta ominaisuutta varten </h2>
<ul>
<li> Siirry terminaalikehotteessa kansioon: FrontEnd / ClientApp </li>
<li> Kirjoita: tuottaa komponentti ominaisuutesi </li>
<li> Lisää toiminnallisuus tiedostoihin, jotka ovat: FrontEnd / ClientApp / src / app / oma-ominaisuus </li>
<li> Aseta uusi gm-pieni-kortti tai gm-iso-kortielementti sovellukseen / viiva-pää / viiva-main.html. </li>
<li> Muokkaa kortielementin kuvaketta, kuvaväriä, otsikkoa jne. </li>
<li> Jos tarvitset pääsyä valitsimen valitun sijainnin ja edustajan nimeen: 
<ul>
<li> Lisää sijainti- ja toimistotietojen määritteet ominaisuuselementtiin </li>
<li> Lisää sijainti- ja toimisto @Input-ominaisuudet ohjaimeesi. </li>
</ul></li>
</ul>
<p> (Katso muut näytteet dash-main.html-muodossa) </p>
<h2> Järjestä kortit uudelleen </h2><ol>
<li> Avaa tiedosto: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Vaihda kortin sijainnit muuttamalla gm-pieni-kortti tai gm-iso-korttiosien sijainti tässä tiedostossa. </li></ol><h1> hakkuu </h1>
<p> WebApp- ja WorkflowApp-lokitiedostot ovat ratkaisun juuren kansiossa "lokit". </p>

<ul>
<li> "nlog-all- (date) .log" sisältää kaikki lokisanomat, mukaan lukien järjestelmä. </li>
<li> Tiedosto "nlog-own- (date) .log" sisältää vain sovellusviestit. </li>
</ul>
<p> Monien ClientApp-komponentitiedostojen yläosassa on määritelty const "NoLog". Vaihda sen arvo totta väärään kytkeäksesi konsolin lokitiedot käyttöön vain kyseisessä komponentissa. </p>
<h1> Rakenna skriptit </h1>
<p> Powershell-rakennuskomentosarjat löytyvät Apuohjelmat / PsScriptit -sivustosta </p>

<ul>
<li> BuildPublishAndDeploy.ps1 - Soita muille skripteille rakentaaksesi julkaisu ja ottaa sen käyttöön. </li>
<li> Build-ClientApp.ps1 - Rakenna ClientApp-tuotantoversiot </li>
<li> Publish-WebApp.ps1 - Luo WebApp "julkaise" -kansio </li>
<li> Copy-ClientAssets.ps1 - Kopioi ClientApp-omaisuus WebApp wwwroot -kansioon </li>
<li> Deploy-PublishFolder.ps1 - Ota julkaisukansio käyttöön etäkoneella </li>
<li> Luo dokumentitiedostoista README.md-tiedosto Gethubille </li>
</ul>
<p> Deploy-PublishFolder.ps1 käyttää ohjelmistoa osoitteeseen govmeeting.org FTP: n avulla. FTP-kirjautumistiedot ovat tiedostossa appsettings.Development.json, SECRETS-kansiossa. Se sisältää FTP: n ja muut kehitykseen käytettävät salaisuudet. Alla on osa tätä tiedostoa, jota FTP käyttää: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
