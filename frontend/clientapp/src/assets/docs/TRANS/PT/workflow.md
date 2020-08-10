<p> Abaixo está uma descrição funcional das principais partes do software. </p>
<h2> Registo individual </h2>
<ul>
<li> Durante o registro, os usuários especificam seu local de residência (cidade, cidade, vila, código postal, etc.). </li>
<li> Com base em sua localização, o sistema determina as entidades administrativas às quais eles pertencem. (país, estado, município, localidade etc) </li>
</ul><h2> Registro de Órgão Governamental </h2>
<ul>
<li> Um usuário pode registrar qualquer uma das entidades administrativas às quais eles pertencem. </li>
<li> As informações inseridas incluirão: 
<ul>
<li> URL do site </li>
<li> Nomes dos funcionários governamentais </li>
<li> URLs onde transcrições ou gravações de reuniões podem ser encontradas </li>
</ul></li>
<li> Outros usuários deste local verão os dados já inseridos. Eles podem votar na precisão de qualquer item de dados e inserir valores alternativos. </li>
<li> Os votos serão acumulados para cada valor de dados. Os valores com mais votos se tornam os valores oficiais. <a href="https://github.com/govmeeting/govmeeting/issues/62">Edição no Github
# 62</a> </li>
</ul><h2> Importar gravações ou transcrições </h2>
<ul>
<li> O sistema fará o download das gravações ou transcrições on-line existentes, regularmente, nos locais especificados no Registro do Órgão Governamental. </li>
<li> Os usuários também têm a opção de fazer upload de gravações ou transcrições. </li>
<li> Muitos lugares não fornecem transcrições nem gravações de suas reuniões. O Govmeeting fornecerá um aplicativo smartphome que os usuários podem usar para gravar e enviar pessoalmente uma gravação de reunião. <a href="https://github.com/govmeeting/govmeeting/issues/18">Edição no Github
# 18</a> </li>
</ul><h2> Pré-processar transcrições existentes </h2>
<ul>
<li> Converta transcrições para texto sem formatação. Muitas vezes, as transcrições existentes estão em outros formatos, como PDF. Eles são convertidos em texto sem formatação para facilitar o processamento. </li>
<li> Extraia informações como nomes de oradores e seções. </li>
</ul><h2> Transcrever gravações usando o reconhecimento de fala </h2>
<ul>
<li> Converta gravações nos principais formatos de vídeo da web (mp4, ogg e webm.) Isso os torna mais acessíveis em todos os tipos de dispositivos. </li>
<li> Extraia e mescle faixas de áudio, se houver mais de uma. </li>
<li> Faça o upload do arquivo de áudio no armazenamento do Google Cloud para se preparar para a transcrição. </li>
<li> Ligue para a API de fala do Google assíncrona para fazer o reconhecimento automático de voz. </li>
<li> Realize o reconhecimento de alteração do alto-falante. Existe uma API do Google para isso. </li>
<li> Adicione a identificação do alto-falante. Isso usará o software de processamento de fala no servidor. </li>
<li> Coloque as informações em um formato JSON para processamento adicional. </li>
<li> Divida os arquivos de vídeo, áudio e transcrição em segmentos de trabalho de 3 minutos, para que vários voluntários possam trabalhar simultaneamente na revisão. </li>
</ul><h2> Revisar texto transcrito [Etapa manual] </h2>
<ul>
<li> Revise o texto para erros. Forneça uma interface amigável para correção rápida de erros. </li>
<li> Informações corretas, como nomes de oradores e seções. </li>
</ul>
<p> O Govmeeting tenta tornar o processamento o mais automático possível. Mas os computadores ainda não são tão inteligentes quanto gostaríamos. Os humanos ainda são necessários para corrigir seus erros. Mas todos os dias, os computadores ficam mais inteligentes e esse trabalho deve ficar cada vez menos. </p>
<h2> Adicionar tags de problema [Etapa manual] </h2>
<ul>
<li> Um dos trabalhos mais importantes é adicionar corretamente tags ou metadados à transcrição. Isto é o que permite: 
<ul>
<li> informações a serem facilmente localizadas. </li>
<li> uma transcrição para ser indexada e navegada rapidamente </li>
<li> alertas a serem definidos pelo usuário em questões específicas </li>
</ul></li>
<li> Os nomes dos problemas precisam ser atribuídos por pessoas e não por computadores. Esta é a melhor maneira de garantir que eles sejam significativos. </li>
<li> É importante que seja fornecida uma interface de usuário muito fácil de usar e rápida. </li>
</ul>
<p> No futuro, talvez essa etapa também possa ser realizada principalmente por um computador. Mas não é uma coisa ruim precisar de algum trabalho manual de voluntários da comunidade. Ajuda a unir as pessoas por uma causa comum. Se esta é uma cidade pequena, com 35.000 habitantes, não deve ser tão difícil alistar uma dúzia ou mais para dar um curto período de tempo a cada mês. </p>
<h2> Preencher banco de dados relacional </h2>
<p> Os dados são colocados em um banco de dados relacional para que possam ser acessados rapidamente usando vários critérios. </p>
<h2> Os dados estão agora disponíveis para uso </h2>
<ul>
<li> Uma transcrição disponível e disponível para pesquisa está agora disponível </li>
<li> Um resumo dos assuntos discutidos na reunião é enviado aos solicitantes. </li>
<li> Os alertas são enviados sobre questões específicas para os solicitantes. </li>
</ul><h2> Reunião virtual é agendada. </h2>
<ul>
<li> Uma agenda é criada com base nos problemas da reunião real. </li>
<li> As convites são enviadas aos membros da comunidade. </li>
<li> Estão incluídas no convite solicitações para possíveis itens adicionais da agenda. </li>
<li> Quando as respostas são recebidas, uma votação é enviada para aqueles que comparecerão. Nesta votação, os membros podem votar em quais novos itens da agenda sugeridos para incluir. </li>
<li> Dentro de alguns dias, uma reunião virtual é realizada. </li>
</ul><h2> Gestão de fluxo de trabalho </h2>
<p> Algumas das etapas do fluxo de trabalho acima são realizadas automaticamente por computador e outras são feitas manualmente por voluntários. Há lugares no fluxo de trabalho em que uma pessoa real deve verificar se não há problema em prosseguir: </p>

<ul>
<li> Verifique se os URLs para recuperar transcrições e gravações parecem válidos. </li>
<li> Verifique se o conteúdo dos arquivos recuperados parece válido. </li>
<li> Verifique se a saída do pré-processamento parece válida. </li>
<li> Verifique se a conversão de fala em texto parece válida. </li>
<li> Verifique se a revisão da transcrição parece concluída. </li>
<li> Verifique se a adição de tags à transcrição parece concluída. </li>
<li> Verifique se os dados finais da transcrição parecem completos e válidos. </li>
</ul>
<p> É preciso haver uma maneira de elevar os direitos de um ou mais usuários registrados de um local para uma posição de "gerente". </p>

<ul>
<li> Os gerentes seriam notificados sempre que uma decisão estivesse pendente no fluxo de trabalho. </li>
<li> Um gerente pode fazer login e dar ou negar a aprovação do fluxo de trabalho. </li>
</ul>
