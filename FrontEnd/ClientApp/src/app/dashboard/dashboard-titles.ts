let DashboardTitles: string[][] = [
  ["English", "en", "Politics", "Legislation", "Meetings", "Govmeeting News", "Proofread Transcript", "Add Tags to Transcript", "View Latest Meeting", "Issues", "Officials", "Virtual Meeting", "Chat", "Charts", "Notes", "Meeting Minutes", "Work Items", "Alerts" ],
  ["German", "de", "Politik", "Gesetzgebung", "Besprechungen", "Govmeeting News", "Korrekturlesen von Transkripten", "Tags zum Transkript hinzufügen", "Letzte Besprechung anzeigen", "Probleme", "Beamte", "Virtuelles Meeting", "Chat", "Diagramme" , "Notizen", "Sitzungsprotokolle", "Arbeitselemente", "Warnungen"],
  ["Spanish", "es", "Política", "Legislación", "reuniones", "Noticias gubernamentales", "Transcripción revisada", "Agregar etiquetas a la transcripción", "Ver la última reunión", "Problemas", "Funcionarios", "Reunión virtual", "Chat", "Gráficos" , "Notas", "Actas de reuniones", "Elementos de trabajo", "Alertas"],
  ["French", "fr", "Politique", "Législation", "Réunions", "Actualités", "Relire la transcription", "Ajouter des balises à la transcription", "Afficher la dernière réunion", "Issues", "Enjeux", "Fonctionnaires", "Réunion virtuelle", "Bavarder"," Graphiques "," Remarques"," Procès-verbaux de réunion "," Éléments de travail "," Alertes "],
  ["Icelandic", "is", "Stjórnmál", "löggjöf", "fundir", "frétt um stjórnarmyndunarviðskipti", "fullgilt afrit", "Bæta merkjum við afrit", "skoða nýjasta fundinn", "mál", "embættismenn", "Sýndarfundur", "spjall", "töflur" , "Athugasemdir", "Fundargerðir fundargerð", "Vinnuatriði", "Viðvaranir"],
  ["Italian", "it", "Politica", "Legislazione", "incontri", "Notizie importanti", "Trascrizione di bozze", "Aggiungi tag alla trascrizione", "Visualizza ultimo incontro", "Problemi", "Funzionari", "Riunione virtuale", "Chat", "Grafici" , "Note", "Verbale riunione", "Articoli di lavoro", "Avvisi"],
  ["Finish", "fi", "Politiikka", "Lainsäädäntö", "Kokoukset", "Govmeeting-uutiset", "Oikolukema kopio", "Lisää tunnisteita tekstiksi", "Näytä viimeisin kokous", "Aiheet", "Virkamiehet", "Virtuaali kokous", "Keskustelu", "Kaaviot" , "Muistiinpanot", "Kokouspöytäkirjat", "Työesineet", "Hälytykset"],
  ["Arabic", "ar", "السياسة" ,  "التشريع" ,  "الاجتماعات" ,  "أخبار الحكومة" ,  "تدقيق النصوص" ,  "إضافة علامات إلى النص" ,"اجتماع افتراضي",  "عرض آخر اجتماع" ,  "الإصدارات" ,  "المسؤولين" ,  "الدردشة" ,  "الرسوم البيانية" ,  "ملاحظات" ,  "محضر الاجتماع" ,  "عناصر العمل" ,  "التنبيهات"],
  ["Swahili", "sw", "Siasa", "Sheria", "mikutano", "Habari za Govmeeting", "Nakala ya Proofread", "Ongeza vitambulisho kwa nakala", "Angalia Mkutano wa hivi karibuni", "Masuala", "Viongozi", "Mkutano wa kweli", "Ongea", "Chati" , "Vidokezo", "Dakika za Mkutano", "Vitu vya Kazi", "Taadhari"],
  ["Mandarin", "zh", "政治", "立法", "会议", "政府新闻", "校对成绩单", "向成绩单添加标签", "查看最新会议", "问题", "官员", "虚拟会议", "聊天", "图表" , "注释", "会议记录", "工作项", "警报"],
  ["Portuguese", "pt", "Política", "Legislação", "reuniões", "Notícias do Govmeeting", "Transcrição de revisão", "Adicionar tags à transcrição", "Exibir última reunião", "Edições", "Funcionários", "Reunião virtual", "Bate-papo", "Gráficos" , "Notas", "Atas da reunião", "Itens de trabalho", "Alertas"],
  ["Bengali", "bn", "রাজনীতি", "আইন", "সভা", "সরকারী সংবাদ", "প্রুফ্রেড ট্রান্সক্রিপ্ট", "ট্রান্সক্রিপ্টে ট্যাগ যুক্ত করুন", "সর্বশেষ সভা দেখুন", "সমস্যা", "আধিকারিক", "ভার্চুয়াল সভা", "চ্যাট", "চার্ট" , "নোটস", "মিটিং মিনিট", "কাজের আইটেম", "সতর্কতা"],
  ["Hindi", "hi", "राजनीति", "विधान", "बैठकें", "गोवमीटिंग न्यूज़", "प्रूफरीड ट्रांसक्रिप्ट", "टैगिंग को ट्रांसक्रिप्ट में जोड़ें", "नवीनतम बैठक देखें", "मुद्दे", "अधिकारी", "वर्चुअल मीटिंग", "चैट", "चार्ट" , "नोट्स", "मीटिंग मिनट", "कार्य आइटम", "अलर्ट"]
]


export function GetDashboardTitle(englishTitle: string, language: string) : string {
  let i = DashboardTitles[0].findIndex(x => x == englishTitle);
  let j = DashboardTitles.findIndex(y => y[1] == language);
  return DashboardTitles[j][i];
}
