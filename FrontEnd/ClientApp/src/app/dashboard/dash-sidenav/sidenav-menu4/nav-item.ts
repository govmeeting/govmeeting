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

  constructor(displayName, iconName, children?: NavItem[]) {
    this.displayName = displayName;
    this.iconName = iconName;
    if (children != undefined) {
      this.children = children;
    } else {
      this.children = new Array();
    }
    this.route = 'what-up-web';
  }
}

