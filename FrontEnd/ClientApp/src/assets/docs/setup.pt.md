
<p><a name="Contents"></a></p>
<h1> Conteúdo </h1>
<ul>
<li> <a href="about?id=setup#InstallTools">Instalar ferramentas e clonar repositório</a> </li>
<li> <a href="about?id=setup#DevelopVsCode">Desenvolver com VsCode</a> </li>
<li> <a href="about?id=setup#DevelopVS">Desenvolver com o Visual Studio</a> </li>
<li> <a href="about?id=setup#DevelopOther">Desenvolva em outras plataformas</a> </li>
<li> <a href="about?id=setup#Database">Base de dados</a> </li>
<li> <a href="about?id=setup#GoogleCloud">Conta do Google Cloud Platform</a> </li>
<li> <a href="about?id=setup#GoogleApi">Chaves da API do Google</a> </li>
</ul>
<p> Essas páginas de documentação podem ser encontradas em FrontEnd / ClientApp / src / app / assets / docs. Faça as correções lá e emita uma <a href="https://github.com/govmeeting/govmeeting">solicitação de recebimento no Gitub.</a> </p>
<hr />
<p><a name="InstallTools"></a></p>
<h1> Instalar ferramentas e clonar repositório <br/></h1>
<p> <a href="about?id=setup#Contents">[Conteúdo]</a> </p>

<ul>
<li> Instale o git. <a href="https://gitforwindows.org">Git para Windows</a> , <a href="https://git-scm.com/download/mac">Git para Mac</a> </li>
<li> Instale o <a href="https://nodejs.org/en/download/">Node.js.</a> </li>
<li> Instale o <a href="https://dotnet.microsoft.com/download">.Net Core SDK.</a> </li>
<li> "Fork" o projeto no github </li>
<li> Clonar o projeto localmente </li>
<li> Crie uma pasta para o repositório clonado chamado "_SECRETS" </li>
</ul>
<p> A pasta "_SECRETS" é para chaves e senhas que não são armazenadas no repositório público. Isso seria necessário para executar os serviços da API do Google. </p>
<hr />
<p><a name="DevelopVsCode"></a></p>
<h1> Desenvolver com VsCode <br/></h1>
<p> <a href="about?id=setup#Contents">[Conteúdo]</a> </p>
<h2> Instale o VsCode </h2>
<ul>
<li> Instale o <a href="https://code.visualstudio.com/download">Visual Studio Code</a> e inicie-o. </li>
<li> Abra as extensões no painel lateral esquerdo e instale: 
<ul>
<li> "Depurador para Chrome" da Microsoft </li>
<li> "C
# para código do Visual Studio" pela Microsoft </li>
<li> "SQL Server (mssql)" pela Microsoft </li>
<li> "Todo Tree" de Gruntfuggly - mostra as linhas do TODO no código (opcional) </li>
<li> "Powershell" da Microsoft - para depuração de scripts de construção do Powershell (opcional) </li>
</ul></li>
</ul><h2> Depurar / Executar ClientApp e WebApp </h2>
<ul>
<li> Abra a pasta Govmeeting no VsCode </li>
<li> Abra um painel de terminal no VsCode </li>
<li> cd FrontEnd / ClientApp </li>
<li> instalação npm </li>
<li> início npm </li>
<li> No painel de depuração, defina a configuração de inicialização "WebApp & ClientApp-W" </li>
<li> Pressione F5 (depuração) ou Ctrl-F5 (executada sem depuração) </li>
</ul>
<p> O ClientApp será aberto em um navegador. </p>

<ul>
<li> Clique em qualquer um dos itens de menu "Sobre" para ver a documentação. </li>
<li> Clique no item do menu local "Boothbay Harbor". Você verá o painel aberto para este local. </li>
</ul>
<p> Para verificar se o ClientApp está chamando a API WebApp para recuperar dados. </p>

