import {Directive, ElementRef, Input} from 'angular2/core';

@Directive({
    selector:'[myhighlight]',
    host: {
        '(mouseenter)':'onMouseEnter()',
        '(mouseleave)':'onMouseLeave()'
    }
})

export class MyHighlightDirective {
    
    private _el:HTMLElement;
    private _defaultColor = 'yellow';
    
    @Input('myHighlight') highlightColor: string;
    
    constructor(el: ElementRef) {
        this._el = el.nativeElement;
    }
    
    onMouseEnter() {
        this._highlight(this.highlightColor || this._defaultColor);
    }

    onMouseLeave() {
        this._highlight(null);   
    }
     
    private _highlight(color: string) {
        this._el.style.backgroundColor = color;
    }
}