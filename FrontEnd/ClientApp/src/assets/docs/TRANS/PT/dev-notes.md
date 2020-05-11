<h1> Lidar com novas transcrições </h1>
<p> Algumas cidades produzem transcrições de reuniões. Isso nos permite pular a transcrição da reunião. Mas apresenta um problema diferente. As transcrições não estarão em um formato padrão. </p>

<p> Nosso software precisará: </p>

<ul>
<li> Extraia as informações. </li>
<li> Adicione tags que permitam que as informações sejam usadas com facilidade. </li>
</ul>
<p> As informações normalmente em uma transcrição, que queremos extrair são: </p>

<ul>
<li> Informações da reunião: hora, local, se é uma reunião especial. </li>
<li> Funcionários presentes </li>
<li> Títulos de seção </li>
<li> Nome de cada orador e o que eles disseram. </li>
</ul>
<p> Se nenhum cabeçalho de seção estiver presente, o software deve ser inteligente o suficiente para determinar onde seções comuns são iniciadas: </p>

<ul>
<li> Chamada de função </li>
<li> Invocação </li>
<li> Relatórios do Comitê </li>
<li> Introdução de contas </li>
<li> Resoluções </li>
<li> Comentário público </li>
</ul>
<p> Precisamos ver quão bem também podemos extrair os resultados das votações em projetos de lei e resoluções. Às vezes, os resultados são indicados por frases como "Os sim têm". Outras vezes, é realizada uma votação formal onde o nome de cada funcionário é lido em voz alta e a pessoa responde com "sim" ou "não". </p>

<p> Informações supérfluas precisam ser removidas. Por exemplo: repetir cabeçalhos ou rodapés, números de linhas e números de páginas. </p>

<p> Espera-se que um código geral possa ser escrito para extrair informações de uma nova transcrição que nunca foi usada. No entanto, até então, será necessário escrever um novo código para lidar com casos específicos. </p>

<p> Como normalmente são apenas as cidades maiores que produzem transcrições: </p>

<ul>
<li> Na maioria das vezes, lidaremos com gravações de reuniões. </li>
<li> Em uma cidade maior, há mais programadores de computador disponíveis, capazes de escrever esse código. </li>
</ul>
<p> Poderíamos criar um mecanismo de plug-in que permitiria adicionar módulos que executam a extração. Poderíamos permitir que os plugins fossem escritos em muitas linguagens diferentes: Python, Java, PHP, Ruby - além das linguagens em que o sistema está atualmente escrito: Typescript e C #. </p>

<p> Atualmente, o software lida apenas com um caso, Filadélfia, PA, EUA. A biblioteca do projeto "Backend \ ProcessMeetings \ ProcessTranscripts_lib" contém código para processar transcrições. </p>

<p> A classe "Specific_Philadelphia_PA_USA" chama algumas rotinas de uso geral para processar transcrições para a Filadélfia. </p>

<p> Existe uma classe de stub "Specific_Austin_TX_USA" destinada ao processo de uma transcrição de Austin, TX. Talvez alguém queira dar uma facada no preenchimento deste código. Há uma transcrição de teste na pasta Testdata. Mas provavelmente é melhor obter as informações mais recentes em seu site: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Modificando o painel do cliente </h1><h2> Adicione um cartão para novos recursos </h2>
<ul>
<li> Em um prompt do terminal, vá para a pasta: FrontEnd / ClientApp </li>
<li> Digite: ng gerar componente seu recurso </li>
<li> Adicione sua funcionalidade aos arquivos em: FrontEnd / ClientApp / src / app / your-feature </li>
<li> Insira um novo elemento gm-small-card ou gm-large-card em app / dash-main / dash-main.html. </li>
<li> Modifique o ícone, a cor do ícone, o título etc. do elemento do cartão. </li>
<li> Se você precisar acessar o nome do local e agência atualmente selecionados no seu controlador: 
<ul>
<li> Adicione os atributos de entrada do local e da agência ao seu elemento de recurso </li>
<li> Adicione propriedades @Input de localização e agência no seu controlador. </li>
</ul></li>
</ul>
<p> (Veja os outros exemplos em dash-main.html) </p>
<h2> Reorganizar cartões </h2><ol>
<li> Abra o arquivo: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Altere as posições do cartão alterando a posição dos elementos gm-small-card ou gm-large-card neste arquivo. </li></ol><h1> Exploração madeireira </h1>
<p> Os arquivos de log do WebApp e WorkflowApp estão na pasta "logs" na raiz da solução. </p>

<ul>
<li> "nlog-all- (date) .log" contém todas as mensagens de log, incluindo o sistema. </li>
<li> O arquivo "nlog-own- (date) .log" contém apenas as mensagens do aplicativo. </li>
</ul>
<p> Na parte superior de muitos dos arquivos de componente no ClientApp, uma const "NoLog" é definida. Altere seu valor de true para false para ativar o log do console apenas para esse componente. </p>
<h1> Criar scripts </h1>
<p> Os scripts de construção do PowerShell podem ser encontrados em Utilitários / PsScripts </p>
<h2> BuildPublishAndDeploy.ps1 </h2>
<p> Esse script chama muitos dos outros scripts para criar um release de produção e implementá-lo. </p>

<ul>
<li> Build-ClientApp.ps1 - Crie versões de produção do ClientApp </li>
<li> Publish-WebApp.ps1 - Crie uma pasta "publicar" do WebApp </li>
<li> Copy-ClientAssets.ps1 - Copiar ativos ClientApp para a pasta wwwroot do WebApp </li>
<li> Deploy-PublishFolder.ps1 - Implante a pasta de publicação em um host remoto </li>
<li> Crie o arquivo README.md para o Gethub a partir dos arquivos de documentação </li>
</ul>
<p> O Deploy-PublishFolder.ps1 implanta o software no govmeeting.org, usando FTP. As informações de login do FTP estão no arquivo appsettings.Development.json na pasta SECRETS. Ele contém FTP e outros segredos para uso em desenvolvimento. Abaixo está o formato deste arquivo: </p>
<pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-id", "ClientSecret": "your-client-secret" } }, "ReCaptcha": { "SiteKey": "your-site-key", "Secret": "your-secret" }, "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } }</code> </pre>