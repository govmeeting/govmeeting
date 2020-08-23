import { HighlightDirective } from './myhighlight.directive';
import { ElementRef } from '@angular/core';

describe('HighlightDirective', () => {
  it('should create an instance', () => {
    const el: ElementRef = new ElementRef(null);
    const directive = new HighlightDirective(el);
    expect(directive).toBeTruthy();
  });
});
