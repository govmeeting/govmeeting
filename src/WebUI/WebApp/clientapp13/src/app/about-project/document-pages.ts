// doc filenames (less .md") and titles

const PageIds = ['overview', 'workflow', 'project-status', 'setup', 'dev-notes', 'database', 'sys-design'];
const PageTitles = [
  ['English', 'en', 'Overview', 'Workflow', 'Project status', 'Setup', 'Developer notes', 'Database', 'Design'],
  ['German', 'de', 'Überblick', 'Funktionaler Workflow', 'Projektstatus', 'Setup', 'Dev Notes', 'Datenbank', 'Design'],
  [
    'Spanish',
    'es',
    'Visión general',
    'Flujo funcional',
    'Estado del proyecto',
    'Configuración',
    'Dev Notes',
    'Base de datos',
    'Diseño',
  ],
  [
    'French',
    'fr',
    'Aperçu',
    'Flux de travail',
    'Statut du projet',
    'Configuration',
    'Notes de développement',
    'Base de données',
    'Conception Sys',
  ],
  [
    'Italian',
    'it',
    'Panoramica',
    'Flusso di lavoro',
    'Stato del progetto',
    'Impostazione',
    'Note per gli sviluppatori',
    'Database',
    'Progettazione',
  ],
  [
    'Finish',
    'fi',
    'Yleiskatsaus',
    'Työnkulku',
    'Projektin tila',
    'Asennus',
    'Kehittäjän muistiinpanot',
    'Tietokanta',
    'Suunnittelu',
  ],
  ['Arabic', 'ar', 'نظرة عامة', 'تدفق العمل', 'حالة المشروع', 'اقامة', 'ملاحظات المطور', 'قاعدة البيانات', 'التصميم'],
  [
    'Swahili',
    'sw',
    'Maelezo ya jumla',
    'Utiririshaji wa kazi',
    'Hali ya Mradi',
    'Usanidi',
    'Maelezo ya Wasanidi programu',
    'Hifadhidata',
    'Ubunifu',
  ],
  ['Mandarin', 'zh', '总览', '工作流程', '项目状态', '设置', '开发人员说明', '数据库', '设计'],
  [
    'Portuguese',
    'pt',
    'Visão geral',
    'Fluxo de trabalho',
    'Status do projeto',
    'Configuração',
    'Notas do desenvolvedor',
    'Banco de dados',
    'Design',
  ],
  ['Bengali', 'bn', 'সংক্ষিপ্ত বিবরণ', 'কর্মপ্রবাহ', 'প্রকল্পের স্থিতি', 'সেটআপ', 'বিকাশকারী নোট', 'ডাটাবেস', 'নকশা'],
  ['Hindi', 'hi', 'अवलोकन', 'वर्कफ़्लो', 'प्रोजेक्ट स्थिति', 'सेटअप', 'डेवलपर नोट्स', 'डेटाबेस', 'डिज़ाइन'],
  [
    'Greek',
    'el',
    'επισκόπηση',
    'ροή εργασίας',
    'κατάσταση έργου',
    'ρύθμιση',
    'dev-Notes',
    'βάση δεδομένων',
    'sys-design',
  ],
  [
    'Japanese',
    'ja',
    '概要',
    'ワークフロー',
    'プロジェクトステータス',
    'セットアップ',
    '開発ノート',
    'データベース、シス',
    'テム設計',
  ],
  ['Korean', 'ko', '개요', '워크 플로우', '프로젝트 상태', '설정', '개발자 노트', '데이터베이스', '시스템 디자인'],
  [
    'Vietnamese',
    'vi',
    'Tổng quan',
    'quy trình làm việc',
    'trạng thái dự án',
    'thiết lập',
    'ghi chú của nhà phát triển',
    'cơ sở dữ liệu',
    'thiết kế hệ thống',
  ],
  [
    'Polish',
    'pl',
    'Przegląd',
    'Przepływ pracy',
    'Status projektu',
    'Konfiguracja',
    'Notki programisty',
    'Baza danych',
    'Projekt',
  ],
  [
    'Icelandic',
    'is',
    'Yfirlit',
    'Verkflæði',
    'Staða verkefnis',
    'Skipulag',
    'Athugasemdir þróunaraðila',
    'Gagnasafn',
    'Hönnun',
  ],
  [
    'Serbian',
    'sr',
    'Преглед',
    'Радни ток',
    'Статус пројекта',
    'Постављање',
    'Напомене за програмере',
    'База података',
    'Дизајн',
  ],
  ['Hebrew', 'iw', 'סקירה כללית', 'זרימת עבודה', 'סטטוס פרויקט', 'הגדרה', 'הערות מפתחים', 'מסד נתונים', 'עיצוב'],
  [
    'Hungarian',
    'hu',
    'Áttekintés',
    'Munkafolyamat',
    'Projekt állapota',
    'Beállítás',
    'Fejlesztői megjegyzések',
    'Adatbázis',
    'Tervezés',
  ], // ADD_HERE - do not remove this comment
];

const betaPageIds = ['betaOverview', 'betaDocumentation'];
const betaPageTitles = [['English', 'en', 'Overview', 'Documentation']];

export function GetPageTitle(pageid: string, language: string, isBeta: boolean): string {
  if (isBeta) {
    return GetBetaPageTitles(pageid, language);
  }
  const i = PageIds.findIndex((x) => x === pageid);
  const j = PageTitles.findIndex((y) => y[1] === language);
  return PageTitles[j][i + 2];
}

function GetBetaPageTitles(pageid: string, language: string) {
  const i = betaPageIds.findIndex((x) => x === pageid);
  const j = betaPageTitles.findIndex((y) => y[1] === language);
  return betaPageTitles[j][i + 2];
}
