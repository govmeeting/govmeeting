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
</style><p style=";text-align:right;direction:rtl"> تتكون الجداول في قاعدة البيانات من: </p>
<ol style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> جداول المصادقة. </li></ol><p style=";text-align:right;direction:rtl"> تم إنشاؤها تلقائيًا بواسطة خدمة هوية Microsoft عندما تم التحقق من "المصادقة = حسابات المستخدمين الفرديين" عند إنشاء المشروع لأول مرة. </p>
<ol start="2" style=";text-align:right;direction:rtl"><li style=";text-align:right;direction:rtl"> جداول Govmeeting. </li></ol><p style=";text-align:right;direction:rtl"> يتم إنشاؤها بواسطة ميزة "Code First" في Entity Framework. تقرأ EF فئات C# في مكتبة مشروع "قاعدة البيانات / النموذج" وتقوم تلقائيًا بإنشاء مخطط قاعدة البيانات والجداول. </p>
<p style=";text-align:right;direction:rtl"> راجع صفحة مستند "الإعداد" لإنشاء قاعدة البيانات والعمل معها. </p>
<h1 style=";text-align:right;direction:rtl"> مخطط </h1><h2 style=";text-align:right;direction:rtl"> جدول "الجهات الحكومية" </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th><th> مثال 3 </th></tr>
<tr><td> المفتاح الأساسي </td><td> مفتاح فريد </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> اسم </td><td> اسم الكيان </td><td> مجلس الشيوخ </td><td> المجسم </td><td> مجلس التخطيط </td></tr>
<tr><td> بلد </td><td> موقع البلد </td><td> الولايات المتحدة الأمريكية </td><td> الولايات المتحدة الأمريكية </td><td> الولايات المتحدة الأمريكية </td></tr>
<tr><td> حالة </td><td> موقع الولاية </td><td></td><td> آيوا </td><td> نيو جيرسي </td></tr>
<tr><td> مقاطعة </td><td> موقع مقاطعة أو منطقة </td><td></td><td></td><td> غلوستر </td></tr>
<tr><td> البلدية </td><td> مدينة أو بلدة </td><td></td><td></td><td> بلدة مونرو </td></tr>
</table>
<p style=";text-align:right;direction:rtl">
* المزيد من الأمثلة لجدول الجهات الحكومية </p>

