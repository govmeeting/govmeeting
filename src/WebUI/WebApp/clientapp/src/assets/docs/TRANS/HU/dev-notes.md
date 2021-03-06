<!-- Do not edit this file. It was translated by Google. -->
<h1> Új átirat-formátumok feldolgozása </h1>
<p> A végső cél az, hogy bármilyen átirat formátumot feldolgozó kódot írjon. Addig azonban minden új formátum kezeléséhez egyedi kódot kell írnunk. Ha elegendő különböző formátumú minta van, jobban tudjuk írni az általános kódot. </p>

<p> Az új átirat-formátumok kezelésének lépései: </p>

<ul>
<li>
<p> Szerezzen be példaként vagy szöveges fájlként egy kormányzati ülés átiratát. </p>
</li>
<li>
<p> Nevezze el a fájlt a következőképpen: "country_state_county_municipality_agency_language-code_date.pdf". (vagy .txt) Például: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Hozzon létre egy új osztályt az "ISpecificFix" felülettel a "ProcessTranscripts_Lib" projektben. </p>
</li>
<li>
<p> Nevezze meg az osztály "country_state_county_municipality_agency_language-code" -ét. Például: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Az osztály módszer végrehajtása: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> A Fix () megkapja a meglévő átirat szöveget, és a következő formátumban adja vissza a szöveget: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Amikor ez az osztály befejeződik, a WorkflowApp feldolgozza az új átiratokat, amikor azok megjelennek a "DATAFILES / RECEIVED" mappában. </p>

<p> Megjegyzés: </p>

<p> A System.Reflection használatával készítjük el a helyes osztályt a feldolgozandó fájl neve alapján. </p>

<p> Lásd például az „USA_PA_Philadelphia_Philadelphia_CityCouncil_en” osztályt a ProcessTranscripts_Lib részben. Megértheti jobban, amit ez az osztály csinál, ha megnézi a naplófájl nyomkövetéseit a "munkamappában", amelyet a Fix () -nek argumentumként adnak át. </p>

<p> A következő információkat nem vonjuk ki most, de végül ezt meg akarjuk tenni. </p>

<ul>
<li> Jelenlévő tisztviselők </li>
<li> Bevezetésre kerülnek törvényjavaslatok és határozatok </li>
<li> Szavazási eredmények </li>
</ul>
<p> Austin, TX - Az USA-ban online nyilvános találkozók átiratai is vannak. Létrehoztunk egy osztályt, amely "USA_TX_TravisCounty_Austin_CityCouncil_en" volt a ProcessTranscripts_Lib mappában. A Fix () metódus azonban nem került megvalósításra. Az átiratokat a weboldalukról szerezhetik be: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Módosítsa az Ügyfél irányítópultját </h1><h2> Adjon hozzá egy kártyát az új szolgáltatáshoz </h2>
<ul>
<li> A terminál kérésére lépjen a következő mappába: FrontEnd / ClientApp </li>
<li> Írja be: a szolgáltatás összetevőjének generálása </li>
<li> Adja hozzá funkcionalitását a következő fájlokhoz: FrontEnd / ClientApp / src / app / your-feature </li>
<li> Helyezzen be egy új gm-small-card vagy gm-nagy-card elemet az app / dash-main / dash-main.html mappába. </li>
<li> Módosítsa a kártya elem ikonját, színét, címét stb. </li>
<li> Ha hozzáférésre van szüksége a vezérlőben jelenleg kiválasztott hely és ügynökség nevéhez: 
<ul>
<li> Adja hozzá a hely és az ügynökség bemeneti attribútumait a szolgáltatás eleméhez </li>
<li> Adja hozzá a hely és az ügynökség @Input tulajdonságait a vezérlőjéhez. </li>
</ul></li>
</ul>
<p> (A többi mintát lásd a kötőjelben.html) </p>
<h2> Helyezze újra a kártyákat </h2><ol>
<li> Nyissa meg a fájlt: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Változtassa meg a kártya pozícióját az ebben a fájlban szereplő gm-small-kártya vagy gm-large-kártya elemek helyzetének megváltoztatásával. </li></ol><h1> Fakitermelés </h1>
<p> A WebApp és a WorkflowApp naplófájljai a megoldás gyökerein található "naplók" mappában vannak. </p>

<ul>
<li> "nlog-all- (date) .log" az összes naplóüzenetet tartalmazza, beleértve a rendszert is. </li>
<li> A "nlog-saját- (dátum) .log" fájl csak az alkalmazás üzeneteit tartalmazza. </li>
</ul>
<p> A ClientApp sok összetevő fájljának tetején egy const "NoLog" van megadva. Változtassa meg értékét igazról hamisra, hogy csak a komponens konzol naplózását kapcsolja be. </p>
<h1> Szkriptek készítése </h1>
<p> A Powershell build szkriptek a Utilities / PsScripts mappában találhatók </p>

<ul>
<li> BuildPublishAndDeploy.ps1 - Hívja a többi parancsfájlt egy kiadás készítéséhez és telepítéséhez. </li>
<li> Build-ClientApp.ps1 - A ClientApp gyártási verzióinak készítése </li>
<li> Publish-WebApp.ps1 - Készítsen egy WebApp "közzététel" mappát </li>
<li> Copy-ClientAssets.ps1 - Másolja a ClientApp eszközöket a WebApp wwwroot mappába </li>
<li> Deploy-PublishFolder.ps1 - A közzétételi mappa telepítése távoli gazdagépre </li>
<li> Hozza létre a README.md fájlt a Gethub számára a dokumentációs fájlokból </li>
</ul>
<p> A Deploy-PublishFolder.ps1 az FTP használatával telepíti a szoftvert a govmeeting.org webhelyre. Az FTP bejelentkezési információ az appsettings.Development.json fájlban található, a SECRETS mappában. FTP-t és egyéb fejlesztési titkokat tartalmaz. Az alábbiakban található a fájlnak az FTP által használt szakasza: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
