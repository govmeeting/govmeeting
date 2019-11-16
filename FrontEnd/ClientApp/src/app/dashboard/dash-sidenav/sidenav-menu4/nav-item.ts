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

  constructor(displayName, iconName) {
    this.displayName = displayName;
    this.iconName = iconName;
    this.children = [];
  }
}

