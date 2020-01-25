import {NavItem} from './nav-item';

// let x  = "2"
// export const numberRegexp = /^[0-9]+$/;
// export const zzz = [1,2,3,4];
// export const yyy = '222';
// const DPS: DataTable[] = [];

export const months =['Jan', 'Feb'];
// export const M_B_S_Y = 2015;



export let navigationItems = [

  new NavItem('About', null, 0,
  [
    new NavItem('Purpose', 'group', 1, 'info-city'),
    new NavItem('Overview', 'school', 1, 'info-city'),
    new NavItem('Workflow', 'school', 1, 'info-city'),
    new NavItem('Auto Processing', 'school', 1, 'info-city'),
    new NavItem('[All Pages]', 'school', 1, 'info-city')
  ]),

  new NavItem('Select Location', null, 0,
  [
    new NavItem('Boothbay Harbor', 'location_city', 1,
    [
      new NavItem('City Council', 'group', 2, 'dashboard/govinfo'),
      new NavItem('Board of Education', 'school', 2, 'dashboard/govinfo'),
      new NavItem('Planning Board', 'group', 2, 'dashboard/govinfo'),
      new NavItem('All Depts.', 'group', 2, 'dashboard/govinfo'),
    ]),
    new NavItem('Lincoln County', 'group', 1,
    [
      new NavItem('Commissioners', 'group', 2, 'dashboard/infocounty'),
      new NavItem('Transportation', 'group', 2, 'dashboard/infocounty'),
      new NavItem('Both Depts.', 'group', 2, 'dashboard/infocounty'),
    ]),
    new NavItem('State of Maine', 'star', 1,
    [
      new NavItem('Senate', 'group', 2, 'info-state'),
      new NavItem('House', 'group', 2, 'info-state'),
      new NavItem('Both chambers', 'group', 2, 'info-state')
    ]),
    new NavItem('United States', 'flag', 1,
    [
      new NavItem('Senate', 'group', 2, 'info-federal'),
      new NavItem('House', 'group', 2, 'info-federal'),
      new NavItem('Both chambers', 'group', 2, 'info-federal')
    ]),
    new NavItem('Non-Government', 'group', 1,
    [
      new NavItem('Glendale HOA', 'group', 2, 'info-HOA'),
    ])
  ])
];



//   new NavItem('Select Location', null, 0,
//   [
//     new NavItem('Austin', 'location_city', 1,
//     [
//       new NavItem('City Council', 'group', 2, 'dashboard/govinfo'),
//       new NavItem('Board of Education', 'school', 2, 'dashboard/govinfo'),
//       new NavItem('Planning Board', 'group', 2, 'dashboard/govinfo'),
//       new NavItem('All Depts.', 'group', 2, 'dashboard/govinfo'),
//     ]),
//     new NavItem('Travis County', 'group', 1,
//     [
//       new NavItem('Commissioners', 'group', 2, 'dashboard/infocounty'),
//       new NavItem('Transportation', 'group', 2, 'dashboard/infocounty'),
//       new NavItem('Both Depts.', 'group', 2, 'dashboard/infocounty'),
//     ]),
//     new NavItem('State of Texas', 'star', 1,
//     [
//       new NavItem('Senate', 'group', 2, 'info-state'),
//       new NavItem('House', 'group', 2, 'info-state'),
//       new NavItem('Both chambers', 'group', 2, 'info-state')
//     ]),
//     new NavItem('United States', 'flag', 1,
//     [
//       new NavItem('Senate', 'group', 2, 'info-federal'),
//       new NavItem('House', 'group', 2, 'info-federal'),
//       new NavItem('Both chambers', 'group', 2, 'info-federal')
//     ]),
//     new NavItem('Non-Government', 'group', 1,
//     [
//       new NavItem('Glendale HOA', 'group', 2, 'info-HOA'),
//     ])
//   ])
// ];