<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> مثال 4 </th><th> مثال 5 </th></tr>
<tr><td> المفتاح الأساسي </td><td> 4 </td><td> 5 </td></tr>
<tr><td> اسم </td><td> فيده سبها </td><td> المجلس البلدي </td></tr>
<tr><td> بلد </td><td> الهند </td><td> الهند </td></tr>
<tr><td> حالة </td><td> ولاية اندرا براديش </td><td> ولاية اندرا براديش </td></tr>
<tr><td> مقاطعة </td><td></td><td> حي كادابا </td></tr>
<tr><td> البلدية </td><td></td><td> Rayachoty </td></tr>
</table>
<p style=";text-align:right;direction:rtl"> لاحظ أنه إذا كانت الجهة الحكومية على المستوى الوطني ، فإن مواقع الولاية والمقاطعة والبلدية لاغية. إذا كان الكيان على مستوى الولاية ، فإن مواقع مقاطعاته وبلدياته لاغية ، إلخ. </p>
<p style=";text-align:right;direction:rtl"> هناك حاجة إلى أمثلة للبلدان الأخرى. إذا كانت لديك أمثلة أخرى ، فيرجى تعديل هذا المستند وإصدار طلب السحب في Github. إذا كانت هناك أسباب لعدم نجاح هذا في بعض البلدان ، فيرجى إرسال مشكلة في Github. </p>
<hr /><h2 style=";text-align:right;direction:rtl"> "طاولة اللقاء </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th></tr>
<tr><td> المفتاح الأساسي </td><td> مفتاح فريد </td><td> 1 </td><td> 2 </td></tr>
<tr><td> الحكومة </td><td> مفتاح الكيان الحكومي </td><td> 2 (مجلس الشيوخ الأمريكي) </td><td> 4 (فيدهان سبها) </td></tr>
<tr><td> زمن </td><td> وقت الاجتماع </td><td> 3 أغسطس ، &#39;14 19:30 </td><td> 2 مايو ، 14:00 </td></tr>
<tr><td> نص </td><td> نص النسخ </td><td> "سيأتي الاجتماع على النظام ..." </td><td> "سيجتمع المجلس. ..." </td></tr>
</table>
<hr /><h2 style=";text-align:right;direction:rtl"> جدول "ممثل" </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th></tr>
<tr><td> المفتاح الأساسي </td><td> مفتاح فريد </td><td> 1 </td><td> 2 </td></tr>
<tr><td> الاسم الكامل </td><td> الاسم الكامل </td><td> النائب ستيف جونز </td><td> رئيس رافي أناند </td></tr>
<tr><td> المعرف </td><td> معرّف شخصي </td><td> (لكي تقرر </td><td> (لكي تقرر) </td></tr>
</table>
<p style=";text-align:right;direction:rtl"> يمكن أن يكون المتحدثون في الاجتماعات ممثلين للكيان الحاكم أو لعامة الناس. في كلتا الحالتين ، يمكن أن يكون هناك نفس الأشخاص الذين يحضرون الاجتماعات في أكثر من جهة حكومية واحدة. سوف نرغب في تتبع ما يقوله نفس الممثل عبر كل من الهيئات التي يكون عضوا فيها. لذلك نحن بحاجة إلى معرف فريد لكل ممثل. </p>
<p style=";text-align:right;direction:rtl"> سنحتاج إلى تحديد المعلومات المطلوبة لهذا التعريف. من الواضح أننا لن نحصل على رقم الهوية الوطنية للشخص لشيء من هذا القبيل. قد نحتاج إلى استخدام مجموعة من أكثر من حقل واحد للتعرف على شخص ما. على سبيل المثال ، العنوان والاسم. </p>
<p style=";text-align:right;direction:rtl"> سيكون هناك جدول "ممثل" يحتوي على معرف شخصي فريد لكل ممثل. </p>
<hr /><h2 style=";text-align:right;direction:rtl"> جدول "RepresentativeToEntity" </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th><th> مثال 3 </th></tr>
<tr><td> وكيل </td><td> مفتاح الممثل </td><td> 1 </td><td> 2 </td><td> 2 </td></tr>
<tr><td> الحكومة </td><td> مفتاح الكيان الحكومي </td><td> 5 </td><td> 7 </td><td> 9 </td></tr>
</table>
<p style=";text-align:right;direction:rtl"> سيكون هناك أيضًا جدول "RepresentativeToEntity" يربط الممثلين والهيئات الحكومية التي يعملون فيها. لاحظ أن الممثل نفسه يمكن أن يخدم في كيانات حكومية متعددة. </p>
<hr /><h2 style=";text-align:right;direction:rtl"> جدول "المواطن" </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th></tr>
<tr><td> المفتاح الأساسي </td><td> مفتاح فريد </td><td> 1 </td><td> 2 </td></tr>
<tr><td> اسم </td><td> اسم </td><td> جون ج. </td><td> Rai S. </td></tr>
<tr><td> لقاء </td><td> مفتاح الاجتماع </td><td> 2 (اجتماع مجلس الشيوخ الأمريكي في 3 أغسطس &#39;14) </td><td> 4 (لقاء فيدهان سبها في 2 مايو 1414) </td></tr>
</table>
<p style=";text-align:right;direction:rtl"> سيكون هناك جدول "مواطن" لأفراد الجمهور. سيحتوي جدول المواطن على مفتاح خارجي يشير إلى الاجتماع الذي تحدث فيه هذا الشخص. </p>
<p style=";text-align:right;direction:rtl"> هل يجب أن نحاول تتبع ما يقوله الجمهور عبر جميع الاجتماعات التي يحضرونها؟ ربما هذا غير مناسب. </p>
<p style=";text-align:right;direction:rtl"> إذا لم يكن الأمر كذلك ، فلا حاجة إلى تحديد هوية المتحدثين بشكل فريد. يمكن استخدام الاسم الذي يعطيه هذا الشخص عندما يتحدث في اجتماع لتحديد شخص ما لهذا الاجتماع فقط. لسنا بحاجة إلى ربط هذا الاسم عبر الاجتماعات. قد نفضل حتى تخزين الاسم الأول واسم العائلة الأخير فقط. </p>
<hr /><h2 style=";text-align:right;direction:rtl"> جدول "الموضوع" </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th><th> مثال 3 </th></tr>
<tr><td> المفتاح الأساسي </td><td> مفتاح فريد </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> الحكومة </td><td> مفتاح الكيان الحكومي </td><td> 2 (مجلس الشيوخ الأمريكي) </td><td> 2 (مجلس الشيوخ الأمريكي) </td><td> 4 (فيدهان سبها) </td></tr>
<tr><td> نوع </td><td> الفئة أو الموضوع </td><td> الفئة </td><td> موضوع </td><td> الفئة </td></tr>
<tr><td> اسم </td><td> اسم الموضوع </td><td> الصحة </td><td> Obamacare </td><td> التعليم </td></tr>
</table>
<p style=";text-align:right;direction:rtl"> سيكون لكل كيان حكومي (على سبيل المثال مجلس الشيوخ الأمريكي أو مجلس تقسيم المناطق في بلدة مونرو ، نيوجيرسي ، الولايات المتحدة الأمريكية) أسماء فريدة خاصة به للفئات والموضوعات التي تمت مناقشتها في اجتماعاتهم. لذلك ، يحتوي جدول "اسم العلامة" على مفتاح خارجي يشير إلى الكيان الحكومي. </p>
<hr /><p style=";text-align:right;direction:rtl"> النص الكامل للاجتماع هو سلسلة نصية. تحتوي جداول موقع مكبر الصوت وموقع العلامة على مؤشرات في النص ، أي نقاط البداية والنهاية التي يتغير عندها مكبر الصوت أو العلامة. ستكون هذه مؤشرات حرف في السلسلة النصية. </p>
<h2 style=";text-align:right;direction:rtl"> جدول "علامات المتحدث" </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th></tr>
<tr><td> PimaryKey </td><td> مفتاح فريد </td><td> 1 </td><td> 2 </td></tr>
<tr><td> مكبر الصوت </td><td> مفتاح اللغة </td><td> 1 (ممثل جونز) </td><td> 2 (الرئيس. أناند) </td></tr>
<tr><td> لقاء </td><td> مفتاح الاجتماع </td><td> 1 (الجلسة 1) </td><td> 2 (الاجتماع 2) </td></tr>
<tr><td> بداية </td><td> نقطة عندما يبدأ المتحدث في الحديث </td><td> 521 </td><td> 12045 </td></tr>
<tr><td> النهاية </td><td> نقطة عندما يتوقف المتحدث عن الكلام </td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2 style=";text-align:right;direction:rtl"> جدول "علامات الموضوع" </h2>
<table style=";text-align:right;direction:rtl">
<tr><th> حقل </th><th> المعنى </th><th> مثال 1 </th><th> مثال 2 </th></tr>
<tr><td> المفتاح الأساسي </td><td> مفتاح فريد </td><td> 1 </td><td> 2 </td></tr>
<tr><td> بطاقة شعار </td><td> مفتاح الوسم </td><td> 1 (طاقة) </td><td> 2 (التعليم) </td></tr>
<tr><td> لقاء </td><td> مفتاح الاجتماع </td><td> 1 (الجلسة 1) </td><td> 2 (الاجتماع 2) </td></tr>
<tr><td> بداية </td><td> نقطة عندما يبدأ الموضوع </td><td> 750 </td><td> 14500 </td></tr>
<tr><td> النهاية </td><td> النقطة عندما يتوقف الموضوع </td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2 style=";text-align:right;direction:rtl"> حجم البيانات </h2><p style=";text-align:right;direction:rtl"> حجم قاعدة بيانات الاجتماع النهائي صغير جداً. سيمكننا هذا من إنشاء تطبيقات حيث يتم تخزين معظم البيانات محليًا على كمبيوتر المستخدم أو الهاتف الذكي - للحصول على أداء عال وإمكانية تشغيل التطبيق دون اتصال. </p>
