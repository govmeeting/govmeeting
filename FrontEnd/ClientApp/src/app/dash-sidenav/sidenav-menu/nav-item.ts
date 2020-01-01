
export class NavItem {
  displayName: string;
  disabled?: boolean;
  iconName: string;
  route?: string;
  children?: NavItem[];
  expanded: boolean;
  depth: number;

  constructor(displayName, iconName, depth, childrenOrRoute?: NavItem[] | string) {
    this.displayName = displayName;
    this.iconName = iconName;
    this.expanded = false;
    this.depth = depth;
    if (childrenOrRoute != undefined) {
    if (typeof childrenOrRoute === "string") {
      this.route = childrenOrRoute;
    } else {
      this.children = childrenOrRoute;
    }
  }
}
}

