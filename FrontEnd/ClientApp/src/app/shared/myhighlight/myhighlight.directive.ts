import { Directive, ElementRef, Input, Output, EventEmitter } from '@angular/core';
import { HostListener } from '@angular/core';

/*    MyhighlightDirective
 *      Add the "myhighlight" attribute to an element.
 *      When the mouse pointer enters this element, its text will be highlighted.
 *      When the mouse pointer leaves, the highlight is removed
 *      The default highlight color is yellow. This can be changed by setting the "highlightColor" attribute.
 *      If text within the element is selected, the "textSelected" event is emitted.
 *      This event can be handled within the element. For example:
 *          <div myhighlight (textSelected)="handleTextSelected($event)"> This is some text. </div>
 *      The "handleTextSelected(text: string)" method would be defined on the controller.
 *      The default value of the event will be the text that is selected.
 */


@Directive({
  selector: '[myhighlight]'
})
export class MyhighlightDirective {

    //@Input('myHighlight') highlightColor: string;
    @Input() highlightColor: string;

    @Output() textSelected: EventEmitter<string>;

    selectedText: string;
    private _el:HTMLElement;
    private _defaultColor = 'yellow';
    //private fullText: string;
    private selection: Selection;

    constructor(el: ElementRef) {
      // console.log('MyHighlightDirective constructor');
      this.textSelected = new EventEmitter<string>();
      this._el = el.nativeElement;
    }

    @HostListener('mouseenter')
    onMouseEnter() {
        // console.log('onMouseEnter');
        this._highlight(this.highlightColor || this._defaultColor);
    }

    @HostListener('mouseleave')
    onMouseLeave() {
        // console.log('onMouseLeave');
        this._highlight('transparent');
    }

    @HostListener('mouseup')
    onMouseUp() {
        // console.log(window.getSelection());
        this.selection = window.getSelection();

        var sel = {
            range: this.selection.getRangeAt(0),
            text: ''
        };

        this.snapToWord(sel);
/*
        if ((this.selection.anchorNode == null) ||
        (!this.selection.anchorNode.textContent)) {
            return;
        }

        this.fullText = this.selection.anchorNode.textContent;
        console.log("FULL TEXT: " + this.fullText);

        this.selectedText = this.fullText.substring(this.selection.anchorOffset,
          this.selection.focusOffset);
*/
        this.selectedText = sel.text;

        // console.log('SELECTED TEXT: ' + this.selectedText);
        this.textSelected.emit(this.selectedText);
    }


    private _highlight(color: string) {
        // console.log('color is ' + color);
        this._el.style.backgroundColor = color;
    }

    // JP: I added "selection" as an argument. The original had it as the object on which
    // snapToWord was called.
    private snapToWord(selection: any) {
        //if (isHighlighted()) {
        //  throw new Error("Can't modify range after highlighting");
        //}

        var start = selection.range.startOffset;
        var end = selection.range.endOffset;
        // console.log('start=' + start);
        // console.log('end=' + end);
        // If start = end, then they just clicked and didn't select.
        if (start === end) return;

        end = end -1; // last character selected is one less.

        var startNode = selection.range.startContainer;
        // console.log('startNode=' + startNode);

        //while (startNode.textContent.charAt(start) != ' ' && start > 0) {
        while (this.IsAlphaNum(startNode.textContent.charAt(start)) && start > 0) {
          start--;
        }
        if (start !== 0 && start !== selection.range.startOffset) {
          start++;
        }

        var endNode = selection.range.endContainer;
        //while (endNode.textContent.charAt(end) != ' ' && end < endNode.length) {
        while (this.IsAlphaNum(endNode.textContent.charAt(end)) && end < endNode.length) {
          end++;
        }

        selection.range.setStart(startNode, start);
        selection.range.setEnd(endNode, end);

        selection.text = selection.range.toString();

   }

   private IsAlphaNum(ch: string) {
       var code = ch.charCodeAt(0);
        if (!(code > 47 && code < 58) && // numeric (0-9)
            !(code > 64 && code < 91) && // upper alpha (A-Z)
            !(code > 96 && code < 123)) { // lower alpha (a-z)
        return false;
        }
        return true;
   }
}
