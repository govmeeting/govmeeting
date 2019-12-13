// export interface NavItem {
//   displayName: string;
//   disabled?: boolean;
//   iconName: string;
//   route?: string;
//   children?: NavItem[];
// }

export class NavItem {
  displayName: string;
  disabled?: boolean;
  iconName: string;
  route?: string;
  children?: NavItem[];

  constructor(displayName, iconName, childrenOrRoute?: NavItem[] | string) {
    this.displayName = displayName;
    this.iconName = iconName;
    if (childrenOrRoute != undefined) {
    if (typeof childrenOrRoute === "string") {
      this.route = childrenOrRoute;
    } else {
      this.children = childrenOrRoute;
    }
  }
}
}

