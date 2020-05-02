
<p><a name="Contents"></a></p>
<h1>内容</h1>
<ul>
<li> <a href="about?id=setup#InstallTools">安装工具和克隆存储库</a> </li>
<li> <a href="about?id=setup#DevelopVsCode">用VsCode开发</a> </li>
<li> <a href="about?id=setup#DevelopVS">使用Visual Studio开发</a> </li>
<li> <a href="about?id=setup#DevelopOther">在其他平台上开发</a> </li>
<li> <a href="about?id=setup#Database">数据库</a> </li>
<li> <a href="about?id=setup#GoogleCloud">Google Cloud Platform帐户</a> </li>
<li> <a href="about?id=setup#GoogleApi">Google API密钥</a> </li>
</ul>
<p>这些文档页面可以在FrontEnd / ClientApp / src / app / assets / docs中找到。请在那里进行更正，然后<a href="https://github.com/govmeeting/govmeeting">在Gitub上</a>发出<a href="https://github.com/govmeeting/govmeeting">拉动请求。</a> </p>
<hr />
<p><a name="InstallTools"></a></p>
<h1>安装工具和克隆存储库<br/></h1>
<p> <a href="about?id=setup#Contents">[内容]</a> </p>

<ul>
<li>安装git。 <a href="https://gitforwindows.org">Windows版</a> <a href="https://git-scm.com/download/mac">Git，Mac版Git</a> </li>
<li>安装<a href="https://nodejs.org/en/download/">Node.js。</a> </li>
<li>安装<a href="https://dotnet.microsoft.com/download">.Net Core SDK。</a> </li>
<li> “分叉” github上的项目</li>
<li>在本地克隆项目</li>
<li>为克隆的存储库创建一个名为“ _SECRETS”的同级文件夹</li>
</ul>
<p> “ _SECRETS”文件夹用于未存储在公共存储库中的密钥和密码。这些将是运行Google API服务所必需的。 </p>
<hr />
<p><a name="DevelopVsCode"></a></p>
<h1>用VsCode开发<br/></h1>
<p> <a href="about?id=setup#Contents">[内容]</a> </p>
<h2>安装VsCode </h2>
<ul>
<li>安装<a href="https://code.visualstudio.com/download">Visual Studio Code</a>并启动它。 </li>
<li>打开扩展左侧面板并安装： 
<ul>
<li>微软的“ Chrome调试器” </li>
<li> Microsoft的“ Visual Studio Code的C＃” </li>
<li> Microsoft的“ SQL Server（mssql）” </li>
<li> Gruntfuggly的“ Todo Tree”-用代码显示TODO行（可选） </li>
<li> Microsoft的“ Powershell”-用于调试Powershell构建脚本（可选） </li>
</ul></li>
</ul><h2>调试/运行ClientApp和WebApp </h2>
<ul>
<li>在VsCode中打开Govmeeting文件夹</li>
<li>在VsCode中打开一个终端窗格</li>
<li> cd FrontEnd / ClientApp </li>
<li> npm安装</li>
<li> npm开始</li>
<li>在调试面板中，将启动配置设置为“ WebApp＆ClientApp-W” </li>
<li>按F5（调试）或Ctrl-F5（无需调试即可运行） </li>
</ul>
<p> ClientApp将在浏览器中打开。 </p>

<ul>
<li>单击任何“关于”菜单项以查看文档。 </li>
<li>单击位置菜单项“ Boothbay Harbor”。您将看到该位置打开的仪表板。 </li>
</ul>
<p>验证ClientApp正在调用WebApp API检索数据。 </p>

<ul>
<li>点击“校对成绩单”。您将看到一个视频窗格和转录的文本。点击视频播放按钮。 </li>
<li>点击“向成绩单添加标签”。您将看到要标记的会议记录。 </li>
<li>单击“查看最新会议”。您将看到一份完整的成绩单供查看。 </li>
</ul>
<p>其他大多数仪表板卡都不调用WebApp，而是返回测试数据。 </p>

<p> ClientApp由以“ npm start”开头的webpack-dev-server提供服务。 WebApp使用Asp.Net Core中包含的Kestrel服务器。 Kestrel服务器响应Web API调用。但是它将内部ClientApp请求代理到webpack-dev-server。 </p>
<h2>独立调试/运行ClientApp </h2>
<ul>
<li>在app.module.ts中，将“ isAspServerRunning”从true更改为false。 </li>
<li> npm开始</li>
<li>在调试面板中，设置启动配置“ ClientApp” </li>
<li>按F5（调试）或Ctrl-F5（无需调试即可运行） </li>
</ul>
<p>当“ isAspServerRunning”设置为false时，将使用存根服务，而不是调用WebApp API。当我们仅在ClientApp中修改代码时，这很有用。 </p>
<h2>调试/运行WorkflowApp </h2>
<ul>
<li>在调试面板中，设置启动配置“ WorkflowApp” </li>
<li>按F5（调试）或Ctrl-F5（无需调试即可运行） </li>
</ul>
<p>当WorkflowApp启动时： </p>

