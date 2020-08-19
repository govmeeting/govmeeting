import { GovEntity, GovEntityType } from '../goventity-view';

export let govEntities: GovEntity[] = [
  {
    entityId: 1,
    name: 'Boothbay Harbor',
    govEntityType: GovEntityType.City,
    menuIcon: 'location_city',
    govBodies: null,
    parentEntityId: 2,
  },
  {
    entityId: 2,
    name: 'Lincoln County',
    govEntityType: GovEntityType.County,
    menuIcon: 'landscape',
    govBodies: null,
    parentEntityId: 3,
  },
  {
    entityId: 3,
    name: 'Maine',
    govEntityType: GovEntityType.State,
    menuIcon: 'star',
    govBodies: [
      { id: 1, name: 'Senate', parent: 3 },
      { id: 2, name: 'House', parent: 3 },
    ],
    parentEntityId: 4,
  },
  {
    entityId: 4,
    name: 'United States',
    govEntityType: GovEntityType.Country,
    menuIcon: 'flag',
    govBodies: [
      { id: 3, name: 'Senate', parent: 4 },
      { id: 4, name: 'House', parent: 4 },
    ],
    parentEntityId: 0,
  },
  {
    entityId: 5,
    name: 'Glendale HOA',
    govEntityType: GovEntityType.HOA,
    menuIcon: 'group',
    govBodies: null,
    parentEntityId: 0,
  },
];
