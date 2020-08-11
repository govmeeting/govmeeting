import { NavItem, EntryType } from './nav-item';

// Each menu item has: DisplayName, iconName, Depth, children array or route

const unitedStates = new NavItem(EntryType.location, 'United States', 'flag', [
  new NavItem(EntryType.agency, 'Senate', null),
  new NavItem(EntryType.agency, 'House', null),
]);

const maine = new NavItem(EntryType.location, 'State of Maine', 'star', [
  new NavItem(EntryType.agency, 'Senate', null),
  new NavItem(EntryType.agency, 'House', null),
]);

const lincolnCounty = new NavItem(EntryType.location, 'Lincoln County', 'landscape', null);

const boothbayHarbor = new NavItem(EntryType.location, 'Boothbay Harbor', 'location_city', null);

const austin = new NavItem(EntryType.location, 'Austin', 'location_city', [
  new NavItem(EntryType.agency, 'City Council', 'group'),
  new NavItem(EntryType.agency, 'Board of Education', 'school'),
  new NavItem(EntryType.agency, 'Planning Board', 'group'),
]);

const travisCounty = new NavItem(EntryType.location, 'Travis County', 'group');

const texas = new NavItem(EntryType.location, 'State of Texas', 'star', [
  new NavItem(EntryType.agency, 'Senate', 'group'),
  new NavItem(EntryType.agency, 'House', 'group'),
]);

const nonGovernment = new NavItem(null, 'Non-Government', 'group', [
  new NavItem(EntryType.location, 'Glendale HOA', 'group'),
]);

///////////////////////////////////////////////////////////////////////////////

const aboutpagesMenu = new NavItem(null, 'About', null, [
  // new NavItem(EntryType.docId, 'Purpose', 'info', 'purpose'),
  new NavItem(EntryType.link, 'Overview', 'toc', 'overview'),
  new NavItem(EntryType.docId, 'Workflow', 'trending_up', 'workflow'),
  new NavItem(EntryType.docId, 'Project Status', 'check_circle_outline', 'project-status'),
  new NavItem(null, 'Developer', 'school', [
    new NavItem(EntryType.docId, 'Setup', 'build', 'setup'),
    new NavItem(EntryType.docId, 'Design', 'bubble_chart', 'sys-design'),
    new NavItem(EntryType.docId, 'Dev Notes', 'notes', 'dev-notes'),
    new NavItem(EntryType.docId, 'Database', 'archive', 'database'),
  ]),
]);

const boothbayHarborMenu = new NavItem(null, 'Select Location', null, [
  boothbayHarbor,
  lincolnCounty,
  maine,
  unitedStates,
  nonGovernment,
]);

const austinMenu = new NavItem(null, 'Select Location', null, [
  austin,
  travisCounty,
  texas,
  unitedStates,
  nonGovernment,
]);

export let navigationItems = [
  aboutpagesMenu,
  boothbayHarborMenu,
  // austinMenu
];

///////////////////////////////////////////////////////////////////////////////

const betaAboutPages = new NavItem(null, 'About', null, [
  new NavItem(EntryType.docId, 'Overview', 'toc', 'betaOverview'),
  new NavItem(EntryType.docId, 'Documentation', 'school', 'betaDocumentation'),
]);

const betaLocationMenu = new NavItem(null, 'Select Location', null, [boothbayHarbor, lincolnCounty]);

export let betaNavigationItems = [betaAboutPages, betaLocationMenu];
