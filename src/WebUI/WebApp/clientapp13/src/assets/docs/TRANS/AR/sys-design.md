<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<mat-card><mat-card-title class="cardtitle"> التصميم </mat-card-title>
<markdown ngPreserveWhitespaces>

<p style=";text-align:right;direction:rtl"> توضح الرسوم البيانية أدناه التفاعل بين مكونات البرامج. </p>
<ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"><p style=";text-align:right;direction:rtl"> ClientApp هو تطبيق صفحة واحدة Angular Typescript يتم تشغيله في المستعرض. يوفر واجهة المستخدم. </p>
</li><li style=";text-align:right;direction:rtl"><p style=";text-align:right;direction:rtl"> WebApp هو تطبيق <a href="https://github.com/aspnet/home">Asp.Net Core</a> C# يعمل على الخادم. يستجيب لمكالمات WebApi. </p>
</li><li style=";text-align:right;direction:rtl"><p style=";text-align:right;direction:rtl"> WorkflowApp هو تطبيق <a href="https://github.com/dotnet/core">DotNet Core</a> C# يعمل على الخادم. يفعل معالجة الدفعات للتسجيلات والنصوص. يمكن أيضًا تحويلها إلى مكتبة تعمل كجزء من عملية WebApp. </p>
</li><li style=";text-align:right;direction:rtl"><p style=";text-align:right;direction:rtl"> مكونات الخادم الأخرى هي مكتبات DotNet Core C #. يتم استخدامها من قبل كل من WebApp و WorkflowApp. </p>
</li>
</ul><hr /><h2 style=";text-align:right;direction:rtl"> تصميم النظام </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>
<p style=";text-align:right;direction:rtl"> المكونات في الرسم البياني أعلاه هي: </p>

<table style="width:100%;text-align:right;direction:rtl">
<tr><th colspan="2"> التطبيقات </th></tr>
<tr><td> ClientApp </td><td> Angular SPA </td></tr>
<tr><td> التطبيق على شبكة الإنترنت </td><td> عملية خادم الويب Asp.Net </td></tr>
<tr><td> تطبيق Workflow </td><td> عملية التحكم في سير العمل </td></tr>
<tr><th colspan="2"> مكتبات </th></tr>
<tr><td> GetOnlineFiles </td><td> استرجاع النسخ والتسجيلات عبر الإنترنت </td></tr>
<tr><td> تسجيل العملية </td><td> استخراج ونسخ الصوت. إنشاء قطاعات العمل. </td></tr>
<tr><td> ProcessTranscript </td><td> تحويل النصوص الخام </td></tr>
<tr><td> قاعدة بيانات LoadDatabase </td><td> تعبئة قاعدة البيانات ببيانات من النسخة الكاملة </td></tr>
<tr><td> الوصول عبر الإنترنت </td><td> إجراءات لاسترداد الملفات من المواقع البعيدة </td></tr>
<tr><td> GoogleCloudAccess </td><td> إجراءات للوصول إلى خدمات Google Cloud </td></tr>
<tr><td> FileDataRepositories </td><td> تخزين بيانات ملف عمل JSON والحصول عليها </td></tr>
<tr><td> قاعدة بيانات المستودعات </td><td> تخزين بيانات النموذج والحصول عليها من قاعدة البيانات </td></tr>
<tr><td> DatabaseAccess </td><td> الوصول إلى قاعدة البيانات باستخدام Entity Framework </td></tr>
</table>
<hr /><h2 style=";text-align:right;direction:rtl"> تصميم ClientApp </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>
<p style=";text-align:right;direction:rtl"> يتم إظهار بنية ClientApp بشكل أفضل من خلال هيكل المكون الزاوي </p>

