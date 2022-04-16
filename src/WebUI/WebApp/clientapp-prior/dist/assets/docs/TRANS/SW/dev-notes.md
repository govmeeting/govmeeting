<h1> Sindika muundo mpya wa maandishi </h1>
<p> Lengo kuu ni kuandika msimbo ambao utasindika muundo wowote wa maandishi. Lakini hadi wakati huo, tunahitaji kuandika msimbo maalum ili kushughulikia kila fomati mpya. Tunapokuwa na sampuli za kutosha za fomati tofauti, tutaweza kuandika nambari ya generic. </p>

<p> Hii ni hatua za kushughulikia fomati mpya za maandishi: </p>

<ul>
<li>
<p> Pata nakala ya mfano ya mkutano wa serikali kama faili ya maandishi au maandishi. </p>
</li>
<li>
<p> Taja faili kama ifuatavyo: "nchi_state_county_municipality_agency_language-code_date.pdf". (au .txt) Kwa mfano: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Unda darasa mpya na kiufundi "ISpecificFix" katika mradi "michakato yaTranscriptts_Lib". </p>
</li>
<li>
<p> Taja darasa "nchi_state_county_municipality_agency_language-code". Kwa mfano: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Timiza njia ya darasa: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Kurekebisha () inapokea maandishi ya maandishi yaliyopo na inarudisha maandishi katika muundo ufuatao: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Darasa hili litakapomalizika, WorkflowApp itashughulikia maandishi mapya wakati yanaonekana katika "DATAFILES / RECEIVED". </p>

<p> Vidokezo: </p>

<p> Tunatumia System.Reflection kusisitiza darasa sahihi kulingana na jina la faili kusindika. </p>

<p> Tazama darasa "USA_PA_Philadelphia_Philadelphia_CityC Council_en" katika MchakatoTranscriptts_Lib kwa mfano. Unaweza kuelewa vizuri zaidi ambayo darasa hili linafanya kwa kuangalia athari za faili ya logi kwenye "kiboreshaji" ambacho hupitishwa kama hoja kwa Kurekebisha (). </p>

<p> Hatuonyeshi habari ifuatayo sasa, lakini tutataka kufanya hivi mwishowe. </p>

<ul>
<li> Viongozi katika mahudhurio </li>
<li> Miswada na maazimio yaliyoletwa </li>
<li> Matokeo ya upigaji kura </li>
</ul>
<p> Austin, TX - USA pia ina nakala za mikutano ya hadharani mkondoni. Hatari iliundwa inayoitwa "USA_TX_TravisCounty_Austin_CityC Council_en" katika mchakatoTranscriptts_Lib. Lakini njia ya Kurekebisha () haikuweza kutekelezwa. Nakala zinaweza kupatikana kutoka kwa wavuti yao: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX Halmashauri ya Jiji</a> </p>
<h1> Badilisha Dashibodi ya Mteja </h1><h2> Ongeza kadi ya huduma mpya </h2>
<ul>
<li> Katika mwendo wa terminal, nenda kwenye folda: FrontEnd / ClientApp </li>
<li> Ingiza: ng toa sehemu ya kipengele chako </li>
<li> Ongeza utendaji wako kwa faili katika: FrontEnd / ClientApp / src / programu / hulka yako </li>
<li> Ingiza kipengee kipya cha kadi ya gm-ndogo au gm-kubwa katika programu / dashi-kuu / dash-main.html. </li>
<li> Kurekebisha icon, iconcolor, kichwa, nk ya kipengee cha kadi. </li>
<li> Ikiwa unahitaji ufikiaji wa jina la eneo lililochaguliwa kwa sasa na wakala katika mdhibiti wako: 
<ul>
<li> Ongeza eneo na sifa za kuingiza la wakala kwenye kipengee chako </li>
<li> Ongeza mali na eneo la shirika la @Input katika mtawala wako. </li>
</ul></li>
</ul>
<p> (Tazama sampuli zingine kwenye dash-main.html) </p>
<h2> Panga upya kadi </h2><ol>
<li> Fungua faili: FrontEnd / ClientApp / src / programu / dash-main / dash-main.html. </li>
<li> Badilisha nafasi za kadi kwa kubadilisha nafasi ya vitu vya kadi gm-ndogo au gm-kubwa kwenye faili hii. </li></ol><h1> Magogo </h1>
<p> Faili za logi za WebApp na WorkflowApp ziko kwenye folda "magogo" kwenye mizizi ya suluhisho. </p>

<ul>
<li> "nlog-all- (tarehe) .log" ina ujumbe wote wa logi pamoja na mfumo. </li>
<li> Faili "nlog-mwenyewe- (tarehe) .log" ina ujumbe wa maombi tu. </li>
</ul>
<p> Hapo juu ya faili nyingi za sehemu kwenye ClientApp, "NoLog" imeelezewa. Badilisha thamani yake kutoka kwa kweli kwenda kwa uwongo kuwasha ukataji wa kiweko kwa sehemu tu hiyo. </p>
<h1> Jenga Maandishi </h1>
<p> Maandishi ya ujenzi wa Powershell yanaweza kupatikana katika Huduma / Maandishi </p>

<ul>
<li> BuildPublishAndDeploy.ps1 -Anda maandishi mengine ili kuunda kutolewa na kuipeleka. </li>
<li> Jenga-MtejaApp.ps1 - Tengeneza matoleo ya uzalishaji wa MtejaApp </li>
<li> Chapisha-WebApp.ps1 - Jenga folda ya "kuchapisha" ya WebApp </li>
<li> Copy-ClientAssets.ps1 - Nakili mali za mteja waApp kwa folda ya wWwroot WebApp </li>
<li> Deploy-PublishFolder.ps1 - Toa folda ya kuchapisha kwa mwenyeji wa mbali </li>
<li> Unda faili ya README.md ya Gethub kutoka faili za hati </li>
</ul>
<p> Deploy-PublishFolder.ps1 inapea programu kwa govmeeting.org, kwa kutumia FTP. Habari ya kuingia kwa FTP iko kwenye programu ya vifaa vya faili.Development.json kwenye folda ya SECRETS. Inayo FTP na siri zingine za kutumika katika maendeleo. Chini ni sehemu ya faili hii inayotumiwa na FTP: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