<ul>
<li> Clique em "Revisar Transcrição". Você verá um painel de vídeo e um texto transcrito. Clique no botão de reprodução de vídeo. </li>
<li> Clique em "Adicionar tags à transcrição". Você verá uma transcrição de uma reunião a ser marcada. </li>
<li> Clique em "Exibir última reunião". Você verá uma transcrição completa para visualização. </li>
</ul>
<p> A maioria dos outros cartões do painel não chama o WebApp, mas retorna dados de teste. </p>

<p> O ClientApp é servido pelo servidor webpack-dev-iniciado com "npm start". O WebApp usa o servidor Kestrel incluído no Asp.Net Core. O servidor Kestrel responde às chamadas da API da Web. Mas proxies solicitações internas do ClientApp para o servidor webpack-dev. </p>
<h2> Depurar / Executar ClientApp autônomo </h2>
<ul>
<li> No app.module.ts, altere "isAspServerRunning" de true para false. </li>
<li> início npm </li>
<li> No painel de depuração, defina a configuração de inicialização "ClientApp" </li>
<li> Pressione F5 (depuração) ou Ctrl-F5 (executada sem depuração) </li>
</ul>
<p> Quando "isAspServerRunning" é definido como false, serviços de stub são usados, em vez de chamar a API WebApp. Isso é útil para quando estamos apenas modificando o código no ClientApp. </p>
<h2> Depurar / Executar WorkflowApp </h2>
<ul>
<li> No painel de depuração, defina a configuração de inicialização "WorkflowApp" </li>
<li> Pressione F5 (depuração) ou Ctrl-F5 (executada sem depuração) </li>
</ul>
<p> Quando o WorkflowApp o inicia: </p>

<ul>
<li> Copia alguns arquivos de teste na pasta Datafles / RECEIVED: um arquivo PDF de transcrição e um arquivo MP4 de gravação. </li>
<li> Processa o arquivo PDF de transcrição e cria um arquivo JSON pronto para ser marcado. </li>
<li> Processe o arquivo MP4 de gravação, transcrevendo-o na nuvem e crie um arquivo JSON pronto para ser revisado. </li>
</ul>
<p> Os resultados podem ser encontrados em Arquivos de dados / PROCESSAMENTO. No entanto, você precisará primeiro configurar uma <a href="about?id=setup#GoogleCloud">conta do Google Cloud</a> para que a gravação seja transcrita. </p>
<hr />
<p><a name="DevelopVS"></a></p>
<h1> Desenvolver com o Visual Studio <br/></h1>
<p> <a href="about?id=setup#Contents">[Conteúdo]</a> </p>

<ul>
<li> Instale o <a href="https://visualstudio.microsoft.com/free-developer-offers/">Visual Studio Community Edition</a> gratuito <a href="https://visualstudio.microsoft.com/free-developer-offers/">.</a> </li>
<li> Durante a instalação, selecione as cargas de trabalho "ASP.NET" e "Área de trabalho .NET". </li>
<li> Instalar extensões: (todas de Mads Kristensen) 
<ul>
<li> "Executor de tarefas do NPM" </li>
<li> "Executador de tarefas de comando" </li>
<li> "Editor de descontos" </li>
</ul></li>
<li> Abra o arquivo de solução "govmeeting.sln" </li>
</ul><h2> Depurar / Executar ClientApp e WebApp </h2>
<ul>
<li> No Task Runner Explorer (ClientApp): 
<ul>
<li> execute "instalar" </li>
<li> execute "start" </li>
</ul></li>
<li> Defina o projeto de inicialização como "WebApp" </li>
<li> Pressione F5 (depuração) ou Ctrl-F5 (executada sem depuração) </li>
<li> O WebApp será executado e um navegador será aberto, exibindo o ClientApp. </li>
</ul>
<p> NOTA: Há um problema com a definição de pontos de interrupção no Angular ClientApp no Visual Studio. Veja: <a href="https://github.com/govmeeting/govmeeting/issues/80">Edição
# 80 do Github</a> </p>
<h2> Depurar WorkflowApp </h2>
<ul>
<li> Abra o painel de depuração. </li>
<li> Defina o projeto de inicialização como "WorkflowApp" </li>
<li> Pressione F5 (depuração) ou Ctrl-F5 (executada sem depuração) </li>
</ul>
<p> Nota: Veja as notas do WorkflowApp em "Código do Visual Studio" </p>
<hr />
<p><a name="DevelopOther"></a></p>
<h1> Desenvolva em outras plataformas <br/></h1>
<p> <a href="about?id=setup#Contents">[Conteúdo]</a> </p>

