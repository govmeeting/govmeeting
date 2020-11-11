<h1>处理新的成绩单格式</h1>
<p>最终目标是编写可处理任何脚本格式的代码。但是在那之前，我们需要编写自定义代码来处理每种新格式。当我们有足够的不同格式的样本时，我们将能够更好地编写通用代码。 </p>

<p>这些是处理新成绩单格式的步骤： </p>

<ul>
<li>
<p>以pdf或文本文件的形式获取政府会议的笔录样本。 </p>
</li>
<li>
<p>命名文件如下：“ country_state_county_municipality_agency_language-code_date.pdf”。 （或.txt）例如： </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p>在项目“ ProcessTranscripts_Lib”中，使用接口“ ISpecificFix”创建一个新类。 </p>
</li>
<li>
<p>将类命名为“ country_state_county_municipality_agency_language-code”。例如： </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p>实现类方法： </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix（）接收现有的脚本文本，并以以下格式返回文本： </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p>此类完成后，WorkflowApp将在新成绩单出现在“ DATAFILES / RECEIVED”中时对其进行处理。 </p>

<p>笔记： </p>

<p>我们使用System.Reflection根据要处理的文件的名称实例化正确的类。 </p>

<p>有关示例，请参见ProcessTranscripts_Lib中的类“ USA_PA_Philadelphia_Philadelphia_CityCouncil_en”。通过查看作为参数传递给Fix（）的“工作文件夹”中的日志文件跟踪，您可以更好地了解此类的功能。 </p>

<p>我们现在不提取以下信息，但是最终将要这样做。 </p>

<ul>
<li>出席人员</li>
<li>法案和决议介绍</li>
<li>投票结果</li>
</ul>
<p>美国德克萨斯州奥斯汀市-美国也有在线公开会议的笔录。在ProcessTranscripts_Lib中创建了一个名为“ USA_TX_TravisCounty_Austin_CityCouncil_en”的类。但是Fix（）方法没有实现。成绩单可从其网站获得： <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">德克萨斯州奥斯汀市议会</a> </p>
<h1>修改客户端仪表板</h1><h2>添加新功能卡</h2>
<ul>
<li>在终端提示下，移至以下文件夹：FrontEnd / ClientApp </li>
<li>输入：ng生成您的特征部件</li>
<li>将功能添加到以下文件中：FrontEnd / ClientApp / src / app /您的功能</li>
<li>在app / dash-main / dash-main.html中插入一个新的gm-small-card或gm-large-card元素。 </li>
<li>修改卡片元素的图标，iconcolor，标题等。 </li>
<li>如果您需要访问控制器中当前所选地点和代理商的名称，请执行以下操作： 
<ul>
<li>将位置和代理商输入属性添加到要素元素</li>
<li>在控制器中添加位置和代理商@Input属性。 </li>
</ul></li>
</ul>
<p> （请参阅dash-main.html中的其他示例） </p>
<h2>重新安排卡片</h2><ol>
<li>打开文件：FrontEnd / ClientApp / src / app / dash-main / dash-main.html。 </li>
<li>通过更改gm-smallcard或gm-largecard元素在此文件中的位置来更改卡的位置。 </li></ol><h1>记录中</h1>
<p> WebApp和WorkflowApp的日志文件位于解决方案根目录的“ logs”文件夹中。 </p>

<ul>
<li> “ nlog-all-（date）.log”包含所有日志消息，包括系统。 </li>
<li>文件“ nlog-own-（date）.log”仅包含应用程序消息。 </li>
</ul>
<p>在ClientApp的许多组件文件的顶部，定义了一个常量“ NoLog”。将其值从true更改为false以仅打开该组件的控制台日志记录。 </p>
<h1>构建脚本</h1>
<p> Powershell构建脚本可在实用程序/ PsScripts中找到</p>

<ul>
<li> BuildPublishAndDeploy.ps1-调用其他脚本来构建发行版并进行部署。 </li>
<li> Build-ClientApp.ps1-构建ClientApp的生产版本</li>
<li> Publish-WebApp.ps1-构建WebApp的“发布”文件夹</li>
<li> Copy-ClientAssets.ps1-将ClientApp资产复制到WebApp wwwroot文件夹</li>
<li> Deploy-PublishFolder.ps1-将发布文件夹部署到远程主机</li>
<li>从文档文件为Gethub创建README.md文件</li>
</ul>
<p> Deploy-PublishFolder.ps1使用FTP将软件部署到govmeeting.org。 FTP登录信息位于SECRETS文件夹中的文件appsettings.Development.json中。它包含用于开发的FTP和其他机密。以下是FTP使用的此文件部分： </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
