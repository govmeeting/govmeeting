import { NavItem, EntryType } from './nav-item';

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

const nonGovernment = new NavItem(null, 'Non-Government', 'group', [
  new NavItem(EntryType.location, 'Glendale HOA', 'group'),
]);

export let MenuItemsGov = new NavItem(null, 'Select Location', null, [
  boothbayHarbor,
  lincolnCounty,
  maine,
  unitedStates,
  nonGovernment,
]);

//////////////////////////////////////////////////////////////////////////

// For beta release, we will just have city/town and county.
export let MenuItemsGovBeta = new NavItem(null, 'Select Location', null, [boothbayHarbor, lincolnCounty]);

//////////////////////  For development/testing ////////////////////

// const austin = new NavItem(EntryType.location, 'Austin', 'location_city', [
//   new NavItem(EntryType.agency, 'City Council', 'group'),
//   new NavItem(EntryType.agency, 'Board of Education', 'school'),
//   new NavItem(EntryType.agency, 'Planning Board', 'group'),
// ]);

// const travisCounty = new NavItem(EntryType.location, 'Travis County', 'group');

// const texas = new NavItem(EntryType.location, 'State of Texas', 'star', [
//   new NavItem(EntryType.agency, 'Senate', 'group'),
//   new NavItem(EntryType.agency, 'House', 'group'),
// ]);

// const austinMenu = new NavItem(null, 'Select Location', null, [
//   austin,
//   travisCounty,
//   texas,
//   unitedStates,
//   nonGovernment,
// ]);
