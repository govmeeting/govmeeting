<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle"> Ubunifu </mat-card-title>
<markdown ngPreserveWhitespaces>

<p> Mchoro hapo chini unaonyesha mwingiliano kati ya vifaa vya programu. </p>

<ul>
<li>
<p> MtejaApp ni aina ya Angular Typeescript single page ambayo inaendesha kivinjari. Inatoa interface ya mtumiaji. </p>
</li>
<li>
<p> WebApp ni programu ya <a href="https://github.com/aspnet/home">Asp.Net Core</a> C# inayoendesha kwenye seva. Hujibu simu za WebApi. </p>
</li>
<li>
<p> WorkflowApp ni programu ya <a href="https://github.com/dotnet/core">DotNet Core</a> C#
# inayoendesha kwenye seva. Haina usindikaji wa bendi ya rekodi na Nakala. Inaweza pia kubadilishwa kuwa maktaba ambayo inaendesha kama sehemu ya mchakato wa WebApp. </p>
</li>
<li>
<p> Sehemu zingine za seva ni maktaba za DotNet Core C #. Zinatumiwa na wote WebApp & WorkflowApp. </p>
</li>
</ul><hr /><h2> Ubunifu wa Mfumo </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

<p> Sehemu zilizo kwenye mchoro hapo juu ni: </p>

<table style="width:100%">
<tr><th colspan="2"> Maombi </th></tr>
<tr><td> MtejaApp </td><td> SPA ya angular </td></tr>
<tr><td> WebApp </td><td> Mchakato wa seva ya wavuti ya Asp.Net </td></tr>
<tr><td> Programu ya kazi </td><td> Mchakato wa udhibiti wa seva ya kazi </td></tr>
<tr><th colspan="2"> Maktaba </th></tr>
<tr><td> GetOnlineFiles </td><td> Rudisha nakala za mkondoni na rekodi </td></tr>
<tr><td> Usindikaji </td><td> Futa na uandishi wa sauti. Unda sehemu za kazi. </td></tr>
<tr><td> Mchakato wa maandishi </td><td> Badilisha maandishi mbichi </td></tr>
<tr><td> Database ya Load </td><td> Hifadhi database na data kutoka kwa hati iliyokamilishwa </td></tr>
<tr><td> Mtumiaji wa Mtandao </td><td> Njia za kupata faili kutoka tovuti za mbali </td></tr>
<tr><td> GoogleCloudAccess </td><td> Njia za kupata huduma za Wingu la Google </td></tr>
<tr><td> FileDataRepositories </td><td> Hifadhi na Pata data ya faili ya kazi ya JSON </td></tr>
<tr><td> Hifadhidata za kumbukumbu </td><td> Hifadhi na Pata data ya Mfano kutoka kwa hifadhidata </td></tr>
<tr><td> DatabaseAccess </td><td> Pata hifadhidata kwa kutumia Mfumo wa Taasisi </td></tr>
</table>
<hr /><h2> Ubunifu wa Wateja </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

<p> Muundo wa ClientApp umeonyeshwa vyema na muundo wake wa Sehemu ya Angular </p>

<table style="width:100%">
<tr><th colspan="2"> Vipengele vya programu </th></tr>
<tr><td> Kichwa </td><td> Kichwa </td></tr>
<tr><td> Sidenav </td><td> Urambazaji wa Upinde </td></tr>
<tr><td> Dashibodi </td><td> Chombo cha vifaa vya dashibodi </td></tr>
<tr><td> Nyaraka </td><td> Chombo cha kurasa za nyaraka </td></tr>
<tr><th colspan="2"> Vipengele vya dashibodi </th></tr>
<tr><td> Kurekebisha </td><td> Rekebisha maandishi ya utambuzi wa Hotuba ya Auto </td></tr>
<tr><td> Vitunguu </td><td> Ongeza vitambulisho kwa nakala </td></tr>
<tr><td> Mtangazaji </td><td> Angalia maandishi yaliyokamilishwa </td></tr>
<tr><td> Mambo </td><td> Angalia habari juu ya maswala </td></tr>
<tr><td> Taadhari </td><td> Angalia na weka habari kwenye arifu </td></tr>
<tr><td> Viongozi </td><td> Angalia habari juu ya maafisa </td></tr>
<tr><td> (Wengine)) </td><td> Vipengele vingine vinavyotekelezwa </td></tr>
<tr><th colspan="2"> Huduma </th></tr>
<tr><td> Kupatikana kwa Virtual </td><td> Run mkutano wa kawaida </td></tr>
<tr><td> Ongea </td><td> Sehemu ya mazungumzo ya watumiaji </td></tr>
</table>
<hr /><h2> Ubunifu wa WebApp </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

<p> Kila moja ya API za Wavuti ni ndogo na piga hazina kuweka au kupata data kutoka kwa hifadhidata au mfumo wa faili. </p>

