export enum EntryType {
  location,
  agency,
  link,
  docId,
}
export class NavItem {
  entryType: EntryType;
  displayName: string;
  disabled?: boolean;
  iconName: string;
  children?: NavItem[];
  expanded: boolean;
  depth: number;
  position: number[]; // position within the tree object
  route: string;

  constructor(type: EntryType, displayName: string, iconName: string, childrenOrRoute?: NavItem[] | string) {
    this.entryType = type;
    this.displayName = displayName;
    this.iconName = iconName;
    this.expanded = false;
    if (childrenOrRoute !== undefined) {
      if (typeof childrenOrRoute === 'string') {
        this.route = childrenOrRoute;
      } else {
        this.children = childrenOrRoute;
      }
    }
    this.position = [];
  }
}