<table style="width:100%;text-align:right;direction:rtl">
<tr><th colspan="2"> مكونات التطبيق </th></tr>
<tr><td> العنوان </td><td> العنوان </td></tr>
<tr><td> Sidenav </td><td> التنقل في الشريط الجانبي </td></tr>
<tr><td> لوحة القيادة </td><td> حاوية لمكونات لوحة القيادة </td></tr>
<tr><td> توثيق </td><td> حاوية لصفحات التوثيق </td></tr>
<tr><th colspan="2"> مكونات لوحة القيادة </th></tr>
<tr><td> Fixasr </td><td> إصلاح نص التعرف التلقائي على الكلام </td></tr>
<tr><td> اضف اشارة </td><td> أضف علامات إلى النصوص </td></tr>
<tr><td> عرض </td><td> عرض النسخ المكتملة </td></tr>
<tr><td> مسائل </td><td> عرض معلومات حول القضايا </td></tr>
<tr><td> التنبيهات </td><td> عرض وتعيين معلومات حول التنبيهات </td></tr>
<tr><td> المسؤولون </td><td> عرض معلومات عن المسؤولين </td></tr>
<tr><td> (الآخرين)) </td><td> المكونات الأخرى التي سيتم تنفيذها </td></tr>
<tr><th colspan="2"> خدمات </th></tr>
<tr><td> مقابلة افتراضية </td><td> قم بتشغيل اجتماع افتراضي </td></tr>
<tr><td> دردشة </td><td> مكون محادثة المستخدم </td></tr>
</table>
<hr /><h2 style=";text-align:right;direction:rtl"> تصميم WebApp </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>
<p style=";text-align:right;direction:rtl"> كل واحدة من واجهات برمجة تطبيقات الويب صغيرة وتستدعي المستودعات لوضع أو الحصول على البيانات من قاعدة البيانات أو نظام الملفات. </p>

