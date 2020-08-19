export enum GovEntityType {
  Country,
  State, // or province, canton
  County, // or council, parish
  City, // or town, boro
  HOA, // Home Owners Association
}

export class GovBody {
  id: number;
  name: string;
  parent: number;
}

export class GovEntity {
  entityId: number;
  name: string;
  govEntityType: GovEntityType;
  menuIcon: string;
  govBodies: GovBody[];
  parentEntityId: number;
}
