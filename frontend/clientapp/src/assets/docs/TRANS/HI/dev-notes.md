<h1> नए प्रतिलिपि स्वरूपों को संसाधित करें </h1>
<p> अंतिम लक्ष्य कोड लिखना है जो किसी भी प्रतिलिपि प्रारूप को संसाधित करेगा। लेकिन तब तक, हमें प्रत्येक नए प्रारूप को संभालने के लिए कस्टम कोड लिखने की आवश्यकता होती है। जब हमारे पास विभिन्न प्रारूपों के पर्याप्त नमूने होंगे, तो हम जेनेरिक कोड लिखने में बेहतर होंगे। </p>

<p> ये नई प्रतिलेख प्रारूप से निपटने के चरण हैं: </p>

<ul>
<li>
<p> एक पीडीएफ या पाठ फ़ाइल के रूप में एक सरकारी बैठक का नमूना प्रतिलेख प्राप्त करें। </p>
</li>
<li>
<p> फ़ाइल का नाम इस प्रकार है: "country_state_county_m आवश्यकताएँity_agency_language-code_date.pdf"। (या .txt) उदाहरण के लिए: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> प्रोजेक्ट "ProcessTranscripts_Lib" में इंटरफ़ेस "ISpecificFix" के साथ एक नया वर्ग बनाएं। </p>
</li>
<li>
<p> कक्षा का नाम "country_state_county_m आवश्यकताएँity_agency_language-code" रखें। उदाहरण के लिए: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> वर्ग विधि को लागू करें: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> फिक्स () मौजूदा प्रतिलेख पाठ प्राप्त करता है और निम्नलिखित प्रारूप में पाठ लौटाता है: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> जब यह वर्ग पूरा हो जाता है, तो वर्कफ़्लोApp "DATAFILES / RECEIVED" में दिखाई देने पर नए ट्रांसक्रिप्ट की प्रक्रिया करेगा। </p>

<p> टिप्पणियाँ: </p>

<p> हम संसाधित की जाने वाली फ़ाइल के नाम के आधार पर सही वर्ग को तुरंत भरने के लिए System.Reflection का उपयोग करते हैं। </p>

<p> एक उदाहरण के लिए ProcessTranscripts_Lib में "USA_PA_Philadelphia_Philadelphia_CityCatalog_en" श्रेणी देखें। आप बेहतर तरीके से समझ सकते हैं कि "वर्कफ़्लो" में लॉग फ़ाइल के निशान को देखकर यह वर्ग क्या कर रहा है जो कि फिक्स () के तर्क के रूप में पारित हो गया है। </p>

<p> हम अब निम्नलिखित जानकारी नहीं निकालते हैं, लेकिन हम अंततः ऐसा करना चाहेंगे। </p>

<ul>
<li> उपस्थिति में अधिकारी </li>
<li> बिल और संकल्प पेश किए </li>
<li> मतदान के परिणाम </li>
</ul>
<p> ऑस्टिन, TX - यूएसए में ऑनलाइन सार्वजनिक बैठकों के टेप भी हैं। ProcessTranscripts_Lib में एक वर्ग "USA_TX_TravisCounty_Austin_CityCatalog_en" बनाया गया था। लेकिन फिक्स () विधि को लागू नहीं किया गया था। उनकी वेबसाइट से प्राप्त किया जा सकता है: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">ऑस्टिन, TX सिटी काउंसिल</a> </p>
<h1> क्लाइंट डैशबोर्ड को संशोधित करें </h1><h2> नई सुविधा के लिए एक कार्ड जोड़ें </h2>
<ul>
<li> टर्मिनल प्रॉम्प्ट पर, फ़ोल्डर में जाएँ: FrontEnd / ClientApp </li>
<li> दर्ज करें: एनजी उत्पन्न घटक आपकी सुविधा </li>
<li> फ़ाइलों में अपनी कार्यक्षमता जोड़ें: FrontEnd / ClientApp / src / app / your-feature </li>
<li> ऐप / डैश-मुख्य / डैश-मेन.html में एक नया ग्राम-छोटा-कार्ड या ग्राम-बड़े-कार्ड तत्व डालें। </li>
<li> कार्ड तत्व के आइकन, आइकनकोलर, शीर्षक, आदि को संशोधित करें। </li>
<li> यदि आपको अपने नियंत्रक में वर्तमान में चयनित स्थान और एजेंसी के नाम की आवश्यकता है: 
<ul>
<li> स्थान और एजेंसी इनपुट विशेषताओं को अपने सुविधा तत्व में जोड़ें </li>
<li> अपने नियंत्रक में स्थान और एजेंसी @Input गुण जोड़ें। </li>
</ul></li>
</ul>
<p> (डैश-main.html में अन्य नमूने देखें) </p>
<h2> कार्ड को फिर से व्यवस्थित करें </h2><ol>
<li> फ़ाइल खोलें: FrontEnd / ClientApp / src / app / dash-main / dash-main.html। </li>
<li> इस फ़ाइल में gm-small-card या gm-big-card तत्वों की स्थिति को बदलकर कार्ड की स्थिति बदलें। </li></ol><h1> लॉगिंग </h1>
<p> WebApp और WorkflowApp के लिए लॉग फ़ाइलें समाधान की जड़ में फ़ोल्डर "लॉग" में हैं। </p>

<ul>
<li> "nlog-all- (दिनांक) .log" में सिस्टम सहित सभी लॉग संदेश शामिल हैं। </li>
<li> फ़ाइल "nlog-own- (दिनांक) .log" में केवल एप्लिकेशन संदेश शामिल हैं। </li>
</ul>
<p> ClientApp में घटक फ़ाइलों में से कई के शीर्ष पर, एक कास्ट "NoLog" परिभाषित किया गया है। केवल उस घटक के लिए कंसोल लॉगिंग चालू करने के लिए उसके मान को सही से असत्य में बदलें। </p>
<h1> लिपियों का निर्माण </h1>
<p> पॉवर्सशेल बिल्ड स्क्रिप्ट यूटिलिटीज / Pscricripts में पाई जा सकती है </p>

<ul>
<li> BuildPublishAndDeploy.ps1-रिलीज़ रिलीज़ करने और उसे परिनियोजित करने के लिए अन्य स्क्रिप्ट्स पर क्लिक करें। </li>
<li> बिल्ड-ClientApp.ps1 - ClientApp का उत्पादन संस्करण बनाएँ </li>
<li> प्रकाशित करें- WebApp.ps1 - WebApp के "प्रकाशित" फ़ोल्डर का निर्माण करें </li>
<li> Copy-ClientAssets.ps1 - WebApp wwwroot फ़ोल्डर में ClientApp संपत्ति कॉपी करें </li>
<li> Deploy-PublishFolder.ps1 - किसी दूरस्थ होस्ट के लिए प्रकाशित फ़ोल्डर परिनियोजित करें </li>
<li> दस्तावेज़ फ़ाइलों से Gethub के लिए README.md फ़ाइल बनाएँ </li>
</ul>
<p> Deploy-PublishFolder.ps1 एफ़टीपी का उपयोग करके सॉफ्टवेयर को govmeeting.org पर भेजता है। एफ़टीपी लॉगिन जानकारी फ़ाइल appsettings.Development.json में SECRETS फ़ोल्डर में है। इसमें FTP और विकास में उपयोग के लिए अन्य रहस्य हैं। एफ़टीपी द्वारा उपयोग की जाने वाली इस फ़ाइल का अनुभाग नीचे दिया गया है: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
