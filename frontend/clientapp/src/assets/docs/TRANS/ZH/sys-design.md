<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle">设计</mat-card-title>
<markdown ngPreserveWhitespaces>

<p>下图显示了软件组件之间的交互。 </p>

<ul>
<li>
<p> ClientApp是在浏览器中运行的Angular Typescript单页应用程序。它提供了用户界面。 </p>
</li>
<li>
<p> WebApp是在服务器上运行的<a href="https://github.com/aspnet/home">Asp.Net Core</a> C＃应用程序。它响应WebApi调用。 </p>
</li>
<li>
<p> WorkflowApp是在服务器上运行的<a href="https://github.com/dotnet/core">DotNet Core</a> C＃应用程序。它对记录和成绩单进行批处理。也可以将其转换为作为WebApp流程的一部分运行的库。 </p>
</li>
<li>
<p>其他服务器组件是DotNet Core C＃库。 WebApp和WorkflowApp都使用它们。 </p>
</li>
</ul><hr /><h2>系统设计</h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

<p>上图中的组件是： </p>

<table style="width:100%">
<tr><th colspan="2">应用领域</th></tr>
<tr><td> ClientApp </td><td>角SPA </td></tr>
<tr><td>网络应用</td><td> Asp.Net Web服务器进程</td></tr>
<tr><td>工作流程应用</td><td>工作流服务器控制流程</td></tr>
<tr><th colspan="2">图书馆</th></tr>
<tr><td> GetOnlineFiles </td><td>检索在线成绩单和录音</td></tr>
<tr><td>过程记录</td><td>提取和转录音频。创建工作细分。 </td></tr>
<tr><td>流程记录</td><td>转换原始成绩单</td></tr>
<tr><td>加载数据库</td><td>使用完成的笔录中的数据填充数据库</td></tr>
<tr><td>在线访问</td><td>从远程站点检索文件的例程</td></tr>
<tr><td> GoogleCloudAccess </td><td>访问Google Cloud服务的例程</td></tr>
<tr><td> FileDataRepositories </td><td>存储并获取JSON工作文件数据</td></tr>
<tr><td>数据库仓库</td><td>从数据库存储和获取模型数据</td></tr>
<tr><td>数据库访问</td><td>使用实体框架访问数据库</td></tr>
</table>
<hr /><h2> ClientApp设计</h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

<p> ClientApp的结构最好通过其Angular Component结构来显示</p>

<table style="width:100%">
<tr><th colspan="2">应用组件</th></tr>
<tr><td>标头</td><td>标头</td></tr>
<tr><td>西德纳夫</td><td>侧边栏导航</td></tr>
<tr><td>仪表板</td><td>仪表板组件的容器</td></tr>
<tr><td>文献资料</td><td>文档页面的容器</td></tr>
<tr><th colspan="2">仪表板组件</th></tr>
<tr><td> Fixasr </td><td>修复自动语音识别文本</td></tr>
<tr><td>添加标签</td><td>向成绩单添加标签</td></tr>
<tr><td> ViewMeeting </td><td>查看完成的成绩单</td></tr>
<tr><td>问题</td><td>查看有关问题的信息</td></tr>
<tr><td>警报</td><td>查看和设置警报信息</td></tr>
<tr><td>官员们</td><td>查看官员信息</td></tr>
<tr><td> （其他）） </td><td>其他要实施的组件</td></tr>
<tr><th colspan="2">服务</th></tr>
<tr><td>虚拟会议</td><td>召开虚拟会议</td></tr>
<tr><td>聊天室</td><td>用户聊天组件</td></tr>
</table>
<hr /><h2> WebApp设计</h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

<p>每个Web API都很小，它们调用存储库以放置数据库或文件系统中的数据或从中获取数据。 </p>

<table style="width:100%">
<tr><th colspan="2">控制器</th></tr>
<tr><td> Fixasr </td><td>保存并获取最新版本的成绩单进行校对。 </td></tr>
<tr><td>添加标签</td><td>保存并获取被标记的成绩单的最新版本。 </td></tr>
<tr><td>视讯会议</td><td>获取最新的完整脚本。 </td></tr>
<tr><td>政府机构</td><td>保存并获取注册的政府机构数据。 </td></tr>
<tr><td>会议会议</td><td>保存并获取会议信息。 </td></tr>
<tr><td>视频</td><td>获取会议视频。 </td></tr>
<tr><td>帐户</td><td>处理用户注册和登录。 </td></tr>
<tr><td>管理</td><td>用户可以管理其个人资料。 </td></tr>
<tr><td>管理员</td><td>管理员可以管理用户，策略和声明</td></tr>
<tr><th colspan="2">服务</th></tr>
<tr><td>电子邮件</td><td>处理注册电子邮件确认。 </td></tr>
<tr><td>信息</td><td>通过短信处理注册确认。 </td></tr>
</table>
<hr /><h2>工作流程应用程序设计</h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

<p>特定会议的工作流程状态保存在数据库的会议记录中。每个工作流程组件均独立运行。依次调用它们以检查可用的工作。每个组件将在数据库中查询符合其可用工作标准的会议。如果找到工作，他们将执行该工作并更新数据库中的会议状态。 </p>