<ul>
<li>将一些测试文件复制到Datafles / RECEIVED文件夹中：成绩单PDF文件和MP4录制文件。 </li>
<li>处理成绩单PDF文件并创建一个随时可以标记的JSON文件。 </li>
<li>通过在云中转录来处理录制的MP4文件，并创建一个可供校对的JSON文件。 </li>
</ul>
<p>结果可以在数据文件/处理中找到。但是，您首先需要设置一个<a href="about?id=setup#GoogleCloud">Google Cloud帐户</a> ，以便转录该记录。 </p>
<hr />
<p><a name="DevelopVS"></a></p>
<h1>使用Visual Studio开发<br/></h1>
<p> <a href="about?id=setup#Contents">[内容]</a> </p>

<ul>
<li>安装免费的<a href="https://visualstudio.microsoft.com/free-developer-offers/">Visual Studio社区版。</a> </li>
<li>在安装过程中，选择“ ASP.NET”和“ .NET桌面”工作负载。 </li>
<li>安装扩展程序：（全部由Mads Kristensen提供） 
<ul>
<li> “ NPM任务运行器” </li>
<li> “命令任务运行器” </li>
<li> “降价编辑器” </li>
</ul></li>
<li>打开解决方案文件“ govmeeting.sln” </li>
</ul><h2>调试/运行ClientApp和WebApp </h2>
<ul>
<li>在任务运行程序资源管理器（ClientApp）中： 
<ul>
<li>运行“安装” </li>
<li>运行“开始” </li>
</ul></li>
<li>将启动项目设置为“ WebApp” </li>
<li>按F5（调试）或Ctrl-F5（无需调试即可运行） </li>
<li> WebApp将运行，浏览器将打开，并显示ClientApp。 </li>
</ul>
<p>注意：在Visual Studio的Angular ClientApp中设置断点存在问题。请参阅： <a href="https://github.com/govmeeting/govmeeting/issues/80">Github第80期</a> </p>
<h2>调试WorkflowApp </h2>
<ul>
<li>打开调试面板。 </li>
<li>将启动项目设置为“ WorkflowApp” </li>
<li>按F5（调试）或Ctrl-F5（无需调试即可运行） </li>
</ul>
<p>注意：请参阅“ Visual Studio代码”下有关WorkflowApp的注释</p>
<hr />
<p><a name="DevelopOther"></a></p>
<h1>在其他平台上开发<br/></h1>
<p> <a href="about?id=setup#Contents">[内容]</a> </p>

<p>在您的配置文件中，将环境变量ASPNETCORE_ENVIRONMENT设置为“开发”。 WebApp和WorkflowApp使用它。 </p>
<h2>生成并运行ClientApp </h2>
<p>执行： </p>

<ul>
<li> cd前端/ ClientApp </li>
<li> npm安装</li>
<li> npm开始</li>
</ul>
<p>在浏览器中转到localhost：4200。客户端应用将加载。在WebApp运行之前，某些功能将不起作用。 </p>
<h2>使用ClientApp构建和运行WebApp </h2>
<p>执行： </p>

<ul>
<li> （执行上述操作：“构建并启动ClientApp”） </li>
<li> cd ../../Backend/WebApp </li>
<li> dotnet构建webapp.csproj </li>
<li> dotnet运行bin / debug / dotnet2.2 / webapp.dll </li>
</ul>
<p>在浏览器中转到localhost：5000。客户端应用将加载。 </p>
<h2>独立构建和运行ClientApp </h2>
<ul>
<li>在app.module.ts中，将“ isAspServerRunning”从true更改为false。 </li>
<li> （执行上述操作：“构建并启动ClientApp”） </li>
</ul><h2>生成并运行WorkflowApp </h2>
<p>执行： </p>

<ul>
<li> cd后端/ WorkflowApp </li>
<li> dotnet构建工作流程app.csproj </li>
<li> dotnet运行bin / debug / dotnet2.0 / workflowapp.dll </li>
</ul>
<p>注意：请参阅“ Visual Studio代码”下有关WorkflowApp的注释</p>
<!-- END OF README SECTION --><hr />
<p><a name="Database"></a></p>
<h1>数据库<br/></h1>
<p> <a href="about?id=setup#Contents">[内容]</a> </p>

