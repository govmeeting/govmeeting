<h1>处理新成绩单</h1>
<p>一些城市会产生会议记录。这使我们可以跳过自己抄录会议的内容。但这提出了一个不同的问题。成绩单不是标准格式。 </p>

<p>我们的软件将需要： </p>

<ul>
<li>提取信息。 </li>
<li>添加使信息易于使用的标签。 </li>
</ul>
<p>通常要提取的成绩单中的信息是： </p>

<ul>
<li>会议信息：时间，地点，是否为特别会议。 </li>
<li>出席人员</li>
<li>章节标题</li>
<li>每个演讲者的名字和他们说的话。 </li>
</ul>
<p>如果没有节标题，则该软件应足够聪明，可以确定常见节从何处开始： </p>

<ul>
<li>角色召唤</li>
<li>调用方式</li>
<li>委员会报告</li>
<li>法案介绍</li>
<li>决议案</li>
<li>公众意见</li>
</ul>
<p>我们将需要了解我们还能如何在法案和决议中提取投票结果。有时，结果用诸如“赞成”的短语表示。其他时间则进行正式投票，其中大声读出每个官员的名字，然后该人以“是”或“否”答复。 </p>

<p>需要删除多余的信息。例如：重复页眉或页脚，行号和页码。 </p>

<p>希望可以编写能够从从未有过的新笔录中提取信息的通用代码。但是，在此之前，将需要编写新代码来处理特定情况。 </p>

<p>由于通常只有较大的城市会产生成绩单： </p>

<ul>
<li>大多数时候，我们将处理会议记录。 </li>
<li>在较大的城市中，有更多可能的计算机程序员可以编写此类代码。 </li>
</ul>
<p>我们可以构建一个插件机制，该机制允许添加执行提取的模块。我们可以允许以多种不同的语言编写插件：Python，Java，PHP，Ruby-除了系统当前使用的语言：Typescript和C＃。 </p>

<p>目前，该软件仅处理一种情况，美国宾夕法尼亚州费城。项目库“ Backend \ ProcessMeetings \ ProcessTranscripts_lib”包含用于处理脚本的代码。 </p>

<p>类“ Specific_Philadelphia_PA_USA”调用一些通用例程来处理费城的笔录。 </p>

<p>有一个存根类“ Specific_Austin_TX_USA”，用于处理德克萨斯州奥斯汀的笔录。也许somone会想要完成此代码。 Testdata文件夹中有一个测试成绩单。但是，最好从他们的网站获取最新信息： <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">德克萨斯州奥斯汀市议会</a> </p>
<h1>修改客户端仪表板</h1><h2>添加新功能卡</h2>
<ul>
<li>在终端提示下，移至以下文件夹：FrontEnd / ClientApp </li>
<li>输入：ng生成您的特征部件</li>
<li>将您的功能添加到以下文件中：FrontEnd / ClientApp / src / app /您的功能</li>
<li>在app / dash-main / dash-main.html中插入一个新的gm-small-card或gm-large-card元素。 </li>
<li>修改卡片元素的图标，iconcolor，标题等。 </li>
<li>如果您需要访问控制器中当前所选位置和代理商的名称，请执行以下操作： 
<ul>
<li>将位置和代理商输入属性添加到要素元素中</li>
<li>在控制器中添加位置和代理商@Input属性。 </li>
</ul></li>
</ul>
<p> （请参阅dash-main.html中的其他示例） </p>
<h2>重新安排卡片</h2><ol>
<li>打开文件：FrontEnd / ClientApp / src / app / dash-main / dash-main.html。 </li>
<li>通过更改此文件中gm-small-card或gm-large-card元素的位置来更改卡的位置。 </li></ol><h1>记录中</h1>
<p> WebApp和WorkflowApp的日志文件位于解决方案根目录的“ logs”文件夹中。 </p>

<ul>
<li> “ nlog-all-（date）.log”包含所有日志消息，包括系统。 </li>
<li>文件“ nlog-own-（date）.log”仅包含应用程序消息。 </li>
</ul>
<p>在ClientApp的许多组件文件的顶部，定义了一个常量“ NoLog”。将其值从true更改为false以仅打开该组件的控制台日志记录。 </p>
<h1>构建脚本</h1>
<p> Powershell构建脚本可在实用程序/ PsScripts中找到</p>
<h2> BuildPublishAndDeploy.ps1 </h2>
<p>该脚本调用许多其他脚本来构建生产版本并进行部署。 </p>

<ul>
<li> Build-ClientApp.ps1-构建ClientApp的生产版本</li>
<li> Publish-WebApp.ps1-构建WebApp的“发布”文件夹</li>
<li> Copy-ClientAssets.ps1-将ClientApp资产复制到WebApp wwwroot文件夹</li>
<li> Deploy-PublishFolder.ps1-将发布文件夹部署到远程主机</li>
<li>从文档文件为Gethub创建README.md文件</li>
</ul>
<p> Deploy-PublishFolder.ps1使用FTP将软件部署到govmeeting.org。 FTP登录信息位于_SECRETS文件夹中的文件appsettings.Development.json中。它包含用于开发的FTP和其他机密。以下是此文件的格式： </p>
<pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-id", "ClientSecret": "your-client-secret" } }, "ReCaptcha": { "SiteKey": "your-site-key", "Secret": "your-secret" }, "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } }</code> </pre>