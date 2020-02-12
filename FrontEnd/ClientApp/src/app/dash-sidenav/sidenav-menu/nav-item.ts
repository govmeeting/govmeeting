
export class NavItem {
  displayName: string;
  disabled?: boolean;
  iconName: string;
  children?: NavItem[];
  expanded: boolean;
  depth: number;
  position: number[]; // position within the tree object

  constructor(displayName, iconName, children?: NavItem[]) {
    this.displayName = displayName;
    this.iconName = iconName;
    this.expanded = false;
    //this.depth = depth;
    this.children = children;
    this.position = [];
  }
}

