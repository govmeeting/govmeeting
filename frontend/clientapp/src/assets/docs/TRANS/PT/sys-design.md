<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle"> Projeto </mat-card-title>
<markdown ngPreserveWhitespaces>

<p> Os diagramas abaixo mostram a interação entre os componentes de software. </p>

<ul>
<li>
<p> ClientApp é um aplicativo de página única Angular Typescript que é executado no navegador. Ele fornece a interface do usuário. </p>
</li>
<li>
<p> O WebApp é um <a href="https://github.com/aspnet/home">aplicativo Asp.Net Core</a> C# que é executado no servidor. Ele responde às chamadas da WebApi. </p>
</li>
<li>
<p> WorkflowApp é um aplicativo <a href="https://github.com/dotnet/core">DotNet Core</a> C# que é executado no servidor. Faz o processamento em lote de gravações e transcrições. Também pode ser convertido em uma biblioteca que é executada como parte do processo WebApp. </p>
</li>
<li>
<p> Os outros componentes do servidor são bibliotecas DotNet Core C #. Eles são usados pelo WebApp e pelo WorkflowApp. </p>
</li>
</ul><hr /><h2> Projeto de sistema </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

<p> Os componentes no diagrama acima são: </p>

<table style="width:100%">
<tr><th colspan="2"> Formulários </th></tr>
<tr><td> ClientApp </td><td> SPA angular </td></tr>
<tr><td> Aplicativo web </td><td> Processo do servidor web Asp.Net </td></tr>
<tr><td> WorkflowApp </td><td> Processo de controle do servidor de fluxo de trabalho </td></tr>
<tr><th colspan="2"> Bibliotecas </th></tr>
<tr><td> GetOnlineFiles </td><td> Recuperar transcrições e gravações on-line </td></tr>
<tr><td> ProcessRecording </td><td> Extraia e transcreva áudio. Crie segmentos de trabalho. </td></tr>
<tr><td> ProcessTranscript </td><td> Transformar transcrições brutas </td></tr>
<tr><td> LoadDatabase </td><td> Preencher banco de dados com dados da transcrição concluída </td></tr>
<tr><td> OnlineAccess </td><td> Rotinas para recuperar arquivos de sites remotos </td></tr>
<tr><td> GoogleCloudAccess </td><td> Rotinas para acessar os serviços do Google Cloud </td></tr>
<tr><td> FileDataRepositories </td><td> Armazenar e obter dados do arquivo de trabalho JSON </td></tr>
<tr><td> DatabaseRepositories </td><td> Armazenar e obter dados do modelo do banco de dados </td></tr>
<tr><td> DatabaseAccess </td><td> Acessar banco de dados usando o Entity Framework </td></tr>
</table>
<hr /><h2> Design do ClientApp </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

<p> A estrutura do ClientApp é melhor mostrada por sua estrutura de componente angular </p>

<table style="width:100%">
<tr><th colspan="2"> Componentes do aplicativo </th></tr>
<tr><td> Cabeçalho </td><td> Cabeçalho </td></tr>
<tr><td> Sidenav </td><td> Navegação na barra lateral </td></tr>
<tr><td> painel de controle </td><td> Contêiner para componentes do painel </td></tr>
<tr><td> Documentação </td><td> Contêiner para páginas de documentação </td></tr>
<tr><th colspan="2"> Componentes do painel </th></tr>
<tr><td> Fixasr </td><td> Corrigir texto de reconhecimento automático de fala </td></tr>
<tr><td> Addtags </td><td> Adicionar tags às transcrições </td></tr>
<tr><td> ViewMeeting </td><td> Ver transcrições concluídas </td></tr>
<tr><td> Problemas </td><td> Ver informações sobre problemas </td></tr>
<tr><td> Alertas </td><td> Ver e definir informações sobre alertas </td></tr>
<tr><td> Funcionários </td><td> Ver informações sobre funcionários </td></tr>
<tr><td> (Outras)) </td><td> Outros componentes a serem implementados </td></tr>
<tr><th colspan="2"> Serviços </th></tr>
<tr><td> VirtualMeeting </td><td> Executar reunião virtual </td></tr>
<tr><td> Bate-papo </td><td> Componente de bate-papo do usuário </td></tr>
</table>
<hr /><h2> WebApp Design </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

