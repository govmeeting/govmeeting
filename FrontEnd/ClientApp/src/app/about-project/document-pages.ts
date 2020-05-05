 // doc filenames (less .md") and titles

  let PageIds = ["overview", "workflow", "project-status", "setup", "dev-notes", "database", "sys-design" ];
  let PageTitles = [
    ["English", "en", "Overview", "Workflow", "Project status", "Setup", "Developer notes", "Database", "Design"],
    ["German", "de", "Überblick", "Funktionaler Workflow","Projektstatus", "Setup","Dev Notes","Datenbank", "Design"],
    ["Spanish", "es", "Visión general", "Flujo funcional","Estado del proyecto","Configuración","Dev Notes","Base de datos","Diseño"],
    ["French", "fr","Aperçu", "Flux de travail", "Statut du projet", "Configuration", "Notes de développement", "Base de données", "Conception Sys"],
    //["Icelandic", "is", "Yfirlit", "Vinnuflæði", "Staða verkefnis", "Uppsetning", "Dev athugasemdir", "Gagnasafn", "Sys hönnun"],
    ["Italian", "it", "Panoramica", "Flusso di lavoro", "Stato del progetto", "Impostazione", "Note per gli sviluppatori", "Database", "Progettazione"],
    ["Finish", "fi", "Yleiskatsaus", "Työnkulku", "Projektin tila", "Asennus", "Kehittäjän muistiinpanot", "Tietokanta", "Suunnittelu"],
    ["Arabic", "ar", "نظرة عامة", "تدفق العمل", "حالة المشروع", "اقامة", "ملاحظات المطور", "قاعدة البيانات", "التصميم"],
    ["Swahili", "sw", "Maelezo ya jumla", "Utiririshaji wa kazi", "Hali ya Mradi", "Usanidi", "Maelezo ya Wasanidi programu", "Hifadhidata", "Ubunifu"],
    ["Mandarin", "zh", "总览", "工作流程", "项目状态", "设置", "开发人员说明", "数据库", "设计"],
    ["Portuguese", "pt", "Visão geral", "Fluxo de trabalho", "Status do projeto", "Configuração", "Notas do desenvolvedor", "Banco de dados", "Design"],
    ["Bengali", "bn", "সংক্ষিপ্ত বিবরণ", "কর্মপ্রবাহ", "প্রকল্পের স্থিতি", "সেটআপ", "বিকাশকারী নোট", "ডাটাবেস", "নকশা"],
    ["Hindi", "hi", "अवलोकन", "वर्कफ़्लो", "प्रोजेक्ट स्थिति", "सेटअप", "डेवलपर नोट्स", "डेटाबेस", "डिज़ाइन"]
  ]

  export function GetPageTitle(pageid: string, language: string) : string {
    let i = PageIds.findIndex(x => x == pageid);
    let j = PageTitles.findIndex(y => y[1] == language);
    return PageTitles[j][i+2];
  }

