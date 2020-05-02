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
<p> As tabelas no banco de dados consistem em: </p>
<ol>
<li> Tabelas de autenticação. </li></ol>
<p> Eles foram criados automaticamente pelo Microsoft Identity Service quando "Autenticação = contas de usuário individuais" foi verificada quando o projeto foi criado pela primeira vez. </p>
<ol start="2">
<li> Mesas de governo. </li></ol>
<p> Eles são criados pelo recurso "Code First" do Entity Framework. O EF lê as classes C# na biblioteca de projetos "Banco de Dados / Modelo" e gera automaticamente o esquema e as tabelas do banco de dados. </p>

<p> Consulte a página do documento "Configuração" para criar e trabalhar com o banco de dados. </p>
<h1> Esquema </h1><h2> Tabela "Entidade do governo" </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th><th> Exemplo 3 </th></tr>
<tr><td> Chave primária </td><td> Chave única </td><td> 1 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Nome </td><td> nome da entidade </td><td> Senado </td><td> Montagem </td><td> Conselho de Planejamento </td></tr>
<tr><td> País </td><td> localização do país </td><td> EUA </td><td> EUA </td><td> EUA </td></tr>
<tr><td> Estado </td><td> localização do estado </td><td></td><td> Iowa </td><td> Nova Jersey </td></tr>
<tr><td> município </td><td> local do condado ou região </td><td></td><td></td><td> Gloucester </td></tr>
<tr><td> Municipal </td><td> cidade ou vila </td><td></td><td></td><td> Monroe Township </td></tr>
</table>

<p>
* Mais exemplos para a tabela Entidade governamental </p>

<table><tr><th> Campo </th><th> Exemplo 4 </th><th> Exemplo 5 </th></tr>
<tr><td> Chave primária </td><td> 4 </td><td> 5 </td></tr>
<tr><td> Nome </td><td> Vidhan Sabha </td><td> Conselho municipal </td></tr>
<tr><td> País </td><td> Índia </td><td> Índia </td></tr>
<tr><td> Estado </td><td> Andhra Pradesh </td><td> Andhra Pradesh </td></tr>
<tr><td> município </td><td></td><td> Kadapa district </td></tr>
<tr><td> Municipal </td><td></td><td> Rayachoty </td></tr>
</table>

<p> Observe que, se a entidade governamental estiver em nível nacional, seus locais de estado, município e município serão nulos. Se a entidade estiver no nível estadual, seus locais de condado e município serão nulos etc. </p>

