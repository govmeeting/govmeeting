import { Component, OnInit } from '@angular/core';

class Section {
  constructor(
    public id: number,
    public name: string) {}
}


@Component({
  selector: 'gm-workarea',
  templateUrl: './workarea.component.html',
  styleUrls: ['./workarea.component.scss']
})
export class WorkareaComponent implements OnInit {

  sections = [
    new Section(1, 'Invocation'),
    new Section(2, 'Approval of Journal'),
    new Section(3, 'Leaves of Absense'),
    new Section(4, 'Presentations'),
    new Section(5, 'Communications'),
    new Section(6, 'Introductions of Bills'),
    new Section(7, 'Reports'),
    new Section(8, 'Bills on Second Reading'),
    new Section(9, 'Public Comment'),
    new Section(10, 'Second Reading'),
    new Section(11, 'Invocation'),
    new Section(12, 'Approval of Journal'),
    new Section(13, 'Leaves of Absense'),
    new Section(14, 'Presentations'),
    new Section(15, 'Communications'),
    new Section(16, 'Introductions of Bills'),
    new Section(17, 'Reports'),
    new Section(18, 'Bills on Second Reading'),
    new Section(19, 'Public Comment'),
    new Section(20, 'Second Reading'),
    new Section(21, 'Invocation'),
    new Section(22, 'Approval of Journal'),
    new Section(23, 'Leaves of Absense'),
    new Section(24, 'Presentations'),
    new Section(25, 'Communications'),
    new Section(26, 'Introductions of Bills'),
    new Section(27, 'Reports'),
    new Section(28, 'Bills on Second Reading'),
    new Section(29, 'Public Comment'),
    new Section(30, 'Second Reading'),
    new Section(31, 'Invocation'),
    new Section(32, 'Approval of Journal'),
    new Section(33, 'Leaves of Absense'),
    new Section(34, 'Presentations'),
    new Section(35, 'Communications'),
    new Section(36, 'Introductions of Bills'),
    new Section(37, 'Reports'),
    new Section(38, 'Bills on Second Reading'),
    new Section(39, 'Public Comment'),
    new Section(40, 'Second Reading'),
    new Section(41, 'Invocation'),
    new Section(42, 'Approval of Journal'),
    new Section(43, 'Leaves of Absense'),
    new Section(44, 'Presentations'),
    new Section(45, 'Communications'),
    new Section(46, 'Introductions of Bills'),
    new Section(47, 'Reports'),
    new Section(48, 'Bills on Second Reading'),
    new Section(49, 'Public Comment'),
    new Section(50, 'Second Reading'),
  ]

  list: HTMLElement;
  listTop: number;
  listBot: number;
  listScrollTop: number;
  listScrollOffset: number;
  headerHeight = 0;
  pos01: number;
  pos25: number;
  pos50: number;

  constructor() { }

  ngOnInit() {
    this.list = <HTMLElement>document.getElementById('scrolltext');
    let rect = this.list.getBoundingClientRect();
    this.listTop = Math.round(rect.top);
    this.listScrollTop = Math.round(this.list.scrollTop);
    this.listScrollOffset = Math.round(this.list.offsetTop);
  }

  scroll(amount: number) {
    this.list.scrollTop = amount;
  }

  scrollMyDiv(item: Section) {
    let section = 'section' + item.id;

    window.scroll(0, 0);  // reset window to top

    // const elem: HTMLElement = document.getElementById('#' + section);
    const elem: Element = document.querySelector('#' + section);
    let elemTop: number  = Math.round(elem.getBoundingClientRect().top);

   let totalscroll = elemTop - this.listTop;
    this.list.scrollTop = elemTop - this.listTop;
    // window.scroll(0, offsetTop);

  }

  showPositions(){
    this.pos01 = this.getPosition('#section1');
    this.pos25 = this.getPosition('#section25');
    this.pos50 = this.getPosition('#section50');
    this.listTop = this.getPosition('#scrolltext');
    this.listBot = Math.round(this.list.getBoundingClientRect().bottom);
  }
  getPosition(id: string){
    const elem: Element = document.querySelector(id);
    let rect = elem.getBoundingClientRect();
    return Math.round(rect.top);
  }

}