<table style="width:100%;text-align:right;direction:rtl">
<tr><th colspan="2"> وحدات تحكم </th></tr>
<tr><td> Fixasr </td><td> احفظ واحصل على أحدث نسخة من النص تدقيقها. </td></tr>
<tr><td> اضف اشارة </td><td> احفظ واحصل على أحدث نسخة من النص الذي تم وضع علامة عليه. </td></tr>
<tr><td> مقابلة </td><td> الحصول على آخر trnascript كاملة. </td></tr>
<tr><td> الهيئات الحكومية </td><td> حفظ والحصول على بيانات الهيئة الحكومية المسجلة. </td></tr>
<tr><td> الاجتماعات </td><td> حفظ والحصول على معلومات الاجتماع. </td></tr>
<tr><td> فيديو </td><td> احصل على فيديو للاجتماع. </td></tr>
<tr><td> الحساب </td><td> معالجة تسجيل المستخدم وتسجيل الدخول. </td></tr>
<tr><td> يدير </td><td> يمكن للمستخدمين إدارة ملفاتهم الشخصية. </td></tr>
<tr><td> مشرف </td><td> يمكن للمسؤول إدارة المستخدمين والسياسات والمطالبات </td></tr>
<tr><th colspan="2"> خدمات </th></tr>
<tr><td> البريد الإلكتروني </td><td> التعامل مع تأكيد البريد الإلكتروني للتسجيل. </td></tr>
<tr><td> رسالة </td><td> التعامل مع تأكيد التسجيل عبر رسالة نصية. </td></tr>
</table>
<hr /><h2 style=";text-align:right;direction:rtl"> تصميم سير العمل </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>
<p style=";text-align:right;direction:rtl"> يتم الاحتفاظ بحالة سير العمل لاجتماع معين في سجل الاجتماع الخاص به في قاعدة البيانات. يعمل كل مكون من مكونات سير العمل بشكل مستقل. يتم استدعاء كل منهم بدوره للتحقق من العمل المتاح. سيقوم كل مكون بالاستعلام في قاعدة البيانات عن الاجتماعات التي تطابق معايير العمل المتاحة. إذا تم العثور على عمل ، فسيقومون بتنفيذه وتحديث حالة الاجتماع في قاعدة البيانات. </p>
<p style=";text-align:right;direction:rtl"> من أجل بناء نظام قوي ، يمكن أن يتعافى من الفشل ، سنحتاج إلى معالجة الخطوات في سير العمل على أنها "معاملات". تكتمل المعاملة بشكل كامل أو لا تتم على الإطلاق. إذا كانت هناك حالات فشل غير قابلة للاسترداد أثناء خطوة المعالجة ، يتم إرجاع حالة ذلك الاجتماع إلى آخر حالة صالحة. لا يقوم الكود بتنفيذ المعاملات حاليا. (قضية Gitub لمتابعة) </p>
<p style=";text-align:right;direction:rtl"> ويرد رمز الزائفة أدناه للمكونات </p>
<ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> RetreiveOnlineFiles </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> لجميع الجهات الحكومية في النظام </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> تحقق من جدول (جداول) الاجتماعات لاستردادها </li><li style=";text-align:right;direction:rtl"> استرجاع ملف التسجيل أو النص </li><li style=";text-align:right;direction:rtl"> ضع الملف في مجلد DATAFILES \ Received </li>
</ul><li style=";text-align:right;direction:rtl"> يمكن أيضًا وضع الملفات في المجلد المستلم عن طريق تحميل المستخدم. </li>
</ul><li style=";text-align:right;direction:rtl"> تم تلقي الملفات </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> بالنسبة للملفات في DATAFILES \ Received وسجل قاعدة البيانات غير موجود: </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> تحديد نوع الملف </li><li style=";text-align:right;direction:rtl"> إنشاء سجل قاعدة بيانات </li><li style=";text-align:right;direction:rtl"> تعيين الوضع = تم استلامه ، تمت الموافقة عليه = خطأ </li><li style=";text-align:right;direction:rtl"> أرسل رسالة المدير (المدراء): "Received" </li>
</ul>
</ul><li style=";text-align:right;direction:rtl"> تسجيلات </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> بالنسبة للتسجيلات التي تحتوي على sourcetype = التسجيل ، status = وردت ، تمت الموافقة = true </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> إنشاء مجلد عمل </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = النسخ ، الموافق عليها = خطأ </li><li style=";text-align:right;direction:rtl"> تسجيل التسجيلات الصوتية </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = نسخ ، وافق = خطأ </li><li style=";text-align:right;direction:rtl"> أرسل رسالة المدير (المدراء): "Transuted" </li>
</ul>
</ul><li style=";text-align:right;direction:rtl"> ProcessTranscripts </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> للنصوص مع sourcetype = transcript ، status = وردت ، تمت الموافقة = true </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> إنشاء مجلد عمل </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = معالجة ، تمت الموافقة = false </li><li style=";text-align:right;direction:rtl"> نسخة العملية </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = تمت معالجتها ، تمت الموافقة عليها = خطأ </li><li style=";text-align:right;direction:rtl"> أرسل رسالة المدير (المدراء): "تمت المعالجة" </li>
</ul>
</ul><li style=";text-align:right;direction:rtl"> تسجيل التدقيق </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> للتسجيلات بالحالة = منسوخ / موافق = صحيح </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> إنشاء مجلد عمل </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = التدقيق اللغوي ، موافق عليه = خطأ </li><li style=";text-align:right;direction:rtl"> سيتم الآن تدقيق اللغة يدويًا </li>
</ul><li style=";text-align:right;direction:rtl"> للتسجيلات مع الحالة = التدقيق اللغوي </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> تحقق مما إذا كان التدقيق اللغوي يبدو مكتملًا. لو ذلك: </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = التدقيق اللغوي ، الموافق عليها = خطأ </li><li style=";text-align:right;direction:rtl"> إرسال رسالة مدير (مديري): "تدقيق" </li>
</ul>
</ul><li style=";text-align:right;direction:rtl"> AddTagsToTranscript </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> للتسجيلات ذات الحالة = التدقيق اللغوي ، الموافق عليها = صحيح أو للنسخ بالحالة = المعالجة ، الموافق عليها = صحيح </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> إنشاء مجلد عمل </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = وضع العلامات ، الموافق عليها = خطأ </li><li style=";text-align:right;direction:rtl"> سيتم وضع العلامات اليدوي الآن </li>
</ul>
</ul><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> للنصوص ذات الحالة = وضع العلامات </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> تحقق مما إذا كان وضع العلامات مكتملًا. لو ذلك: </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = الموسومة ، الموافق عليها = خطأ </li><li style=";text-align:right;direction:rtl"> أرسل رسالة إلى مديرين: "Tagged" </li>
</ul>
</ul><li style=";text-align:right;direction:rtl"> لود ترانسكريبت </li><ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> بالنسبة للاجتماعات ذات الحالة = المميزة بعلامة ، الموافق عليها = true <ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> تعيين الحالة = تحميل ، وافق = خطأ </li><li style=";text-align:right;direction:rtl"> تحميل محتويات الاجتماع في قاعدة البيانات </li><li style=";text-align:right;direction:rtl"> تعيين الحالة = تم تحميله ، تمت الموافقة عليه = خطأ </li><li style=";text-align:right;direction:rtl"> أرسل رسالة المدير (المدراء): "Loaded" </li>
</ul>
</ul>
</ul><hr /><h2 style=";text-align:right;direction:rtl"> أسرار المستخدم </h2><p style=";text-align:right;direction:rtl"> عندما تنسخ مستودع govmeeting من Github ، تحصل على كل شيء ما عدا مجلد "SECRETS". هذا المجلد موجود خارج المستودع. يحتوي على المعلومات "السرية" التالية: </p>
<ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> ClientId و ClientSecret لخدمة التفويض الخارجي من Google. </li><li style=";text-align:right;direction:rtl"> SiteKey و Secret لخدمة Google ReCaptcha. </li><li style=";text-align:right;direction:rtl"> بيانات اعتماد Google Cloud Platform. </li><li style=";text-align:right;direction:rtl"> سلسلة اتصال قاعدة البيانات. </li><li style=";text-align:right;direction:rtl"> اسم المستخدم وكلمة المرور للمشرف. </li>
</ul><p style=";text-align:right;direction:rtl"> قد يحتوي مجلد SECRETS على أربعة ملفات. </p>
<ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> تطبيقات. تطوير. json </li><li style=";text-align:right;direction:rtl"> تطبيقات. إنتاج </li><li style=";text-align:right;direction:rtl"> تطبيقات </li><li style=";text-align:right;direction:rtl"> TranscribeAudio.json </li>
</ul><p style=";text-align:right;direction:rtl"> يحتوي TranscribeAudio.json على بيانات اعتماد Google Cloud Platform. قد يحتوي كل ملف من الملفات الثلاثة الأخرى على إعدادات لكل من الأسرار الأخرى. يجب أن يحتوي appettings.Production.json على جميع إعدادات الإنتاج. مهما كانت الإعدادات الموجودة في هذا الملف ، فستتجاوز الإعدادات الموجودة في Server / WebApp / app.settings.json. هذا الملف غير مدرج في المستودع. </p>
<p style=";text-align:right;direction:rtl"> إذا كنت تريد أن يتمكن جهازك المحلي من الوصول إلى خدمات Google ، فأنت بحاجة إلى إنشاء مجلد محلي "../SECRETS فيما يتعلق بمكان وجود المستودع. بعد ذلك ، على سبيل المثال ، يمكنك إضافة ملف" appsettings.Development. json "إليه ، والذي يحتوي على المفاتيح التي تحصل عليها من Google. راجع: <a href="home#google-api-keys">Google API Keys</a> </p>
<hr /><h1 style=";text-align:right;direction:rtl"> توثيق </h1><p style=";text-align:right;direction:rtl"> في الأصل تم الاحتفاظ بهذه الوثائق في صفحات Github Wiki. ولكن تقرر نقل الصفحات إلى المشروع الرئيسي نفسه لسببين: </p>
<ul style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> لا يمكنك إجراء طلب سحب للتغييرات على صفحات Github Wiki. هذا يجعل من الصعب على أفراد المجتمع تغيير الوثائق. </li><li style=";text-align:right;direction:rtl"> من المرجح أن تظل الوثائق متزامنة مع الرمز إذا كانت مع الرمز في نفس المستودع. يمكن أن تتضمن العلاقات العامة الفردية لتغييرات التعليمات البرمجية تغييرات الوثائق المرتبطة به. </li>
</ul><p style=";text-align:right;direction:rtl"> الوثائق مكتوبة في Markdown وموجودة في Frontend / ClientApp / src / app / asset / docs. </p>

</markdown>
<p style=";text-align:right;direction:rtl"> &lt;/mat-card&gt; </p>