<p> No seu perfil, defina a variável de ambiente ASPNETCORE_ENVIRONMENT como "Desenvolvimento". Isso é usado pelo WebApp e WorkflowApp. </p>
<h2> Construa e execute o ClientApp </h2>
<p> Executar: </p>

<ul>
<li> cd Frontend / ClientApp </li>
<li> instalação npm </li>
<li> início npm </li>
</ul>
<p> Vá para localhost: 4200 no seu navegador. O aplicativo cliente será carregado. Alguns recursos não funcionarão até que o WebApp esteja em execução. </p>
<h2> Construa e execute o WebApp com ClientApp </h2>
<p> Executar: </p>

<ul>
<li> (faça acima: "Crie e inicie o ClientApp") </li>
<li> cd ../../Backend/WebApp </li>
<li> dotnet build webapp.csproj </li>
<li> bin de execução do dotnet / debug / dotnet2.2 / webapp.dll </li>
</ul>
<p> Vá para localhost: 5000 no seu navegador. O aplicativo cliente será carregado. </p>
<h2> Construa e execute o ClientApp autônomo </h2>
<ul>
<li> No app.module.ts, altere "isAspServerRunning" de true para false. </li>
<li> (faça acima: "Crie e inicie o ClientApp") </li>
</ul><h2> Crie e execute o WorkflowApp </h2>
<p> Executar: </p>

<ul>
<li> CD Backend / WorkflowApp </li>
<li> dotnet build workflowapp.csproj </li>
<li> bin de execução do dotnet / debug / dotnet2.0 / workflowapp.dll </li>
</ul>
<p> Nota: Veja as notas do WorkflowApp em "Código do Visual Studio" </p>
<!-- END OF README SECTION --><hr />
<p><a name="Database"></a></p>
<h1> Base de dados <br/></h1>
<p> <a href="about?id=setup#Contents">[Conteúdo]</a> </p>

<p> Pode não ser necessário instalar e configurar o banco de dados para fazer o desenvolvimento. Existem stubs de teste que substituem o banco de dados de chamada. Consulte "Stubs de teste" abaixo. </p>
<h2> Instalar fornecedor </h2>
<p> Se você estiver usando o Visual Studio ou o Visual Studio Code, o provedor Sql Server Express LocalDb já estará instalado. Caso contrário, faça "Instalação do provedor LocalDb" abaixo. </p>
<h3> Instalação do provedor LocalDb </h3>
<p> Vá para o <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">Sql Server Express.</a> Para Windows, baixe a edição especializada "Express" do SQL Server. Durante a instalação, escolha "Personalizado" e selecione "LocalDb". </p>

<p> O LocalDb também está disponível para MacOs e Linux. Se você o instalar em qualquer plataforma, atualize este documento com as etapas e faça uma solicitação de recebimento. </p>
<h3> Outros fornecedores </h3>
<p> Além do LocalSb, o EF Core suporta <a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli">outros provedores,</a> que você pode usar para desenvolvimento, incluindo o SqlLite. Você precisará modificar a configuração do DbContext em startup.cs e a cadeia de conexão em appsettings.json. </p>
<h2> Criar esquema de banco de dados </h2>
<p> O banco de dados é criado através do recurso "code first" do Entity Framework Core. Ele examina as classes C# no modelo de dados e cria automaticamente todas as tabelas e relações. Há duas etapas: (1) crie o código "migrações" para fazer a atualização e (2) execute a atualização. </p>

