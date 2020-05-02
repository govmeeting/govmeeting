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
<p>数据库中的表包括： </p>
<ol>
<li>认证表。 </li></ol>
<p>这些是由Microsoft Identity Service在首次构建项目时选中“身份验证=个人用户帐户”时自动创建的。 </p>
<ol start="2">
<li>巡视表。 </li></ol>
<p>这些是通过实体框架的“代码优先”功能创建的。 EF读取“数据库/模型”项目库中的C＃类，并自动生成数据库模式和表。 </p>

<p>请参阅“设置”文档页面，以创建和使用数据库。 </p>
<h1>架构图</h1><h2> “政府实体”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th><th>例子3 </th></tr>
<tr><td>首要的关键</td><td>唯一键</td><td> 1个</td><td> 2 </td><td> 3 </td></tr>
<tr><td>名称</td><td>实体名称</td><td>参议院</td><td>部件</td><td>规划委员会</td></tr>
<tr><td>国家</td><td>国家位置</td><td>美国</td><td>美国</td><td>美国</td></tr>
<tr><td>州</td><td>状态位置</td><td></td><td>爱荷华州</td><td>新泽西州</td></tr>
<tr><td>县</td><td>县或地区的位置</td><td></td><td></td><td>格洛斯特</td></tr>
<tr><td>市政的</td><td>城市或城镇</td><td></td><td></td><td>门罗镇</td></tr>
</table>

<p> *政府实体表的更多示例</p>

<table><tr><th>领域</th><th>例子4 </th><th>例子5 </th></tr>
<tr><td>首要的关键</td><td> 4 </td><td> 5 </td></tr>
<tr><td>名称</td><td>维丹·萨卜哈（Vidhan Sabha） </td><td>市议会</td></tr>
<tr><td>国家</td><td>印度</td><td>印度</td></tr>
<tr><td>州</td><td>安德拉邦</td><td>安德拉邦</td></tr>
<tr><td>县</td><td></td><td>卡达帕区</td></tr>
<tr><td>市政的</td><td></td><td>雷阿乔蒂</td></tr>
</table>

<p>请注意，如果政府实体处于国家级别，则其州，县和市级地理位置为空。如果实体处于州一级，则其县市位置为空，等等。 </p>

<p>需要其他国家的例子。如果您还有其他示例，请编辑此文档并在Github中发出“拉取请求”。如果出于某些原因在某些国家/地区无法使用该功能，请在Github上提交问题。 </p>
<hr /><h2> “会议”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th></tr>
<tr><td>首要的关键</td><td>唯一键</td><td> 1个</td><td> 2 </td></tr>
<tr><td>政府实体</td><td>政府实体的钥匙</td><td> 2（美国参议院） </td><td> 4（Vidhan Sabha） </td></tr>
<tr><td>时间</td><td>会议时间</td><td> 14年8月3日19:30 </td><td> 14年5月2日13:00 </td></tr>
<tr><td>文本</td><td>转录文字</td><td> “会议将开始进行。……” </td><td> “大会将召开。...” </td></tr>
</table>
<hr /><h2> “代表”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th></tr>
<tr><td>首要的关键</td><td>唯一键</td><td> 1个</td><td> 2 </td></tr>
<tr><td>全名</td><td>全名</td><td>众议员史蒂夫·琼斯</td><td>董事长拉维·阿南德（Ravi Anand） </td></tr>
<tr><td>识别码</td><td>个人识别码</td><td> （即将被决定</td><td> （即将被决定） </td></tr>
</table>

<p>会议的发言人可以是理事机构或普通公众的代表。在任何一种情况下，一个以上的政府实体中都可能有同一个人参加会议。我们将希望追踪同一位代表在其所隶属的每个机构中所说的话。因此，我们需要每个代表都有唯一的标识符。 </p>

<p>我们将需要确定此识别所需的信息。很明显，我们不会提供具有这种性质的人的身份证号码。我们可能需要使用多个字段的组合来识别某人。例如，地址和名称。 </p>