<p> São necessários exemplos para outros países. Se você tiver outros exemplos, edite este documento e emita uma solicitação de recebimento no Github. Se houver motivos para isso não funcionar em alguns países, envie um problema ao Github. </p>
<hr /><h2> "Mesa de reunião </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th></tr>
<tr><td> Chave primária </td><td> Chave única </td><td> 1 1 </td><td> 2 </td></tr>
<tr><td> GovEntity </td><td> chave para entidade governamental </td><td> 2 (Senado dos EUA) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Tempo </td><td> hora do encontro </td><td> 3 de agosto de &#39;14 19:30 </td><td> 2 de maio de &#39;14 13:00 </td></tr>
<tr><td> Texto </td><td> texto de transcrição </td><td> "A reunião chegará a hora. ..." </td><td> "A assembléia se reunirá. ..." </td></tr>
</table>
<hr /><h2> Tabela "Representativa" </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th></tr>
<tr><td> Chave primária </td><td> Chave única </td><td> 1 1 </td><td> 2 </td></tr>
<tr><td> Nome completo </td><td> nome completo </td><td> Representante Steve Jones </td><td> Presidente Ravi Anand </td></tr>
<tr><td> Identificador </td><td> identificador pessoal </td><td> (a ser decidido </td><td> (a ser decidido) </td></tr>
</table>

<p> Os oradores das reuniões podem ser representantes da entidade governante ou do público em geral. Em ambos os casos, pode haver as mesmas pessoas participando de reuniões em mais de uma entidade governamental. Queremos acompanhar o que o mesmo representante diz em cada um dos órgãos dos quais ele / ela é membro. Portanto, precisamos de um identificador exclusivo para cada representante. </p>

<p> Precisamos decidir sobre quais informações são necessárias para essa identificação. Obviamente, não teremos o número de identidade nacional de uma pessoa dessa natureza. Podemos precisar usar uma combinação de mais de um campo para identificar alguém. Por exemplo, endereço e nome. </p>

<p> Haverá uma tabela "Representante" que contém um identificador pessoal exclusivo para cada representante. </p>
<hr /><h2> Tabela "RepresentativeToEntity" </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th><th> Exemplo 3 </th></tr>
<tr><td> Representante </td><td> chave para o representante </td><td> 1 1 </td><td> 2 </td><td> 2 </td></tr>
<tr><td> GovEntity </td><td> chave para entidade governamental </td><td> 5 </td><td> 7 </td><td> 9 </td></tr>
</table>

<p> Também haverá uma tabela, "RepresentativeToEntity", que vincula os representantes e as entidades governamentais em que atuam. Observe que o mesmo representante pode servir em várias entidades governamentais. </p>
<hr /><h2> Mesa "Cidadão" </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th></tr>
<tr><td> Chave primária </td><td> Chave única </td><td> 1 1 </td><td> 2 </td></tr>
<tr><td> Nome </td><td> nome </td><td> John J. </td><td> Rai S. </td></tr>
<tr><td> encontro </td><td> chave para a reunião </td><td> 2 (reunião do Senado dos EUA em 3 de agosto de 14) </td><td> 4 (reunião de Vidhan Sabha em 2 de maio de 14) </td></tr>
</table>

<p> Haverá uma tabela "Cidadão" para membros do público. A tabela Citizen conterá uma chave estrangeira apontando para a reunião em que essa pessoa falou. </p>

<p> Devemos tentar rastrear o que os membros do público dizem em todas as reuniões em que participam? Talvez isso não seja apropriado. </p>

<p> Caso contrário, não é necessário tentar identificar exclusivamente oradores públicos. O nome que a pessoa dá quando fala em uma reunião pode ser usado para identificar alguém apenas para essa reunião. Não precisamos correlacionar esse nome entre as reuniões. Podemos até preferir apenas armazenar o primeiro nome e a última inicial. </p>
<hr /><h2> Tabela "Tópico" </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th><th> Exemplo 3 </th></tr>
<tr><td> Chave primária </td><td> Chave única </td><td> 1 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> GovEntity </td><td> chave para entidade governamental </td><td> 2 (Senado dos EUA) </td><td> 2 (Senado dos EUA) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Tipo </td><td> Categoria ou Tópico </td><td> Categoria </td><td> Tópico </td><td> Categoria </td></tr>
<tr><td> Nome </td><td> nome do tópico </td><td> Saúde </td><td> Obamacare </td><td> Educação </td></tr>
</table>

<p> Cada entidade governamental (por exemplo, o senado dos EUA ou o Conselho de Zoneamento em Monroe Township, NJ, EUA) terá seus próprios nomes exclusivos para categorias e tópicos discutidos em suas reuniões. Portanto, a tabela Nome da tag contém uma chave estrangeira apontando para a entidade governamental. </p>
<hr />
<p> A transcrição completa da reunião é uma sequência de texto. As tabelas Local do alto-falante e Local do tag contêm ponteiros para o texto, ou seja, os pontos inicial e final nos quais o alto-falante ou o tag são alterados. Estes serão ponteiros de caracteres para a sequência de texto. </p>
<h2> Tabela "Tags de alto-falante" </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th></tr>
<tr><td> PimaryKey </td><td> Chave única </td><td> 1 1 </td><td> 2 </td></tr>
<tr><td> Alto falante </td><td> chave para o alto-falante </td><td> 1 (Rep. Jones) </td><td> 2 (Presidente. Anand) </td></tr>
<tr><td> encontro </td><td> chave para a reunião </td><td> 1 (reunião 1) </td><td> 2 (reunião 2) </td></tr>
<tr><td> Começar </td><td> ponto em que o alto-falante começa a falar </td><td> 521 </td><td> 12045 </td></tr>
<tr><td> Fim </td><td> ponto em que o alto-falante para de falar </td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2> Tabela "Tags de tópico" </h2>
<table><tr><th> Campo </th><th> Significado </th><th> Exemplo 1 </th><th> Exemplo 2 </th></tr>
<tr><td> Chave primária </td><td> Chave única </td><td> 1 1 </td><td> 2 </td></tr>
<tr><td> Tag </td><td> chave da etiqueta </td><td> 1 (energia) </td><td> 2 (educação) </td></tr>
<tr><td> encontro </td><td> chave para a reunião </td><td> 1 (reunião 1) </td><td> 2 (reunião 2) </td></tr>
<tr><td> Começar </td><td> ponto em que o tópico inicia </td><td> 750 </td><td> 14500 </td></tr>
<tr><td> Fim </td><td> ponto em que o tópico para </td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2> Tamanho dos dados </h2>
<p> O tamanho do banco de dados da reunião final é muito pequeno. Isso nos permitirá criar aplicativos em que muitos dados são armazenados localmente no computador ou smartphone de um usuário - para obter alto desempenho e a capacidade de executar o aplicativo off-line. </p>
