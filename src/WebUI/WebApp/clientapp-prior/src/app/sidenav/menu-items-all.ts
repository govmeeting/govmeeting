import { NavItem, EntryType } from './nav-item';
import { MenuItemsGov, MenuItemsGovBeta } from './menu-items-gov';

const MenuItemsAbout = new NavItem(null, 'About', null, [
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

export let NavigationItems = [MenuItemsAbout, MenuItemsGov];

///////////////////////////////////////////////////////////////////////////////

const MenuItemsAboutBeta = new NavItem(null, 'About', null, [
  new NavItem(EntryType.docId, 'Overview', 'toc', 'betaOverview'),
  new NavItem(EntryType.docId, 'Documentation', 'school', 'betaDocumentation'),
]);

export let NavigationItemsBeta = [MenuItemsAboutBeta, MenuItemsGovBeta];
