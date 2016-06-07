import {Directive, ElementRef, Input, Output, EventEmitter} from '@angular/core';
import {HostListener} from '@angular/core';

@Directive({
    selector:'[myhighlight]'
//    host: {
//        '(mouseenter)':'onMouseEnter()',
//        '(mouseleave)':'onMouseLeave()'
//    }
})

export class MyHighlightDirective {

    //@Input('myHighlight') highlightColor: string;
    @Input() highlightColor: string;
    
    @Output() textSelected: EventEmitter<string>;

    private _el:HTMLElement;
    private _defaultColor = 'yellow';
    fullText: string;
    selection: Selection;
    selectedText: string;

    constructor(el: ElementRef) {
        this.textSelected = new EventEmitter<string>();
        this._el = el.nativeElement;
    }

    @HostListener('mouseenter')
    onMouseEnter() {
        //console.log('onMouseEnter');
        this._highlight(this.highlightColor || this._defaultColor);
    }
    
//        onMouseEnter() {
//        this._highlight(this.highlightColor || this._defaultColor);
//    }

    @HostListener('mouseleave')
    onMouseLeave() {
        //console.log('onMouseLeave');
        this._highlight('transparent');
    }

    @HostListener('mouseup')
    onMouseUp() {
        console.log(window.getSelection());
        
        this.selection = window.getSelection();
        
        if ((this.selection.anchorNode == null) || 
        (!this.selection.anchorNode.textContent)) {
            return;
        }
        
        this.fullText = this.selection.anchorNode.textContent;
        console.log("FULL TEXT: " + this.fullText);           
        
        this.selectedText = this.fullText.substring(this.selection.anchorOffset,
          this.selection.focusOffset);

        console.log("SELECTED TEXT: " + this.selectedText);
        this.textSelected.emit(this.selectedText);
    }


    private _highlight(color: string) {
        //console.log('color is ' + color);
        this._el.style.backgroundColor = color;
    }
}

//\GOVMEETING\CODE\SOURCE\Govmeeting\PublicSystem\Client\BrowserApp\src\client\app\shared\myhighlight\myhighlight.directive.ts
//      line 5   col 5  Use @HostBindings and @HostListeners instead of the host property (https://goo.gl/cHMFz7)
//      line 13  col 5  In the class "MyHighlightDirective", the directive input property "highlightColor" should not be renamed.
//      Please, consider the following use "@Input() highlightColor: string"