<p>您可能不需要安装和设置数据库即可进行开发。有一些测试存根可以代替调用数据库。请参阅下面的“测试存根”。 </p>
<h2>安装提供程序</h2>
<p>如果使用的是Visual Studio或Visual Studio Code，则已经安装了Sql Server Express LocalDb提供程序。否则，请执行下面的“ LocalDb Provider安装”。 </p>
<h3> LocalDb提供程序安装</h3>
<p>转到<a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">Sql Server Express。</a>对于Windows，请下载SQL Server的“ Express”专业版。在安装过程中，选择“自定义”，然后选择“ LocalDb”。 </p>

<p> LocalDb也可用于MacO和Linux。如果您将其安装在任何一个平台上，请按照以下步骤更新本文档，然后执行“拉取请求”。 </p>
<h3>其他提供者</h3>
<p>除LocalSb之外，EF Core还支持<a href= "https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli">其他提供程序</a> （包括SqlLite）可用于开发。您将需要在startup.cs中修改DbContext设置，并在appsettings.json中修改连接字符串。 </p>
<h2>建立数据库架构</h2>
<p>该数据库是通过Entity Framework Core的“代码优先”功能构建的。它检查数据模型中的C＃类，并自动创建所有表和关系。有两个步骤：（1）创建用于执行更新的“迁移”代码，以及（2）执行更新。 </p>

<ul>
<li> cd后端/ WebApp </li>
<li> dotnet ef迁移会添加初始--project .. \ Database \ DatabaseAccess_Lib </li>
<li> dotnet ef数据库更新--project .. \ Database \ DatabaseAccess_Lib </li>
</ul><h2>探索创建的数据库</h2><h3>在VsCode中</h3>
<p>将以下内容添加到VsCode中的用户settings.json中： </p>
<pre> <code> "mssql.connections": [ { "server": "(localdb)\\mssqllocaldb", "database": "Govmeeting", "authenticationType": "Integrated", "profileName": "GMProfile", "password": "" } ],</code> </pre>
<ul>
<li>按ctrl-alt-D或按左边距的Sql Server图标。 </li>
<li>打开GMProfile连接以查看和使用数据库对象。 </li>
<li>打开“表”。您应该看到在构建以上架构时创建的所有表。这包括用于授权的AspNetxxxx表和用于Govmeeting数据模型的表。 </li>
</ul><h3>在Visual Studio中</h3>
<ul>
<li>转到菜单项：视图-&gt; SQL Server对象资源管理器。 </li>
<li>展开SQL Server-&gt;（localdb）\ MSSQLLocalDb-&gt;数据库-&gt; Govmeeting </li>
<li>打开“表”。您应该看到在构建以上架构时创建的所有表。这包括用于授权的AspNetxxxx表和用于Govmeeting数据模型的表。 </li>
</ul><h3>其他平台</h3>
<p>有跨平台和开放源代码的<a href="https://github.com/Microsoft/sqlopsstudio?WT.mc_id=-blog-scottha">SQL Operations Studio，</a> “一种数据管理工具，可从Windows，macOS和Linux使用SQL Server，Azure SQL DB和SQL DW。”您可以<a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha">在此处免费</a>下载<a href="https://docs.microsoft.com/en-us/sql/sql-operations-studio/download?view=sql-server-2017&WT.mc_id=-blog-scottha">SQL Operations Studio。</a> </p>

<p>如果使用此工具或其他工具来浏览SQL Server数据库，请更新这些说明。 </p>
<h2>测试存根</h2>
<p>尚未编写用于在数据库中存储/检索笔录数据的代码。因此，DatabaseRepositories_Lib改为使用静态测试数据。在WebApp / appsettings.json中，属性“ UseDatabaseStubs”设置为“ true”，告诉它调用存根例程。 </p>

<p>但是，WebApp中的用户注册和登录代码确实使用该数据库。它访问Asp.Net用户身份验证表。 WebApp根据当前登录的用户对来自ClientApp的API调用进行身份验证。 </p>

<p>您可以在WebApp中使用“ NOAUTH”预处理器值来绕过身份验证。使用以下方法之一： </p>