<table style="width:100%">
<tr><th colspan="2"> Watawala </th></tr>
<tr><td> Kurekebisha </td><td> Okoa na upate toleo la hivi karibuni la maandishi kuwa maandishi. </td></tr>
<tr><td> Vitunguu </td><td> Okoa na upate toleo la hivi karibuni la maandishi kuwa utambulishwa. </td></tr>
<tr><td> Kutazama </td><td> Pata hati mpya iliyokamilishwa ya hivi karibuni. </td></tr>
<tr><td> Govbodies </td><td> Okoa na upewe data ya serikali iliyosajiliwa. </td></tr>
<tr><td> Mikutano </td><td> Okoa na upate habari ya mkutano. </td></tr>
<tr><td> Video </td><td> Pata video ya mkutano. </td></tr>
<tr><td> Akaunti </td><td> Mchakato wa usajili wa watumiaji na kuingia. </td></tr>
<tr><td> Dhibiti </td><td> Watumiaji wanaweza kusimamia profaili zao. </td></tr>
<tr><td> Usimamizi </td><td> Msimamizi anaweza kusimamia watumiaji, sera na madai </td></tr>
<tr><th colspan="2"> Huduma </th></tr>
<tr><td> Barua pepe </td><td> Uthibitishaji wa barua pepe ya usajili. </td></tr>
<tr><td> Ujumbe </td><td> Dhibitisho la usajili wa kushughulikia kupitia ujumbe wa maandishi. </td></tr>
</table>
<hr /><h2> Ubunifu waApple ya Work Work </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

<p> Hali ya kazi ya mkusanyiko kwa mkutano maalum huhifadhiwa katika rekodi yake ya Mkutano katika hifadhidata. Kila moja ya vifaa vya kazi ya kazi hufanya kazi kwa kujitegemea. Kila mmoja huitwa ili kuangalia kazi inayopatikana. Kila sehemu itahoji hifadhidata kwa mikutano inayolingana na vigezo vya kazi inayopatikana. Ikiwa kazi itapatikana, wataifanya na kusasisha hali ya mkutano katika hifadhidata. </p>

<p> Ili kujenga mfumo wa nguvu, ambao unaweza kupona kutokana na kutofaulu, tutahitaji kutibu hatua kwenye mtiririko wa kazi kama "shughuli". Manunuzi ama anamaliza kikamilifu au sivyo. Ikiwa kuna shida zinazoweza kufichuliwa wakati wa hatua ya usindikaji, jimbo la mkutano huo linarejea katika hali halali ya mwisho. Nambari hiyo haitoi shughuli kwa sasa. (Gitub suala la kufuata) </p>

<p> Nambari ya upendeleo inapewa hapa chini kwa vifaa </p>

