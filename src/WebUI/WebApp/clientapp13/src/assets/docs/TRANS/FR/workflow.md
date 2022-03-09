<p> Vous trouverez ci-dessous une description fonctionnelle des principaux éléments du logiciel. </p><h2> Inscription individuelle </h2>
<ul>
<li> Lors de l&#39;inscription, les utilisateurs précisent leur domicile (ville, ville, village, code postal, etc.). </li>
<li> En fonction de leur emplacement, le système détermine les entités dirigeantes auxquelles ils appartiennent. (pays, état, comté, ville / ville, etc.) </li>
</ul><h2> Inscription auprès d&#39;un organisme gouvernemental </h2>
<ul>
<li> Un utilisateur peut enregistrer n&#39;importe laquelle des entités dirigeantes auxquelles il appartient. </li>
<li> Les informations saisies comprendront: 
<ul>
<li> URL de site web </li>
<li> Noms des dirigeants </li>
<li> URL où se trouvent les transcriptions ou les enregistrements de réunions </li>
</ul></li>
<li> Les autres utilisateurs de cet emplacement verront les données déjà entrées. Ils peuvent voter sur l&#39;exactitude de tout élément de données et entrer des valeurs alternatives. </li>
<li> Les votes s&#39;accumuleront pour chaque valeur de données. Les valeurs avec le plus de votes deviennent les valeurs officielles. <a href="https://github.com/govmeeting/govmeeting/issues/62">Numéro Github
# 62</a> </li>
</ul><h2> Importer des enregistrements ou des transcriptions </h2>
<ul>
<li> Le système téléchargera des enregistrements ou des transcriptions en ligne existants selon un horaire régulier à partir des emplacements spécifiés dans l&#39;enregistrement de l&#39;organisme gouvernemental. </li>
<li> Les utilisateurs ont également la possibilité de télécharger des enregistrements ou des transcriptions. </li>
<li> De nombreux endroits ne fournissent ni transcriptions ni enregistrements de leurs réunions. Govmeeting fournira une application smartphome que les utilisateurs peuvent utiliser pour enregistrer et télécharger personnellement un enregistrement de réunion. <a href="https://github.com/govmeeting/govmeeting/issues/18">Numéro Github
# 18</a> </li>
</ul><h2> Pré-traiter les transcriptions existantes </h2>
<ul>
<li> Convertissez les transcriptions en texte brut. Les transcriptions existantes sont souvent dans d&#39;autres formats comme PDF. Ceux-ci sont convertis en texte brut afin d&#39;être plus facilement traités. </li>
<li> Extrayez des informations telles que les noms des haut-parleurs et des sections. </li>
</ul><h2> Transcrire des enregistrements à l&#39;aide de la reconnaissance vocale </h2>
<ul>
<li> Convertissez les enregistrements aux formats vidéo Web principaux (mp4, ogg et webm.) Cela les rend plus accessibles sur tous les types d&#39;appareils. </li>
<li> Extraire et fusionner des pistes audio si plusieurs. </li>
<li> Téléchargez le fichier audio sur le stockage Google Cloud pour préparer la transcription. </li>
<li> Appelez l&#39;API Google Speech asynchrone pour effectuer la reconnaissance vocale automatique. </li>
<li> Effectuez la reconnaissance de changement de haut-parleur. Il existe une API Google pour cela. </li>
<li> Ajoutez l&#39;identification du locuteur. Cela utilisera un logiciel de traitement de la parole sur le serveur. </li>
<li> Mettez les informations dans un format JSON pour un traitement ultérieur. </li>
<li> Divisez les fichiers vidéo, audio et de transcription en segments de travail de 3 minutes, afin que plusieurs volontaires puissent travailler simultanément sur la relecture. </li>
</ul><h2> Relire le texte transcrit [Étape manuelle] </h2>
<ul>
<li> Relire le texte des erreurs. Fournissez une interface conviviale pour corriger rapidement les erreurs. </li>
<li> Informations correctes telles que les noms des haut-parleurs et des sections. </li>
</ul><p> Govmeeting tente de rendre le traitement aussi automatique que possible. Mais les ordinateurs ne sont pas encore aussi intelligents que nous le souhaiterions. Les humains sont encore nécessaires pour corriger leurs erreurs. Mais chaque jour, les ordinateurs deviennent plus intelligents et ce travail devrait continuer de moins en moins. </p><h2> Ajouter des balises de problème [Étape manuelle] </h2>
<ul>
<li> L&#39;une des tâches les plus importantes consiste à ajouter correctement des balises ou des métadonnées à la transcription. C&#39;est ce qui permet: 
<ul>
<li> informations à localiser facilement. </li>
<li> une transcription à indexer et parcourir rapidement </li>
<li> alertes à définir par l&#39;utilisateur sur des problèmes spécifiques </li>
</ul></li>
<li> Les noms des problèmes doivent être attribués par des personnes et non par des ordinateurs. C&#39;est le meilleur moyen de s&#39;assurer qu&#39;ils sont significatifs. </li>
<li> Il est important de fournir une interface utilisateur très facile à utiliser et rapide. </li>
</ul><p> À l&#39;avenir, cette étape peut peut-être également être principalement effectuée par un ordinateur. Mais ce n&#39;est pas une mauvaise chose d&#39;avoir besoin d&#39;un travail manuel de la part des bénévoles de la communauté. Il aide à unir les gens pour une cause commune. S&#39;il s&#39;agit d&#39;une petite ville de 35 000 habitants, il ne devrait pas être si difficile d&#39;enrôler une douzaine pour donner un peu de temps chaque mois. </p><h2> Remplir la base de données relationnelle </h2><p> Les données sont placées dans une base de données relationnelle afin de pouvoir y accéder rapidement en utilisant plusieurs critères. </p><h2> Les données sont maintenant disponibles pour utilisation </h2>
<ul>
<li> Une transcription accessible et consultable est maintenant disponible </li>
<li> Un résumé des questions discutées lors de la réunion est envoyé à ceux qui le demandent. </li>
<li> Des alertes sont envoyées sur des questions spécifiques à ceux qui en font la demande. </li>
</ul><h2> Une réunion virtuelle est organisée. </h2>
<ul>
<li> Un ordre du jour est créé en fonction des problèmes rencontrés lors de la réunion réelle. </li>
<li> Les invitations sont envoyées aux membres de la communauté. </li>
<li> L&#39;invitation comprend des demandes de possibles points supplémentaires à l&#39;ordre du jour. </li>
<li> Lorsque les réponses sont reçues, un bulletin de vote est envoyé à ceux qui y assisteront. Sur ce bulletin de vote, les membres peuvent voter sur les nouveaux points à inscrire à l&#39;ordre du jour. </li>
<li> En quelques jours, une réunion virtuelle a lieu. </li>
</ul><h2> Gestion du workflow </h2><p> Certaines des étapes ci-dessus sont effectuées automatiquement par ordinateur et d&#39;autres manuellement par des bénévoles. Il y a des endroits dans le flux de travail où une personne réelle doit vérifier qu&#39;il est OK de continuer: </p>
<ul>
<li> Vérifiez que les URL de récupération des transcriptions et des enregistrements semblent valides. </li>
<li> Vérifiez que le contenu des fichiers récupérés semble valide. </li>
<li> Vérifiez que la sortie du prétraitement semble valide. </li>
<li> Vérifiez que la conversion de la parole en texte semble valide. </li>
<li> Vérifiez que la relecture de la transcription semble terminée. </li>
<li> Vérifiez que l&#39;ajout de balises à la transcription semble terminé. </li>
<li> Vérifiez que les données de transcription finales semblent complètes et valides. </li>
</ul><p> Il doit exister un moyen d&#39;élever les droits d&#39;un ou plusieurs utilisateurs enregistrés d&#39;un emplacement à un poste de «gestionnaire». </p>
<ul>
<li> Les gestionnaires seraient informés chaque fois qu&#39;une décision est en attente dans le flux de travail. </li>
<li> Un responsable peut alors se connecter et donner ou refuser l&#39;approbation pour que le flux de travail se poursuive. </li>
</ul>
