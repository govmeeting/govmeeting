/*  NavItem is a navigation item in the sidebar menu.
  Each NavItem can be either:
    1. a route to go to, or
    2. an array of NavItems that expands, when the user click on it.
  There are two kind of "routes"
    1. a documentation page - those in the top half of the menu, under "About".
    2. a government entity - those in the bottom half, under "Select Location"
 */

export enum EntryType {
  location,
  agency,
  link,
  docId,
  parent,
  unknown
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
    this.route = '';
    this.depth = 0;
    if (childrenOrRoute !== undefined) {
      if (typeof childrenOrRoute === 'string') {
        this.route = childrenOrRoute;
      } else {
        this.children = childrenOrRoute;
      }
    }
    this.position = [];
  }

  nullItem() : NavItem {
    return new NavItem(EntryType.unknown, '','','');
  }
}
