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
<p> Tietokannan taulukot koostuvat: </p>
<ol>
<li> Todentamistaulukot. </li></ol>
<p> Microsoft Identity Service loi ne automaattisesti, kun "Authentication = Individual User Accounts" tarkistettiin, kun projekti rakennettiin. </p>
<ol start="2">
<li> Gov-kokouspöydät. </li></ol>
<p> Ne luodaan Entity Framework -sovelluksen "Code First" -ominaisuudella. EF lukee C# -luokat "Tietokanta / malli" -projektikirjastossa ja luo automaattisesti tietokantakaavan ja taulukot. </p>

<p> Katso "Asetukset" -sivulta tietokannan luominen ja käsitteleminen. </p>
<h1> kaavio </h1><h2> "Hallintoyksikkö" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th><th> Esimerkki 3 </th></tr>
<tr><td> Pääavain </td><td> ainutlaatuinen avain </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Nimi </td><td> yksikön nimi </td><td> Senaatti </td><td> kokoonpano </td><td> Suunnittelulautakunta </td></tr>
<tr><td> Maa </td><td> maan sijainti </td><td> Yhdysvallat </td><td> Yhdysvallat </td><td> Yhdysvallat </td></tr>
<tr><td> Osavaltio </td><td> valtion sijainti </td><td></td><td> Iowa </td><td> New Jersey </td></tr>
<tr><td> Lääni </td><td> läänin tai alueen sijainti </td><td></td><td></td><td> Gloucester </td></tr>
<tr><td> Kunnallis </td><td> Kaupunki tai kylä </td><td></td><td></td><td> Monroe Township </td></tr>
</table>

<p>
* Lisää esimerkkejä hallituksen yksiköiden taulukosta </p>

<table><tr><th> Ala </th><th> Esimerkki 4 </th><th> Esimerkki 5 </th></tr>
<tr><td> Pääavain </td><td> 4 </td><td> 5 </td></tr>
<tr><td> Nimi </td><td> Vidhan Sabha </td><td> Kunnanvaltuusto </td></tr>
<tr><td> Maa </td><td> Intia </td><td> Intia </td></tr>
<tr><td> Osavaltio </td><td> Andhra Pradesh </td><td> Andhra Pradesh </td></tr>
<tr><td> Lääni </td><td></td><td> Kadapan piiri </td></tr>
<tr><td> Kunnallis </td><td></td><td> Rayachoty </td></tr>
</table>

<p> Huomaa, että jos hallintoyksikkö on kansallisella tasolla, sen osavaltion, läänin ja kunnan sijaintipaikat ovat tyhjät. Jos yhteisö on valtion tasolla, sen läänin- ja kunnalliset sijainnit ovat tyhjät. </p>

