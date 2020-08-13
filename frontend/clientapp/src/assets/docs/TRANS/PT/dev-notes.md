<h1> Processar novos formatos de transcrição </h1>
<p> O objetivo final é escrever um código que processe qualquer formato de transcrição. Mas até então, precisamos escrever um código personalizado para lidar com cada novo formato. Quando tivermos amostras suficientes de diferentes formatos, poderemos escrever melhor o código genérico. </p>

<p> Estas são as etapas para lidar com novos formatos de transcrição: </p>

<ul>
<li>
<p> Obtenha uma transcrição de amostra de uma reunião do governo como um arquivo PDF ou de texto. </p>
</li>
<li>
<p> Nomeie o arquivo da seguinte maneira: "country_state_county_municipality_agency_language-code_date.pdf". (ou .txt) Por exemplo: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Crie uma nova classe com a interface "ISpecificFix" no projeto "ProcessTranscripts_Lib". </p>
</li>
<li>
<p> Nomeie a classe "country_state_county_municipality_agency_language-code". Por exemplo: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Implemente o método de classe: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix () recebe o texto da transcrição existente e retorna o texto no seguinte formato: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Quando essa classe for concluída, o WorkflowApp processará as novas transcrições quando elas aparecerem em "DATAFILES / RECEIVED". </p>

<p> Notas: </p>

<p> Usamos System.Reflection para instanciar a classe correta com base no nome do arquivo a ser processado. </p>

<p> Consulte a classe "USA_PA_Philadelphia_Philadelphia_CityCouncil_en" em ProcessTranscripts_Lib para obter um exemplo. Você pode entender melhor o que essa classe está fazendo observando os rastreamentos do arquivo de log na "pasta de trabalho" que é passada como argumento para Fix (). </p>

<p> Não extraímos as seguintes informações agora, mas queremos fazer isso eventualmente. </p>

<ul>
<li> Funcionários presentes </li>
<li> Contas e resoluções introduzidas </li>
<li> Resultados da votação </li>
</ul>
<p> Austin, TX - EUA também possui transcrições de reuniões públicas on-line. Uma classe foi criada chamada "USA_TX_TravisCounty_Austin_CityCouncil_en" em ProcessTranscripts_Lib. Mas o método Fix () não foi implementado. As transcrições podem ser obtidas no site: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, TX City Council</a> </p>
<h1> Modificar o painel do cliente </h1><h2> Adicione um cartão para novos recursos </h2>
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

<ul>
<li> BuildPublishAndDeploy.ps1 - chame os outros scripts para criar uma versão e implantá-la. </li>
<li> Build-ClientApp.ps1 - Crie versões de produção do ClientApp </li>
<li> Publish-WebApp.ps1 - Crie uma pasta "publicar" do WebApp </li>
<li> Copy-ClientAssets.ps1 - Copiar ativos ClientApp para a pasta wwwroot do WebApp </li>
<li> Deploy-PublishFolder.ps1 - Implante a pasta de publicação em um host remoto </li>
<li> Crie o arquivo README.md para o Gethub a partir dos arquivos de documentação </li>
</ul>
<p> O Deploy-PublishFolder.ps1 implanta o software no govmeeting.org, usando FTP. As informações de login do FTP estão no arquivo appsettings.Development.json na pasta SECRETS. Ele contém FTP e outros segredos para uso em desenvolvimento. Abaixo está a seção deste arquivo usada pelo FTP: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
