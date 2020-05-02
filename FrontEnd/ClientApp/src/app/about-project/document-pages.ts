 // doc filenames (less .md") and titles

  let PageIds = ["overview", "workflow", "project-status", "setup", "dev-notes", "database", "sys-design" ];
  let PageTitles = [
    ["en", "Overview", "Workflow", "Project status", "Setup", "Developer notes", "Database", "Design"],
    ["de", "Überblick", "Funktionaler Workflow","Projektstatus", "Setup","Dev Notes","Datenbank", "Design"],
    ["es", "Visión general", "Flujo funcional","Estado del proyecto","Configuración","Dev Notes","Base de datos","Diseño"],
    ["fr","Aperçu", "Flux de travail", "Statut du projet", "Configuration", "Notes de développement", "Base de données", "Conception Sys"],
    ["is", "Yfirlit", "Vinnuflæði", "Staða verkefnis", "Uppsetning", "Dev athugasemdir", "Gagnasafn", "Sys hönnun"],
    ["ar", "نظرة عامة", "تدفق العمل", "حالة المشروع", "اقامة", "ملاحظات المطور", "قاعدة البيانات", "التصميم"],
    ["sw", "Maelezo ya jumla", "Utiririshaji wa kazi", "Hali ya Mradi", "Usanidi", "Maelezo ya Wasanidi programu", "Hifadhidata", "Ubunifu"],
    ["zh", "总览", "工作流程", "项目状态", "设置", "开发人员说明", "数据库", "设计"],
    ["pt", "Visão geral", "Fluxo de trabalho", "Status do projeto", "Configuração", "Notas do desenvolvedor", "Banco de dados", "Design"],
    ["bn", "সংক্ষিপ্ত বিবরণ", "কর্মপ্রবাহ", "প্রকল্পের স্থিতি", "সেটআপ", "বিকাশকারী নোট", "ডাটাবেস", "নকশা"],
    ["hi", "अवलोकन", "वर्कफ़्लो", "प्रोजेक्ट स्थिति", "सेटअप", "डेवलपर नोट्स", "डेटाबेस", "डिज़ाइन"]
  ]

  export function GetPageTitle(pageid: string, language: string) : string {
    let i = PageIds.findIndex(x => x == pageid);
    let j = PageTitles.findIndex(y => y[0] == language);
    return PageTitles[j][i+1];
  }