<p> Cada uma das APIs da Web é pequena e chama os repositórios para colocar ou obter dados do banco de dados ou sistema de arquivos. </p>

<table style="width:100%">
<tr><th colspan="2"> Controladores </th></tr>
<tr><td> Fixasr </td><td> Salve e obtenha a versão mais recente da transcrição sendo revisada. </td></tr>
<tr><td> Addtags </td><td> Salve e obtenha a versão mais recente da transcrição sendo etiquetada. </td></tr>
<tr><td> Viewmeeting </td><td> Obtenha o trnascript completo mais recente. </td></tr>
<tr><td> Govbodies </td><td> Salve e obtenha dados do órgão governamental registrado. </td></tr>
<tr><td> Encontros </td><td> Salve e obtenha informações da reunião. </td></tr>
<tr><td> Vídeo </td><td> Obter vídeo da reunião. </td></tr>
<tr><td> Conta </td><td> Processe o registro e o login do usuário. </td></tr>
<tr><td> Gerir </td><td> Os usuários podem gerenciar seus perfis. </td></tr>
<tr><td> Admin </td><td> O administrador pode gerenciar usuários, políticas e reivindicações </td></tr>
<tr><th colspan="2"> Serviços </th></tr>
<tr><td> O email </td><td> Lidar com a confirmação do email de registro. </td></tr>
<tr><td> mensagem </td><td> Lidar com a confirmação do registro via mensagem de texto. </td></tr>
</table>
<hr /><h2> Design de fluxo de trabalho </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

<p> O status do fluxo de trabalho para uma reunião específica é mantido em seu registro de Reunião no banco de dados. Cada um dos componentes do fluxo de trabalho opera de forma independente. Cada um deles é chamado, por sua vez, para verificar o trabalho disponível. Cada componente consultará o banco de dados em busca de reuniões que correspondam aos seus critérios para o trabalho disponível. Se o trabalho for encontrado, eles o executarão e atualizarão o status da reunião no banco de dados. </p>

<p> Para criar um sistema robusto, que possa se recuperar de falhas, precisaremos tratar as etapas do fluxo de trabalho como "transações". Uma transação é concluída totalmente ou não é de todo. Se houver falhas irrecuperáveis durante uma etapa de processamento, o estado dessa reunião reverterá para o último estado válido. O código não implementa transações no momento. (Problema no Gitub a seguir) </p>

<p> Pseudo código é dado abaixo para os componentes </p>

