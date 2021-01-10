import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'text',
})
export class TextPipe implements PipeTransform {
  transform(value: string): string {
    if (!value) {
      return value;
    }

    let without_html = value.replace(/<(?:.|\n)*?>/gm, ' ');

    return without_html;
  }
}
