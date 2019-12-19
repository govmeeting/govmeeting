import { MyhighlightDirective } from './directive';
import { ElementRef } from '@angular/core';

describe('MyhighlightDirective', () => {
  it('should create an instance', () => {
    var el: ElementRef = new ElementRef(null);
    const directive = new MyhighlightDirective(el);
    expect(directive).toBeTruthy();
  });
});