<p> Tarvitaan esimerkkejä muista maista. Jos sinulla on muita esimerkkejä, muokkaa tätä asiakirjaa ja anna Pith-pyyntö Githubissa. Jos on syitä, miksi tämä ei toimi joissakin maissa, lähetä kysymys Github-julkaisusta. </p>
<hr /><h2> "Kokous" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th></tr>
<tr><td> Pääavain </td><td> ainutlaatuinen avain </td><td> 1 </td><td> 2 </td></tr>
<tr><td> GovEntity </td><td> avain hallintoelimeen </td><td> 2 (Yhdysvaltain senaatti) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Aika </td><td> tapaamisaika </td><td> 3. elokuuta &#39;14 19:30 </td><td> 2. toukokuuta &#39;14 13:00 </td></tr>
<tr><td> Teksti </td><td> tekstitys </td><td> "Kokous tulee tilauksesta. ..." </td><td> "Kokous kokoontuu. ..." </td></tr>
</table>
<hr /><h2> "Edustaja" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th></tr>
<tr><td> Pääavain </td><td> ainutlaatuinen avain </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Koko nimi </td><td> koko nimi </td><td> Tasavallan edustaja Steve Jones </td><td> Puheenjohtaja Ravi Anand </td></tr>
<tr><td> tunniste </td><td> henkilökohtainen tunniste </td><td> (päätetään </td><td> (päätetään) </td></tr>
</table>

<p> Kokouksissa puhujat voivat olla hallintoelimen tai suuren yleisön edustajia. Kummassakin tapauksessa samat ihmiset voivat osallistua kokouksiin useammassa kuin yhdessä julkisyhteisössä. Haluamme seurata, mitä sama edustaja sanoo kaikissa elimissä, joiden jäsen hän on. Siksi tarvitsemme yksilöllisen tunnisteen jokaiselle edustajalle. </p>

<p> Meidän on päätettävä, mitä tietoja tätä tunnistamista varten vaaditaan. Meillä ei selvästikään ole henkilön kansallista tunnusnumeroa jotain tällaista. Saatamme joutua käyttämään useamman kuin yhden kentän yhdistelmää jonkun tunnistamiseksi. Esimerkiksi osoite ja nimi. </p>

<p> Siellä on "edustaja" -taulukko, joka sisältää jokaiselle edustajalle yksilöllisen henkilökohtaisen tunnisteen. </p>
<hr /><h2> "RepresentativeToEntity" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th><th> Esimerkki 3 </th></tr>
<tr><td> Edustaja </td><td> avain edustajaan </td><td> 1 </td><td> 2 </td><td> 2 </td></tr>
<tr><td> GovEntity </td><td> avain hallintoelimeen </td><td> 5 </td><td> 7 </td><td> 9 </td></tr>
</table>

<p> Mukana on myös taulukko "RepresentativeToEntity", joka yhdistää edustajat ja hallitusyksiköt, joissa he palvelevat. Huomaa, että sama edustaja voi toimia useissa julkisyhteisöissä. </p>
<hr /><h2> "Citizen" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th></tr>
<tr><td> Pääavain </td><td> ainutlaatuinen avain </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Nimi </td><td> nimi </td><td> John J. </td><td> Rai S. </td></tr>
<tr><td> Tapaaminen </td><td> avain kokoukseen </td><td> 2 (Yhdysvaltain senaatin kokous 3. elokuuta &#39;14) </td><td> 4 (Vidhan Sabha -kokous 2. toukokuuta &#39;14) </td></tr>
</table>

<p> Yleisön jäsenille järjestetään "Citizen" -taulukko. Kansalaisten taulukossa on vieras avain, joka osoittaa kokoukseen, jossa tämä henkilö puhui. </p>

<p> Pitäisikö meidän yrittää seurata, mitä kansalaiset sanovat kaikissa kokouksissaan, joihin he osallistuvat? Ehkä se ei ole tarkoituksenmukaista. </p>

<p> Jos ei, ei tarvitse yrittää tunnistaa yksilöllisesti julkisia puhujia. Nimi, jonka henkilö antaa, kun hän puhuu kokouksessa, voidaan käyttää henkilön tunnistamiseen juuri kyseiselle kokoukselle. Meidän ei tarvitse korreloida nimeä kokouksissa. Saatamme jopa mieluummin tallentaa vain etunimen ja sukunimen. </p>
<hr /><h2> "Aihe" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th><th> Esimerkki 3 </th></tr>
<tr><td> Pääavain </td><td> ainutlaatuinen avain </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> GovEntity </td><td> avain hallintoelimeen </td><td> 2 (Yhdysvaltain senaatti) </td><td> 2 (Yhdysvaltain senaatti) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Tyyppi </td><td> Luokka tai aihe </td><td> Kategoria </td><td> Aihe </td><td> Kategoria </td></tr>
<tr><td> Nimi </td><td> aiheen nimi </td><td> terveys </td><td> Obamacare </td><td> koulutus </td></tr>
</table>

<p> Jokaisella hallituksen yksiköllä (esimerkiksi Yhdysvaltain senaatilla tai Zoning Boardilla Monroe Township, NJ, USA) on omat yksilölliset nimensä ryhmissä ja aiheissa, joita keskustellaan kokouksissaan. Siksi tunnistetaulukko sisältää vieraan avaimen, joka osoittaa julkisyhteisölle. </p>
<hr />
<p> Kokouksen koko teksti on merkkijono. Kaiuttimen sijainti- ja tunnisteiden sijainti -taulukot sisältävät osoittimet tekstiin, nimittäin aloitus- ja loppupisteet, joissa joko puhuja tai tunniste vaihtuvat. Ne ovat merkkiosoittimia tekstimerkkijonoon. </p>
<h2> "Kaiutintunnisteet" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th></tr>
<tr><td> PimaryKey </td><td> ainutlaatuinen avain </td><td> 1 </td><td> 2 </td></tr>
<tr><td> kaiutin </td><td> avain puhujaan </td><td> 1 (edustaja Jones) </td><td> 2 (puheenjohtaja. Anand) </td></tr>
<tr><td> Tapaaminen </td><td> avain kokoukseen </td><td> 1 (kokous 1) </td><td> 2 (kokous 2) </td></tr>
<tr><td> alkaa </td><td> kohta, kun puhuja alkaa puhua </td><td> 521 </td><td> 12045 </td></tr>
<tr><td> pää </td><td> kohta, kun puhuja lakkaa puhumasta </td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2> "Aihetaulut" -taulukko </h2>
<table><tr><th> Ala </th><th> merkitys </th><th> Esimerkki 1 </th><th> Esimerkki 2 </th></tr>
<tr><td> Pääavain </td><td> ainutlaatuinen avain </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Tag </td><td> avaimen tunniste </td><td> 1 (energia) </td><td> 2 (koulutus) </td></tr>
<tr><td> Tapaaminen </td><td> avain kokoukseen </td><td> 1 (kokous 1) </td><td> 2 (kokous 2) </td></tr>
<tr><td> alkaa </td><td> kohta, kun aihe alkaa </td><td> 750 </td><td> 14500 </td></tr>
<tr><td> pää </td><td> kohta, kun aihe pysähtyy </td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2> Tietojen koko </h2>
<p> Lopullisen kokouksen tietokanta on hyvin pieni. Tämän avulla voimme rakentaa sovelluksia, joissa suuri osa tiedoista tallennetaan paikallisesti käyttäjän tietokoneelle tai älypuhelimelle - korkea suorituskyky ja mahdollisuus käyttää sovellusta offline-tilassa. </p>
