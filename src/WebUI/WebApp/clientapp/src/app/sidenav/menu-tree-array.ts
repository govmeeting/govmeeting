import { NavItem } from './nav-item';

const NoLog = true; // set to false for console logging

export class MenuTreeArray {
  private ClassName: string = this.constructor.name + ': ';
  positions: number[];

  // constructor(_navigationItems: NavItem[]) {
  constructor() {
    this.positions = [];
  }

  // Since a NavItem can have an array of child NavItems, it is a tree object.
  // The sidenav menu consists of an array of NavItems, each possibly with their array of child NavItems.
  // The 'position' property of a NavItem is its position within this array of trees.
  // 'position' is an array of numbers. (All counts start with 0.). Examples:
  //  [0]       = 1st item in the sidenav array ("About")
  //  [1,2]     = 2nd item's 3rd child. (Select Location --> State of Maine"
  //  [1,3,1]   = 1st item's 4th child's 2nd child. (Select Location --> United States --> House)
  //
  // When a user selects an item in the menu, we send a message containing its position.
  // From it's positon, others can  obtain everything they need to know.
  // Sending only the NavItem itself is not sufficient.
  //
  // We store the depth as a seperate value to simpify styling.

  // Assign the position values
  public assignPositions(items: NavItem[]) {
    // let items: NavItem[] = _items ? _items : this.navItems;
    let pos = 0;
    // for (var item of this.navItems) {
    for (const item of items) {
      // "this.positions" is an array showing where we curently are in the tree.
      // It starts out empty. If it is not empty, we use it to initialize the current items positions array.
      if (this.positions.length > 0) {
        for (const p of this.positions) {
          item.position.push(p);
        }
      }
      // Then we add the current item's index in it's parent's children array to its positions array.
      item.position.push(pos);

      // We now know this item's depth in the tree, from the length of the position array.
      item.depth = item.position.length - 1;

      NoLog || console.log(this.ClassName + "Position of '" + item.displayName + "' = " + item.position.toString());

      if (item.children) {
        // If this item has children, we push its location onto this.positions and process the children
        this.positions.push(pos);
        this.assignPositions(item.children);
        // When finished with the children, we remove its location from this.positions.
        this.positions.pop();
      } else {
      }
      pos = pos + 1;
    }
  }

  public getItem(position: number[], items: NavItem[]): NavItem {
    const item: NavItem = items[position[0]];
    // On last postion entry, this is the item
    if (position.length === 1) {
      return item;
    }
    if (!item.children) {
      // TOTO - write to log
      console.log(this.ClassName + 'ERROR Invalid call to getItem');
    }
    const newPosition: number[] = position.slice(1);
    return this.getItem(newPosition, item.children);
  }

  public getParent(item: NavItem, items: NavItem[]): NavItem {
    const position = item.position.slice(0, item.position.length - 1);
    return this.getItem(position, items);
  }
}