<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Para todas as entidades governamentais no sistema </li>
<ul>
<li> Verifique os horários das reuniões para recuperar </li>
<li> Recuperar arquivo de gravação ou transcrição </li>
<li> Coloque o arquivo na pasta DATAFILES \ Received </li>
</ul>
<li> Os arquivos também podem ser colocados na pasta Recebido por upload do usuário. </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li> Para arquivos em DATAFILES \ Received e o registro do banco de dados não existe: </li>
<ul>
<li> Determinar o tipo de arquivo </li>
<li> Criar registro de banco de dados </li>
<li> definir status = recebido, aprovado = falso </li>
<li> Enviar mensagem (s) do gerente: "Recebido" </li>
</ul>
</ul>
<li> TranscribeRecordings </li>
<ul>
<li> Para gravações com sourcetype = gravação, status = recebido, aprovado = verdadeiro </li>
<ul>
<li> Criar pasta de trabalho </li>
<li> definir status = transcrição, aprovado = falso </li>
<li> Transcrever gravação </li>
<li> definir status = transcrito, aprovado = falso </li>
<li> Enviar mensagem do gerente: "Transcrito" </li>
</ul>
</ul>
<li> ProcessTranscripts </li>
<ul>
<li> Para transcrições com sourcetype = transcrição, status = recebido, aprovado = verdadeiro </li>
<ul>
<li> Criar pasta de trabalho </li>
<li> definir status = processamento, aprovado = falso </li>
<li> Transcrição do processo </li>
<li> definir status = processado, aprovado = falso </li>
<li> Enviar mensagem do gerente: "Processado" </li>
</ul>
</ul>
<li> Revisão de Gravação </li>
<ul>
<li> Para gravações com status = transcrito / aprovado = verdadeiro </li>
<ul>
<li> Criar pasta de trabalho </li>
<li> definir status = revisão, aprovado = falso </li>
<li> A revisão manual agora ocorrerá </li>
</ul>
<li> Para gravações com status = revisão </li>
<ul>
<li> Verifique se a revisão parece concluída. Se então: </li>
<li> definir status = revisar, aprovado = falso </li>
<li> enviar mensagem (s) do gerente: "Revisão" </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li> Para gravações com status = revisado, aprovado = verdadeiro OU para transcrições com status = processado, aprovado = verdadeiro </li>
<ul>
<li> Criar pasta de trabalho </li>
<li> definir status = marcação, aprovado = falso </li>
<li> A marcação manual agora ocorrerá </li>
</ul>
</ul>
<ul>
<li> Para transcrições com status = tagging </li>
<ul>
<li> Verifique se a marcação parece concluída. Se então: </li>
<li> definir status = marcado, aprovado = falso </li>
<li> enviar mensagem (s) do gerente: "Marcado" </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Para reuniões com status = marcado, aprovado = verdadeiro 
<ul>
<li> definir status = carregamento, aprovado = falso </li>
<li> carregar o conteúdo da reunião no banco de dados </li>
<li> definir status = carregado, aprovado = falso </li>
<li> Enviar mensagem (s) do gerente: "Carregado" </li>
</ul>
</ul>
</ul><hr /><h2> Segredos do usuário </h2>
<p> Quando você clona o repositório govmeeting do Github, você obtém tudo, exceto a pasta "SECRETS". Esta pasta reside fora do repositório. Ele contém as seguintes informações "secretas": </p>

<ul>
<li> ClientId e ClientSecret para o serviço de autorização externa do Google. </li>
<li> SiteKey e Secret para o serviço Google ReCaptcha. </li>
<li> Credenciais para o Google Cloud Platform. </li>
<li> Cadeia de conexão de banco de dados. </li>
<li> Nome de usuário e senha do administrador. </li>
</ul>
<p> A pasta SECRETS pode conter quatro arquivos. </p>

<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> appsettings.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul>
<p> TranscribeAudio.json contém as credenciais do Google Cloud Platform. Cada um dos outros três arquivos pode conter configurações para cada um dos outros segredos. appsettings.Production.json deve conter todas as configurações de produção. Quaisquer configurações que estejam nesses arquivos substituirão as que estão em Server / WebApp / app.settings.json. Este arquivo está incluído no repositório. </p>

<p> Se você deseja que sua máquina local tenha acesso aos serviços do Google, crie uma pasta local "../SECRETS em relação à localização do repositório. Em seguida, por exemplo, você pode adicionar um arquivo" appsettings.Development. json ", que contém as chaves que você obtém do Google. Consulte: <a href="home#google-api-keys">Chaves da API do Google</a> </p>
<hr /><h1> Documentação </h1>
<p> Originalmente, essa documentação era mantida nas páginas do Github Wiki. Mas foi decidido mover as páginas para o próprio projeto principal, por dois motivos: </p>

<ul>
<li> Você não pode fazer uma solicitação pull para alterações nas páginas do Github Wiki. Isso torna difícil para os membros da comunidade alterar a documentação. </li>
<li> A documentação provavelmente ficará sincronizada com o código se estiver junto com o código no mesmo repositório. Um único PR para alterações de código pode incluir as alterações na documentação associadas a ele. </li>
</ul>
<p> A documentação está escrita em Markdown e localizada em Frontend / ClientApp / src / app / assets / docs. </p>

</markdown>

<p> &lt;/mat-card&gt; </p>