<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Kwa vyombo vyote vya serikali kwenye mfumo </li>
<ul>
<li> Angalia ratiba (s) za mikutano ili kupata </li>
<li> Rudisha faili ya kurekodi au nakala </li>
<li> Weka faili kwenye Hifadhidata \ folda iliyopokea </li>
</ul>
<li> Faili zinaweza pia kuwekwa kwenye folda Iliyopokelewa na upakiaji wa mtumiaji. </li>
</ul>
<li> Mchakato wa Kuandaa </li>
<ul>
<li> Kwa faili kwenye datafiles \ Imepokelewa na rekodi ya hifadhidata haipo: </li>
<ul>
<li> Chagua aina ya faili </li>
<li> Unda rekodi ya hifadhidata </li>
<li> hadhi ya kuweka = imepokelewa, kupitishwa = uongo </li>
<li> Tuma ujumbe wa meneja (wa): "Imepokelewa" </li>
</ul>
</ul>
<li> KuandikaRecordings </li>
<ul>
<li> Kwa rekodi zilizo na rekodi ya sourcet = = hadhi, imepokelewa, imepitishwa = kweli </li>
<ul>
<li> Unda folda ya kazi </li>
<li> seti ya hali = kuandika, kupitishwa = uongo </li>
<li> Andika kurekodi </li>
<li> seti ya hali = iliyotumwa, kupitishwa = uongo </li>
<li> Tuma ujumbe wa meneja (wa): "Imechapishwa" </li>
</ul>
</ul>
<li> Utaratibu wa maandishi </li>
<ul>
<li> Kwa maandishi na sourcetype = maandishi, hali = iliyopokelewa, kupitishwa = kweli </li>
<ul>
<li> Unda folda ya kazi </li>
<li> seti ya hali = usindikaji, kupitishwa = uongo </li>
<li> Mchakato wa maandishi </li>
<li> hadhi ya kuweka = kusindika, kupitishwa = uongo </li>
<li> Tuma ujumbe wa "meneja": Usindikaji </li>
</ul>
</ul>
<li> KusanidiKufanya </li>
<ul>
<li> Kwa rekodi zilizo na hadhi = iliyoandikishwa / kupitishwa = kweli </li>
<ul>
<li> Unda folda ya kazi </li>
<li> hadhi ya kuweka = kusoma, kupitishwa = uongo </li>
<li> Usomaji mwongozo sasa utafanyika </li>
</ul>
<li> Kwa rekodi zilizo na hadhi = uthibitisho </li>
<ul>
<li> Angalia ikiwa uthibitishaji unaonekana umekamilika. Ikiwa ni hivyo: </li>
<li> hali ya kuweka = uthibitisho, kupitishwa = uongo </li>
<li> tuma ujumbe wa meneja (wa): "Proofread" </li>
</ul>
</ul>
<li> KuongezaTagsToTranscript </li>
<ul>
<li> Kwa rekodi zilizo na hadhi = dhibitisho, kupitishwa = kweli AU kwa maandishi yaliyo na hali = kusindika, kupitishwa = kweli </li>
<ul>
<li> Unda folda ya kazi </li>
<li> seti ya hali = tagging, kupitishwa = uongo </li>
<li> Kuweka tagi mwongozo sasa kutafanyika </li>
</ul>
</ul>
<ul>
<li> Kwa maandishi na hali = tagging </li>
<ul>
<li> Angalia ikiwa tagi inaonekana kamili. Ikiwa ni hivyo: </li>
<li> hali ya kuweka = tagged, kupitishwa = uongo </li>
<li> tuma ujumbe wa meneja (wa): "Tagged" </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Kwa mikutano iliyo na hadhi = tagged, kupitishwa = kweli 
<ul>
<li> seti ya hali = kupakia, kupitishwa = uongo </li>
<li> Pakia yaliyomo kwenye mkutano kwenye hifadhidata </li>
<li> hali ya kuweka = kubeba, kupitishwa = uongo </li>
<li> Tuma ujumbe wa meneja (wa): "Umepakiwa" </li>
</ul>
</ul>
</ul><hr /><h2> Siri za Mtumiaji </h2>
<p> Unapofuatilia uwekaji wa mapato kutoka Github, unapata kila kitu isipokuwa folda ya "SECRETS". Folda hii inakaa nje ya hazina. Inayo habari ifuatayo ya "siri": </p>

<ul>
<li> MtejaId na Mteja kwa huduma ya idhini ya nje ya Google. </li>
<li> TovutiKey na Siri ya huduma ya Google ReCaptcha. </li>
<li> Sifa za Jukwaa la Wingu la Google. </li>
<li> Kamba ya uunganisho wa database. </li>
<li> Usimamizi la mtumiaji na nywila. </li>
</ul>
<p> Folda ya SECRETS inaweza kuwa na faili nne. </p>

<ul>
<li> vifaa vya programu.Development.json </li>
<li> vipandikizi.Uroduzi.json </li>
<li> vifaa vya vifaa.Staging.json </li>
<li> AndikaAudio.json </li>
</ul>
<p> TranscriptAudio.json ina sifa za Jukwaa la Wingu la Google. Kila faili zingine tatu zinaweza kuwa na mipangilio ya kila siri nyingine. vifaa.Production.json inapaswa kuwa na mipangilio yote ya uzalishaji. Mpangilio wowote ulio kwenye faili hizi utasimamia yale yaliyo kwenye Server / WebApp / app.settings.json. Faili hii imeingizwa kwenye kumbukumbu. </p>

<p> Ikiwa unataka mashine yako ya karibu kupata huduma za Google, unahitaji kuunda folda ya ndani "../SECRETS kuhusiana na mahali uwekaji wa rasilimali. Kwa mfano, unaweza kuongeza faili ya" vifaa vya usanifu. " json "kwake, ambayo ina funguo ambazo unapata kutoka Google. Tazama: Vifunguo vya <a href="home#google-api-keys">API ya Google</a> </p>
<hr /><h1> Nyaraka </h1>
<p> Hapo awali hati hizi zilihifadhiwa katika kurasa za Github Wiki. Lakini iliamuliwa kuhamisha kurasa hizo katika mradi kuu yenyewe, kwa sababu mbili: </p>

<ul>
<li> Hauwezi kufanya ombi la Bomba la mabadiliko kwenye kurasa za Github Wiki. Hii inafanya kuwa ngumu kwa washiriki wa jamii kubadilisha nyaraka. </li>
<li> Nyaraka zina uwezekano mkubwa wa kukaa katika kusawazisha na nambari ikiwa iko pamoja na nambari katika uwekaji sawa. PR moja ya mabadiliko ya nambari inaweza kujumuisha mabadiliko ya nyaraka yanayohusiana nayo. </li>
</ul>
<p> Hati hizo zimeandikwa katika Markdown na ziko Frontend / ClientApp / src / programu / mali / hati. </p>

</markdown>

<p> &lt;/mat- kadi&gt; </p>
