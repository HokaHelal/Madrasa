import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import 'quill-emoji';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss'],
})
export class EditorComponent implements OnInit {
  previewReply = '';
  editForm: FormGroup;
  @Output() Submit = new EventEmitter();

  modules = {
    toolbar: {
      container: [
        ['bold', 'italic', 'underline', 'strike'], // toggled buttons
        ['blockquote', 'code-block'],

        [{ header: 1 }, { header: 2 }], // custom button values
        [{ list: 'ordered' }, { list: 'bullet' }],
        [{ script: 'sub' }, { script: 'super' }], // superscript/subscript
        [{ indent: '-1' }, { indent: '+1' }], // outdent/indent
        [{ direction: 'rtl' }], // text direction

        [{ size: ['small', false, 'large', 'huge'] }], // custom dropdown
        [{ header: [1, 2, 3, 4, 5, 6, false] }],

        [{ color: [] }, { background: [] }], // dropdown with defaults from theme
        [{ font: [] }],
        [{ align: [] }],

        ['clean'], // remove formatting button

        ['link', 'image', 'video'], // link and image, video
        ['emoji'],
      ],
       handlers: { emoji: function () {} },
      
    },
    'emoji-toolbar': true,
    'emoji-textarea': true,
    'emoji-shortname': true,
  };

  constructor() {}

  ngOnInit() {
    this.editForm = new FormGroup({
      editor: new FormControl('', [Validators.required]),
    });
  }

  onPreview() {
    this.previewReply = this.editForm.get('editor').value;
  }

  onClear() {
    this.editForm.get('editor').setValue('');
    this.previewReply = '';
  }

  onSubmit() {
    const editorValue = this.editForm.get('editor').value;
    this.Submit.emit(editorValue);
    this.onClear();
  }
}