<ul>
<li> CD Backend / WebApp </li>
<li> as migrações do dotnet ef adicionam --project inicial .. \ Database \ DatabaseAccess_Lib </li>
<li> atualização do banco de dados do dotnet ef - projeto .. \ Database \ DatabaseAccess_Lib </li>
</ul><h2> Explore o banco de dados criado </h2><h3> Em VsCode </h3>
<p> Adicione o seguinte ao seu user settings.json no VsCode: </p>
<pre> <code> "mssql.connections": [ { "server": "(localdb)\\mssqllocaldb", "database": "Govmeeting", "authenticationType": "Integrated", "profileName": "GMProfile", "password": "" } ],</code> </pre>
<ul>
<li> Pressione ctrl-alt-D ou pressione o ícone Sql Server na margem esquerda. </li>
<li> Abra a conexão GMProfile para visualizar e trabalhar com objetos de banco de dados. </li>
<li> Abra "Tabelas". Você deve ver todas as tabelas criadas quando criou o esquema acima. Isso inclui as tabelas AspNetxxxx para autorização e as tabelas para o modelo de dados Govmeeting. </li>
</ul><h3> No Visual Studio </h3>
<ul>
<li> Vá para o item de menu: Exibir -&gt; SQL Server Object Explorer. </li>
<li> Expanda SQL Server -&gt; (localdb) \ MSSQLLocalDb -&gt; Bancos de dados -&gt; Govmeeting </li>
<li> Abra "Tabelas". Você deve ver todas as tabelas criadas quando criou o esquema acima. Isso inclui as tabelas AspNetxxxx para autorização e as tabelas para o modelo de dados Govmeeting. </li>
</ul><h3> Outras plataformas </h3>
<p> Existe o <a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha">SQL Operations Studio,</a> multiplataforma e de código aberto <a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha">,</a> "uma ferramenta de gerenciamento de dados que permite trabalhar com o SQL Server, o Azure SQL DB e o SQL DW do Windows, macOS e Linux". Você pode baixar o <a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha">SQL Operations Studio gratuitamente aqui.</a> </p>

<p> Se você usar essa ou outra ferramenta para explorar os bancos de dados do SQL Server, atualize estas instruções. </p>
<h2> Stubs de teste </h2>
<p> O código para armazenar / recuperar dados de transcrição no banco de dados ainda não foi gravado. Portanto, o DatabaseRepositories_Lib usa dados de teste estáticos. No WebApp / appsettings.json, a propriedade "UseDatabaseStubs" é configurada como "true", solicitando que ele chame as rotinas de stub. </p>

<p> No entanto, o registro do usuário e o código de login no WebApp usam o banco de dados. Ele acessa as tabelas de autenticação de usuário do Asp.Net. O WebApp autentica chamadas de API do ClientApp com base no usuário conectado atual. </p>

<p> Você pode usar o valor do pré-processador "NOAUTH" no WebApp para ignorar a autenticação. Use um destes métodos: </p>

<ul>
<li> Em FixasrController.cs ou AddtagsController.cs, desmarque a linha "#if NOAUTH" na parte superior do arquivo. </li>
<li> Para desativá-lo para todos os controladores, adicione isso ao WebApp.csproj: </li>
</ul><pre> <code> &lt;PropertyGroup Condition="&#39;$(Configuration)|$(Platform)&#39;==&#39;Debug|AnyCPU&#39;&gt; &lt;DefineConstants&gt;NOAUTH&lt;/DefineConstants&gt; &lt;/PropertyGroup&gt;</code> </pre>
<ul>
<li> No Visual Studio, acesse as páginas de propriedades do WebApp -&gt; Compilar -&gt; e digite NOAUTH na caixa "Símbolos de compilação condicional". </li>
</ul><hr />
<p><a name="GoogleCloud"></a></p>
<h1> Conta do Google Cloud Platform <br/></h1>
<p> <a href="about?id=setup#Contents">[Conteúdo]</a> </p>

<p> Para usar as APIs do Google Speech para conversão de fala em texto, você precisa de uma conta do Google Cloud Platform (GCP). Para a maioria dos trabalhos de desenvolvimento no Govmeeting, você pode usar os dados de teste existentes. Mas se você deseja transcrever novas gravações, você fará um GCP. A API do Google pode transcrever gravações em mais de 120 idiomas e variantes. </p>

