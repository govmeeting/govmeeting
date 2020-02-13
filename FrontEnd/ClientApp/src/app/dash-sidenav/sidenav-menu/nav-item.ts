export enum EntryType{
  location,
  agency,
  link
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

  constructor(type: EntryType, displayName: string, iconName: string, children?: NavItem[]) {
    this.entryType = type;
    this.displayName = displayName;
    this.iconName = iconName;
    this.expanded = false;
    //this.depth = depth;
    this.children = children;
    this.position = [];
  }
}