<ul>
<li>在FixasrController.cs或AddtagsController.cs中，取消注释文件顶部的“ #if NOAUTH”行。 </li>
<li>要对所有控制器禁用它，请将其添加到WebApp.csproj： </li>
</ul><pre> <code> &lt;PropertyGroup Condition="&#39;$(Configuration)|$(Platform)&#39;==&#39;Debug|AnyCPU&#39;&gt; &lt;DefineConstants&gt;NOAUTH&lt;/DefineConstants&gt; &lt;/PropertyGroup&gt;</code> </pre>
<ul>
<li>在Visual Studio中，转到WebApp属性页-&gt;生成-&gt;并在“条件补偿符号”框中输入NOAUTH。 </li>
</ul><hr />
<p><a name="GoogleCloud"></a></p>
<h1> Google Cloud Platform帐户<br/></h1>
<p> <a href="about?id=setup#Contents">[内容]</a> </p>

<p>要使用Google Speech API进行语音到文本的转换，您需要一个Google Cloud Platform（GCP）帐户。对于Govmeeting中的大多数开发工作，您可以使用使用现有的测试数据。但是，如果您想转录新的录音，则需要一个GCP。 Google API可以转录超过120种语言和变体形式的录音。 </p>

<p> Google为开发人员提供了一个免费帐户，其中包含一个抵免额（目前为300美元）。使用语音API的当前费用是每月60分钟的免费转换。此后，“增强模型”的成本（我们需要的）是每15秒$ 0.009。 （每小时$ 2.16） </p>

<ul>
<li>
<p>在<a href="https://cloud.google.com/free/">Google Cloud Platform上</a>开设一个帐户</p>
</li>
<li>
<p>转到<a href="http://console.cloud.google.com">Google Cloud Dashboard</a>并创建一个项目。 </p>
</li>
<li>
<p>转到<a href="http://console.developers.google.com">Google开发者控制台</a>并启用语音和云存储API </p>
</li>
<li>
<p>为该项目生成一个“服务帐户”凭证。单击开发者控制台中的凭据。 </p>
</li>
<li>
<p>授予该帐户对项目的“编辑者”权限。点击帐户。在下一页上，单击“权限”。 </p>
</li>
<li>
<p>下载凭证JSON文件。 </p>
</li>
<li>
<p>将文件放在克隆存储库时创建的<code>_SECRETS</code>文件夹中。 </p>
</li>
<li>
<p>重命名文件<code>TranscribeAudio.json</code> 。 </p>
</li>
</ul>
<p>注意：以上步骤可能已稍作更改。如果是这样，请更新此文档。 </p>
<h2>测试语音到文本的转录</h2>
<ul>
<li>
<p>在Visual Studio中将启动项目设置为<code>Backend/WorkflowApp</code> 。按F5。 </p>
</li>
<li>
<p>将一个示例MP4文件（不要移动）从testdata复制到Datafiles / RECEIVED。 </p>
</li>
</ul>
<p>程序现在将识别出出现了新文件并开始处理它。完成后，MP4文件将移至“ COMPLETED”。您将在sufolder中看到结果，该文件夹是在“ Datafiles”目录中创建的。 </p>

<p>在appsettings.json中，有一个属性“ RecordingSizeForDevelopment”。当前设置为“ 180”。这将导致ProcessRecording_Lib中的转录例程仅处理记录的前180秒。 </p>
<hr />
<p><a name="GoogleApi"></a></p>
<h1> Google API密钥<br/></h1>
<p> <a href="about?id=setup#Contents">[内容]</a> </p>

<p>如果要使用或使用注册和登录过程的某些功能，则需要这些键。 </p>

<ul>
<li>在用户注册期间，需要ReCaptcha密钥才能使用ReCaptcha。可以从<a href="https://developers.google.com/recaptcha/">Google reCaptcha</a>获得它们。 </li>
<li> OAuth 2.0凭据用于进行外部用户登录，而无需用户在网站上创建个人帐户。访问<a href="https://console.developers.google.com/">Google API控制台</a>以获取凭据，例如客户端ID和客户端密钥。 </li>
</ul>
<p>在“ _SECRETS”文件夹中创建一个名为“ appsettings.Development.json”的文件。它应该包含您刚刚获得的密钥： </p>
<pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-Id", "ClientSecret": "your-client-secret" } }, "ReCaptcha:SiteKey": "your-site-key", "ReCaptcha:Secret": "your-secret" }</code> </pre><hr /><h2>测试验证码</h2>
<ul>
<li>运行WebApp项目。 </li>
<li>点击右上方的“注册”。 </li>
<li> reCaptcha选项应该出现。 </li>
</ul><hr /><h2>测试Google身份验证</h2>
<ul>
<li>运行WebApp项目。 </li>
<li>点击右上方的“登录”。 </li>
<li>在“使用其他服务登录”下，选择“ Google”。 </li>
</ul>