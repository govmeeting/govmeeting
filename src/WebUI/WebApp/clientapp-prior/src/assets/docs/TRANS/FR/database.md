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
</style><p> Les tables de la base de données sont composées de: </p><ol>
<li> Tables d&#39;authentification. </li></ol><p> Celles-ci ont été créées automatiquement par Microsoft Identity Service lorsque "Authentification = Comptes d&#39;utilisateurs individuels" a été vérifié lors de la création du projet. </p><ol start="2">
<li> Tables de réunion. </li></ol><p> Celles-ci sont créées par la fonction "Code First" d&#39;Entity Framework. EF lit les classes C# dans la bibliothèque de projet "Database / Model" et génère automatiquement le schéma et les tables de la base de données. </p><p> Voir la page du document "Configuration" pour créer et travailler avec la base de données. </p><h1> Schéma </h1><h2> Tableau "Entité gouvernementale" </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th><th> Exemple 3 </th></tr>
<tr><td> Clé primaire </td><td> clé unique </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Nom </td><td> nom de l&#39;entité </td><td> Sénat </td><td> Assemblée </td><td> Conseil de planification </td></tr>
<tr><td> Pays </td><td> emplacement du pays </td><td> Etats-Unis </td><td> Etats-Unis </td><td> Etats-Unis </td></tr>
<tr><td> Etat </td><td> emplacement de l&#39;État </td><td></td><td> Iowa </td><td> New Jersey </td></tr>
<tr><td> Comté </td><td> emplacement du comté ou de la région </td><td></td><td></td><td> Gloucester </td></tr>
<tr><td> Municipal </td><td> ville ou village </td><td></td><td></td><td> Canton de Monroe </td></tr>
</table>
<p>
* Plus d&#39;exemples pour le tableau des entités gouvernementales </p>
<table><tr><th> Champ </th><th> Exemple 4 </th><th> Exemple 5 </th></tr>
<tr><td> Clé primaire </td><td> 4 </td><td> 5 </td></tr>
<tr><td> Nom </td><td> Vidhan Sabha </td><td> Conseil municipal </td></tr>
<tr><td> Pays </td><td> Inde </td><td> Inde </td></tr>
<tr><td> Etat </td><td> Andhra Pradesh </td><td> Andhra Pradesh </td></tr>
<tr><td> Comté </td><td></td><td> District de Kadapa </td></tr>
<tr><td> Municipal </td><td></td><td> Rayachoty </td></tr>
</table>
<p> Notez que si l&#39;entité gouvernementale est au niveau national, ses emplacements d&#39;État, de comté et municipaux sont nuls. Si l&#39;entité est au niveau de l&#39;État, ses emplacements de comté et municipaux sont nuls, etc. </p><p> Des exemples pour d&#39;autres pays sont nécessaires. Si vous avez d&#39;autres exemples, veuillez modifier ce document et émettre une requête Pull dans Github. S&#39;il y a des raisons pour lesquelles cela ne fonctionnera pas pour certains pays, veuillez soumettre un problème via Github. </p><hr /><h2> "Table de réunion </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th></tr>
<tr><td> Clé primaire </td><td> clé unique </td><td> 1 </td><td> 2 </td></tr>
<tr><td> GouvEntity </td><td> clé de l&#39;entité gouvernementale </td><td> 2 (Sénat américain) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Temps </td><td> heure de rendez-vous </td><td> 3 août &#39;14 19:30 </td><td> 2 mai &#39;14 13:00 </td></tr>
<tr><td> Texte </td><td> texte de transcription </td><td> "La réunion va commencer. ..." </td><td> "L&#39;assemblée se réunira. ..." </td></tr>
</table>
<hr /><h2> Tableau "représentatif" </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th></tr>
<tr><td> Clé primaire </td><td> clé unique </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Nom complet </td><td> nom complet </td><td> Représentant Steve Jones </td><td> Président Ravi Anand </td></tr>
<tr><td> Identifiant </td><td> identifiant personnel </td><td> (être décidé </td><td> (être décidé) </td></tr>
</table>
<p> Les intervenants aux réunions pourraient être des représentants de l&#39;entité dirigeante ou du grand public. Dans les deux cas, il peut y avoir les mêmes personnes assistant à des réunions dans plusieurs entités gouvernementales. Nous voudrons suivre ce que dit le même représentant dans chacun des organes dont il est membre. Par conséquent, nous avons besoin d&#39;un identifiant unique pour chaque représentant. </p><p> Nous devrons décider des informations requises pour cette identification. De toute évidence, nous n&#39;aurons pas le numéro d&#39;identité national d&#39;une personne de cette nature. Nous devrons peut-être utiliser une combinaison de plusieurs champs pour identifier quelqu&#39;un. Par exemple, adresse et nom. </p><p> Il y aura un tableau "Représentant" qui contient un identifiant personnel unique pour chaque représentant. </p><hr /><h2> Tableau "RepresentativeToEntity" </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th><th> Exemple 3 </th></tr>
<tr><td> Représentant </td><td> clé du représentant </td><td> 1 </td><td> 2 </td><td> 2 </td></tr>
<tr><td> GouvEntity </td><td> clé de l&#39;entité gouvernementale </td><td> 5 </td><td> 7 </td><td> 9 </td></tr>
</table>
<p> Il y aura également un tableau, "RepresentativeToEntity", qui relie les représentants et les entités gouvernementales sur lesquelles ils siègent. Notez qu&#39;un même représentant peut siéger sur plusieurs entités gouvernementales. </p><hr /><h2> Table "Citoyen" </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th></tr>
<tr><td> Clé primaire </td><td> clé unique </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Nom </td><td> Nom </td><td> John J. </td><td> Rai S. </td></tr>
<tr><td> Réunion </td><td> clé de la réunion </td><td> 2 (réunion du Sénat américain le 3 août 2014) </td><td> 4 (réunion de Vidhan Sabha le 2 mai 14) </td></tr>
</table>
<p> Il y aura une table "Citoyen" pour les membres du public. La table Citizen contiendra une clé étrangère pointant vers la réunion à laquelle cette personne s&#39;est exprimée. </p><p> Devrions-nous essayer de suivre ce que les membres du public disent à travers toutes les réunions auxquelles ils assistent? Ce n&#39;est peut-être pas approprié. </p><p> Sinon, il n&#39;est pas nécessaire d&#39;essayer d&#39;identifier de manière unique les orateurs publics. Le nom que la personne donne lorsqu&#39;elle parle lors d&#39;une réunion peut être utilisé pour identifier quelqu&#39;un juste pour cette réunion. Nous n&#39;avons pas besoin de corréler ce nom entre les réunions. Nous pouvons même préférer simplement stocker le prénom et la dernière initiale. </p><hr /><h2> Tableau "Thème" </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th><th> Exemple 3 </th></tr>
<tr><td> Clé primaire </td><td> clé unique </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> GouvEntity </td><td> clé de l&#39;entité gouvernementale </td><td> 2 (Sénat américain) </td><td> 2 (Sénat américain) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Type </td><td> Catégorie ou sujet </td><td> Catégorie </td><td> Sujet </td><td> Catégorie </td></tr>
<tr><td> Nom </td><td> Nom du sujet </td><td> Santé </td><td> Obamacare </td><td> éducation </td></tr>
</table>
<p> Chaque entité gouvernementale (par exemple le Sénat américain ou le Zoning Board de Monroe Township, NJ, États-Unis) aura ses propres noms uniques pour les catégories et les sujets abordés lors de leurs réunions. Par conséquent, la table Tag Name contient une clé étrangère pointant vers l&#39;entité gouvernementale. </p><hr /><p> La transcription complète de la réunion est une chaîne de texte. Les tables Emplacement du haut-parleur et Emplacement du tag contiennent des pointeurs dans le texte, à savoir les points de début et de fin auxquels le haut-parleur ou le tag change. Ce seront des pointeurs de caractères dans la chaîne de texte. </p><h2> Tableau "Tags des enceintes" </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th></tr>
<tr><td> PimaryKey </td><td> clé unique </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Orateur </td><td> clé de l&#39;orateur </td><td> 1 (représentant Jones) </td><td> 2 (président. Anand) </td></tr>
<tr><td> Réunion </td><td> clé de la réunion </td><td> 1 (réunion
# 1) </td><td> 2 (réunion n ° 2) </td></tr>
<tr><td> Début </td><td> pointer quand l&#39;orateur commence à parler </td><td> 521 </td><td> 12045 </td></tr>
<tr><td> Fin </td><td> pointer quand l&#39;orateur cesse de parler </td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2> Tableau "Tags de sujet" </h2>
<table><tr><th> Champ </th><th> Sens </th><th> Exemple 1 </th><th> Exemple 2 </th></tr>
<tr><td> Clé primaire </td><td> clé unique </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Étiquette </td><td> clé de tag </td><td> 1 (énergie) </td><td> 2 (éducation) </td></tr>
<tr><td> Réunion </td><td> clé de la réunion </td><td> 1 (réunion
# 1) </td><td> 2 (réunion n ° 2) </td></tr>
<tr><td> Début </td><td> point au début du sujet </td><td> 750 </td><td> 14500 </td></tr>
<tr><td> Fin </td><td> point où le sujet s&#39;arrête </td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2> Taille des données </h2><p> La taille de la base de données des réunions finales est très petite. Cela nous permettra de créer des applications où la plupart des données sont stockées localement sur l&#39;ordinateur ou le smartphone d&#39;un utilisateur - pour des performances élevées et la possibilité d&#39;exécuter l&#39;application hors ligne. </p>
