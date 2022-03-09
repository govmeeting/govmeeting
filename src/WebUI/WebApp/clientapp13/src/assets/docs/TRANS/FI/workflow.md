<p> Alla on toiminnallinen kuvaus ohjelmiston pääosista. </p>
<h2> Henkilökohtainen rekisteröinti </h2>
<ul>
<li> Rekisteröinnin aikana käyttäjät ilmoittavat kotipaikkansa (kaupunki, kaupunki, kylä, postinumero) jne. </li>
<li> Järjestelmä määrittelee sijaintinsa perusteella hallitsevat yhteisöt, joihin ne kuuluvat. (maa, osavaltio, lääni, kaupunki jne.) </li>
</ul><h2> Hallintoelimen rekisteröinti </h2>
<ul>
<li> Käyttäjä voi rekisteröidä minkä tahansa hallitsevan yksikön, johon he kuuluvat. </li>
<li> Syötettyihin tietoihin sisältyy: 
<ul>
<li> Nettisivun URL </li>
<li> Hallintovirkamiesten nimet </li>
<li> URL-osoitteet, joista löytyvät tekstikirjoitukset tai kokousäänitykset </li>
</ul></li>
<li> Muut tämän sijainnin käyttäjät näkevät jo syötetyt tiedot. He voivat äänestää minkä tahansa tietokohteen oikeellisuudesta ja antaa vaihtoehtoisia arvoja. </li>
<li> Ääni kertyy jokaisesta data-arvosta. Eniten ääniä saaneista arvoista tulee virallisia arvoja. <a href="https://github.com/govmeeting/govmeeting/issues/62">Github-numero
# 62</a> </li>
</ul><h2> Tuo nauhoituksia tai kopioita </h2>
<ul>
<li> Järjestelmä lataa olemassa olevat online-nauhoitukset tai -kopiot säännöllisin väliajoin valtion elimen rekisteröinnissä ilmoitetuista paikoista. </li>
<li> Käyttäjät voivat myös ladata nauhoituksia tai kopioita. </li>
<li> Monissa paikoissa ei toimiteta kokousten kopioita eikä tallenteita. Govmeeting tarjoaa smartphome-sovelluksen, jonka avulla käyttäjät voivat tallentaa ja ladata kokouksen nauhoituksen henkilökohtaisesti. <a href="https://github.com/govmeeting/govmeeting/issues/18">Github-numero
# 18</a> </li>
</ul><h2> Esiprosessoida olemassa olevat tekstit </h2>
<ul>
<li> Muunna tekstikirjat tekstiksi. Usein olemassa olevat tekstikirjoitukset ovat muissa muodoissa, kuten PDF. Ne muunnetaan selkeäksi tekstiksi, jotta sitä voidaan käsitellä helpommin. </li>
<li> Pura tietoa, kuten kaiutin- ja osionimet. </li>
</ul><h2> Tallenna tekstitykset puheentunnistuksen avulla </h2>
<ul>
<li> Muunna nauhoitukset ensisijaisiksi web-videoformaateiksi (mp4, ogg ja webm.) Tämä tekee niistä helpommin saatavissa kaikentyyppisissä laitteissa. </li>
<li> Pura ja yhdistä ääniraidat, jos niitä on enemmän kuin yksi. </li>
<li> Lataa äänitiedosto Google Cloud -tallennustilaan valmistautumaan transkriptioon. </li>
<li> Soita asynkroniselle Google Speech -sovellusliittymälle suorittaa automaattinen äänentunnistus. </li>
<li> Suorita puhujamuutoksen tunnistus. Tätä varten on olemassa Google-sovellusliittymä. </li>
<li> Lisää kaiuttimien tunnistetiedot. Tämä käyttää puheprosessointiohjelmistoa palvelimella. </li>
<li> Pane tiedot JSON-muotoon jatkokäsittelyä varten. </li>
<li> Jaa video-, ääni- ja tekstitiedostot 3 minuutin työsegmentteihin, jotta useat vapaaehtoiset voivat työskennellä samanaikaisesti oikolukuissa. </li>
</ul><h2> Oikoluku transkriboitu teksti [Manuaalinen vaihe] </h2>
<ul>
<li> Oikoluku tekstissä virheiden varalta. Tarjoa käyttäjäystävällinen käyttöliittymä virheiden korjaamiseksi nopeasti. </li>
<li> Oikeita tietoja, kuten kaiuttimien ja osastojen nimet. </li>
</ul>
<p> Govmeeting yrittää tehdä käsittelystä mahdollisimman automaattisen. Mutta tietokoneet eivät ole vielä niin älykkäitä kuin haluaisimme. Ihmisiä tarvitaan edelleen virheiden korjaamiseksi. Mutta tietokoneet tulevat päivittäin älykkäämmiksi, ja tämän työn pitäisi saada yhä vähemmän. </p>
<h2> Lisää kysymystageja [Manuaalinen vaihe] </h2>
<ul>
<li> Yksi tärkeimmistä töistä on tunnisteiden tai metatietojen lisääminen oikein transkriptioon. Tämän avulla: 
<ul>
<li> tiedot ovat helposti löydettävissä. </li>
<li> hakemisto, joka indeksoidaan ja selataan nopeasti </li>
<li> hälytykset, jotka käyttäjä asettaa tietyistä asioista </li>
</ul></li>
<li> Asioiden nimet on määritettävä ihmisille, ei tietokoneille. Tämä on paras tapa varmistaa niiden merkityksellisyys. </li>
<li> On tärkeää, että tarjotaan erittäin helppo käyttää ja nopea käyttöliittymä. </li>
</ul>
<p> Jatkossa ehkä tämän vaiheen voi tehdä ensisijaisesti tietokone. Mutta ei kaikki ole huono asia, että tarvitset käsityötä yhteisön vapaaehtoisilta. Se auttaa yhdistämään ihmisiä yhteiseen tarkoitukseen. Jos tämä on pieni kaupunki, 35 000, ei pitäisi olla niin vaikeaa värväämään kymmenkunta, jotta voisit antaa lyhyen ajan kuukaudessa. </p>
<h2> Asutut relaatiotietokanta </h2>
<p> Tiedot laitetaan relaatiotietokantaan, jotta niihin pääsee nopeasti useilla kriteereillä. </p>
<h2> Tiedot ovat nyt käytettävissä </h2>
<ul>
<li> Laaja ja hakukelpoinen kopio on nyt saatavana </li>
<li> Yhteenveto kokouksessa käsitellyistä asioista lähetetään sitä pyytäville. </li>
<li> Hälytykset lähetetään tietyistä asioista niitä pyytäville. </li>
</ul><h2> Virtuaalikokous järjestetään. </h2>
<ul>
<li> Esityslista laaditaan todellisen kokouksen aiheiden perusteella. </li>
<li> Kutsut lähetetään yhteisön jäsenille. </li>
<li> Kutsu sisältää pyynnöt mahdollisista lisäohjelmista. </li>
<li> Kun vastaukset on saatu, äänestyskierros lähetetään osallistujille. Tässä äänestyskierrossa jäsenet voivat äänestää niistä, joista ehdotetut uudet esityslistan kohdat sisällytetään. </li>
<li> Muutaman päivän sisällä järjestetään virtuaalinen kokous. </li>
</ul><h2> Työnkulun hallinta </h2>
<p> Jotkut yllä olevista työnkulun vaiheista suoritetaan automaattisesti tietokoneella ja osa vapaaehtoisilla. Työnkulussa on paikkoja, joissa oikean ihmisen tulee varmistaa, että on hyvä jatkaa: </p>

<ul>
<li> Varmista, että kopioiden ja nauhoitusten hakemiseen käytettävät URL-osoitteet vaikuttavat kelvollisilta. </li>
<li> Varmista, että noudettujen tiedostojen sisältö näyttää kelvolliselta. </li>
<li> Varmista, että esikäsittelyn lähtö näyttää kelvolliselta. </li>
<li> Varmista, että puheen ja tekstin muuntaminen näyttää kelvolliselta. </li>
<li> Varmista, että tekstityksen oikoluku näyttää valmis. </li>
<li> Varmista, että tunnisteiden lisääminen tekstitykseen näyttää valmis. </li>
<li> Varmista, että lopullinen kopiointitiedot ovat täydellisiä ja kelvollisia. </li>
</ul>
<p> On oltava tapa, jolla yhden tai useamman sijaintiin rekisteröityneen käyttäjän oikeudet voidaan nostaa "johtajan" asemaan. </p>

<ul>
<li> Johtajalle ilmoitetaan, kun päätöstä odotetaan työnkulussa. </li>
<li> Johtaja voisi sitten kirjautua sisään ja antaa tai evätä hyväksynnän työnkulun jatkamiselle. </li>
</ul>