<p> O Google fornece aos desenvolvedores uma conta gratuita que inclui um crédito (atualmente US $ 300). O custo atual do uso da API do discurso é gratuito por até 60 minutos de conversão por mês. Depois disso, o custo do "modelo aprimorado" (que é o que precisamos) é de 0,009 dólares por 15 segundos. (US $ 2,16 por hora) </p>

<ul>
<li>
<p> Abra uma conta no <a href="https://cloud.google.com/free/">Google Cloud Platform</a> </p>
</li>
<li>
<p> Vá para o <a href="http://console.cloud.google.com">Google Cloud Dashboard</a> e crie um projeto. </p>
</li>
<li>
<p> Acesse o <a href="http://console.developers.google.com">Console do desenvolvedor do Google</a> e ative as APIs de armazenamento de fala e nuvem </p>
</li>
<li>
<p> Gere uma credencial de "conta de serviço" para este projeto. Clique em Credenciais no console do desenvolvedor. </p>
</li>
<li>
<p> Conceda a esta conta "Editor" permissões no projeto. Clique na conta. Na próxima página, clique em Permissões. </p>
</li>
<li>
<p> Faça o download do arquivo JSON da credencial. </p>
</li>
<li>
<p> Coloque o arquivo na pasta <code>_SECRETS</code> que você criou quando clonou o repositório. </p>
</li>
<li>
<p> Renomeie o arquivo <code>TranscribeAudio.json</code> . </p>
</li>
</ul>
<p> NOTA: As etapas acima podem ter sido ligeiramente alteradas. Em caso afirmativo, atualize este documento. </p>
<h2> Teste da transcrição de fala em texto </h2>
<ul>
<li>
<p> Defina o projeto de inicialização no Visual Studio como <code>Backend/WorkflowApp</code> . Pressione F5. </p>
</li>
<li>
<p> Copie (não mova) um dos arquivos MP4 de amostra de testdata para Datafiles / RECEIVED. </p>
</li>
</ul>
<p> O programa agora reconhecerá que um novo arquivo apareceu e começará a processá-lo. O arquivo MP4 será movido para "CONCLUÍDO" quando terminar. Você verá os resultados em suolders, que foram criados no diretório "Arquivos de dados". </p>

<p> No appsettings.json, há uma propriedade "RecordingSizeForDevelopment". Atualmente, está definido como "180". Isso faz com que a rotina de transcrição em ProcessRecording_Lib processe apenas os primeiros 180 segundos da gravação. </p>
<hr />
<p><a name="GoogleApi"></a></p>
<h1> Chaves da API do Google <br/></h1>
<p> <a href="about?id=setup#Contents">[Conteúdo]</a> </p>

<p> Você precisará dessas chaves se desejar usar ou trabalhar em determinados recursos do processo de registro e login. </p>

<ul>
<li> As chaves do ReCaptcha são necessárias para usar o ReCaptcha durante o registro do usuário. Eles podem ser obtidos no <a href="https://developers.google.com/recaptcha/">Google reCaptcha</a> . </li>
<li> As credenciais do OAuth 2.0 são usadas para fazer logon de usuário externo sem a necessidade de o usuário criar uma conta pessoal no site. Visite o <a href="https://console.developers.google.com/">Google API Console</a> para obter credenciais, como um ID e um segredo do cliente. </li>
</ul>
<p> Crie um arquivo chamado "appsettings.Development.json" na pasta "_SECRETS". Ele deve conter as chaves que você acabou de obter: </p>
<pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-Id", "ClientSecret": "your-client-secret" } }, "ReCaptcha:SiteKey": "your-site-key", "ReCaptcha:Secret": "your-secret" }</code> </pre><hr /><h2> Teste reCaptcha </h2>
<ul>
<li> Execute o projeto WebApp. </li>
<li> Clique em "Registrar" no canto superior direito. </li>
<li> A opção reCaptcha deve aparecer. </li>
</ul><hr /><h2> Teste a autenticação do Google </h2>
<ul>
<li> Execute o projeto WebApp. </li>
<li> Clique em "Login" no canto superior direito. </li>
<li> Em "Usar outro serviço para fazer login", escolha "Google". </li>
</ul>