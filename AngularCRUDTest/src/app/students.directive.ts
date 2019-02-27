import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appStudents]'
})
export class StudentsDirective {

  constructor(el: ElementRef) {
    el.nativeElement.style.color = 'blue';
  }

}