<p>为了构建可以从故障中恢复的健壮系统，我们将需要将工作流中的步骤视为“事务”。事务完全完成还是根本没有完成。如果在处理步骤中出现不可恢复的失败，则该会议的状态将回滚到最后一个有效状态。该代码当前不实现事务。 （跟随的Gitub问题） </p>

<p>下面为组件提供了伪代码</p>

<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li>对于系统中的所有政府实体</li>
<ul>
<li>检查会议时间表以检索</li>
<li>检索记录或成绩单文件</li>
<li>将文件放在DATAFILES \ Received文件夹中</li>
</ul>
<li>用户上传也可以将文件放置在Received文件夹中。 </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li>对于DATAFILES \ Received中的文件，并且数据库记录不存在： </li>
<ul>
<li>确定文件类型</li>
<li>创建数据库记录</li>
<li>设置状态=已接收，已批准=否</li>
<li>向经理发送消息：“已收到” </li>
</ul>
</ul>
<li>转录记录</li>
<ul>
<li>对于源类型=正在录制，状态=已接收，已批准=真的录制</li>
<ul>
<li>创建工作文件夹</li>
<li>设置状态=正在转录，已批准=否</li>
<li>转录录音</li>
<li>设置状态=已转录，已批准=否</li>
<li>向经理发送消息：“已转录” </li>
</ul>
</ul>
<li>处理成绩单</li>
<ul>
<li>对于来源类型为transcript的成绩单，状态为已接收，批准为true </li>
<ul>
<li>创建工作文件夹</li>
<li>设置状态=正在处理，已批准=否</li>
<li>处理成绩单</li>
<li>设置状态=已处理，已批准=否</li>
<li>向经理发送消息：“已处理” </li>
</ul>
</ul>
<li>校对记录</li>
<ul>
<li>对于状态=已转录/已批准=真的录制</li>
<ul>
<li>创建工作文件夹</li>
<li>设置状态=校对，批准=假</li>
<li>现在将进行手动校对</li>
</ul>
<li>对于状态为校对的录制</li>
<ul>
<li>检查校对是否完成。如果是这样的话： </li>
<li>设置状态=校对，已批准=否</li>
<li>向经理发送消息：“校对” </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li>对于状态为校对，已批准为true的记录，或状态为已处理，已批准为true的成绩单</li>
<ul>
<li>创建工作文件夹</li>
<li>设置状态=标记，已批准=否</li>
<li>现在将进行手动标记</li>
</ul>
</ul>
<ul>
<li>对于状态为=标记的成绩单</li>
<ul>
<li>检查标记是否完整。如果是这样的话： </li>
<li>设置状态=已标记，已批准=否</li>
<li>向经理发送消息：“已标记” </li>
</ul>
</ul>
<li>载入文字</li>
<ul>
<li>对于状态=已标记，已批准=真的会议
<ul>
<li>设置状态=正在加载，已批准=否</li>
<li>将会议内容加载到数据库中</li>
<li>设置状态=已加载，已批准=否</li>
<li>向经理发送消息：“已加载” </li>
</ul>
</ul>
</ul><hr /><h2>用户机密</h2>
<p>当从Github克隆govmeeting存储库时，除了“ SECRETS”文件夹外，您将获得所有内容。该文件夹位于资源库外部。它包含以下“秘密”信息： </p>

<ul>
<li> Google外部授权服务的ClientId和ClientSecret。 </li>
<li> Google ReCaptcha服务的SiteKey和Secret。 </li>
<li> Google Cloud Platform的凭证。 </li>
<li>数据库连接字符串。 </li>
<li>管理员用户名和密码。 </li>
</ul>
<p> SECRETS文件夹可能包含四个文件。 </p>

<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> appsettings.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul>
<p> TranscribeAudio.json包含Google Cloud Platform凭据。其他三个文件中的每个文件可能包含其他每个秘密的设置。 appsettings.Production.json应该包含所有生产设置。这些文件中的任何设置都将覆盖Server / WebApp / app.settings.json中的设置。该文件包含在存储库中。 </p>

<p>如果您希望本地计算机能够访问Google服务，则需要创建与存储库所在位置有关的本地文件夹“ ../SECRETS”。例如，您可以添加文件“ appsettings.Development”。 json”，其中包含您从Google获得的密钥。请参阅： <a href="home#google-api-keys">Google API密钥</a> </p>
<hr /><h1>文献资料</h1>
<p>该文档最初保存在Github Wiki页面中。但是出于两个原因，决定将页面移入主项目本身： </p>

<ul>
<li>您不能在Github Wiki页面上进行更改请求。这使社区成员很难更改文档。 </li>
<li>如果文档与同一存储库中的代码一起，则文档很有可能与代码保持同步。用于代码更改的单个PR可以包括与其相关的文档更改。 </li>
</ul>
<p>该文档使用Markdown编写，位于Frontend / ClientApp / src / app / assets / docs中。 </p>

</markdown>

<p> &lt;/ mat-card&gt; </p>