<p>将有一个“代表”表，其中包含每个代表的唯一个人标识符。 </p>
<hr /><h2> “ RepresentativeToEntity”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th><th>例子3 </th></tr>
<tr><td>代表</td><td>代表的关键</td><td> 1个</td><td> 2 </td><td> 2 </td></tr>
<tr><td>政府实体</td><td>政府实体的钥匙</td><td> 5 </td><td> 7 </td><td> 9 </td></tr>
</table>

<p>还有一个表“ RepresentativeToEntity”，该表链接了代表及其所服务的政府实体。请注意，同一位代表可以在多个政府实体中任职。 </p>
<hr /><h2> “公民”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th></tr>
<tr><td>首要的关键</td><td>唯一键</td><td> 1个</td><td> 2 </td></tr>
<tr><td>名称</td><td>名称</td><td>约翰·J </td><td>莱·S。 </td></tr>
<tr><td>会议</td><td>会议的关键</td><td> 2（美国参议院于14年8月3日召开会议） </td><td> 4（Vidhan Sabha于14年5月2日召开会议） </td></tr>
</table>

<p>将为公众提供一个“公民”表。市民表将包含一个外键，指向此人讲话的会议。 </p>

<p>我们是否应该在所有出席的会议上跟踪公众的意见？也许那不合适。 </p>

<p>如果不是，则无需尝试唯一标识公共发言人。该人在会议上讲话时所给出的名称可用于识别仅用于该会议的人。我们无需在会议之间关联该名称。我们甚至可能更喜欢只存储名字和姓氏。 </p>
<hr /><h2> “主题”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th><th>例子3 </th></tr>
<tr><td>首要的关键</td><td>唯一键</td><td> 1个</td><td> 2 </td><td> 3 </td></tr>
<tr><td>政府实体</td><td>政府实体的钥匙</td><td> 2（美国参议院） </td><td> 2（美国参议院） </td><td> 4（Vidhan Sabha） </td></tr>
<tr><td>类型</td><td>类别或主题</td><td>类别</td><td>话题</td><td>类别</td></tr>
<tr><td>名称</td><td>主题名称</td><td>健康</td><td>奥巴马医改</td><td>教育</td></tr>
</table>

<p>每个政府实体（例如，美国参议院或位于美国新泽西州门罗镇的分区委员会）在其会议上讨论的类别和主题都将有其自己的唯一名称。因此，标签名称表包含指向政府实体的外键。 </p>
<hr />
<p>会议的完整记录是一串文本。演讲者位置和标签位置表包含指向文本的指针，即演讲者或标签更改的起点和终点。这些将是文本字符串中的字符指针。 </p>
<h2> “扬声器标签”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th></tr>
<tr><td> PimaryKey </td><td>唯一键</td><td> 1个</td><td> 2 </td></tr>
<tr><td>扬声器</td><td>演讲者的关键</td><td> 1（众议员琼斯） </td><td> 2名（主席。阿南德） </td></tr>
<tr><td>会议</td><td>会议的关键</td><td> 1（会议1） </td><td> 2（会议2） </td></tr>
<tr><td>开始</td><td>发言者开始讲话的时间</td><td> 521 </td><td> 12045 </td></tr>
<tr><td>结束</td><td>说话者停止说话的时间</td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2> “主题标签”表</h2>
<table><tr><th>领域</th><th>含义</th><th>例子1 </th><th>例子2 </th></tr>
<tr><td>首要的关键</td><td>唯一键</td><td> 1个</td><td> 2 </td></tr>
<tr><td>标签</td><td>标签的钥匙</td><td> 1（能量） </td><td> 2（教育） </td></tr>
<tr><td>会议</td><td>会议的关键</td><td> 1（会议1） </td><td> 2（会议2） </td></tr>
<tr><td>开始</td><td>主题何时开始</td><td> 750 </td><td> 14500 </td></tr>
<tr><td>结束</td><td>主题何时停止</td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2>数据量</h2>
<p>最终会议数据库的大小很小。这将使我们能够构建将大部分数据存储在本地计算机或智能手机上的应用程序-以获得高性能和脱机运行应用程序的能力。 </p>
