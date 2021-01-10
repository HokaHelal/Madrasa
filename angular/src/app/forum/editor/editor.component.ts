import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import 'quill-emoji';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss'],
})
export class EditorComponent implements OnInit {
  previewReply = '';
  editorForm: FormGroup;
  
  modules = {
    toolbar: {      
       handlers: { emoji: function () {} },      
    },
    'emoji-toolbar': true,
    'emoji-textarea': true,
    'emoji-shortname': true,
  };

  constructor() {
  }

  ngOnInit() {
    this.editorForm = new FormGroup({
      editor: new FormControl(''),
    });
  }

  onPreview() {
    this.previewReply = this.editorForm.get('editor').value;
  }

  onClear() {
    this.editorForm.get('editor').setValue('');
    this.previewReply = '';
  }

  get content() {
    return this.editorForm.get('editor').value;
  }
}
