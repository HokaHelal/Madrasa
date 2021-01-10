import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { take } from 'rxjs/operators';
import { NewTopic } from 'src/app/_models/NewTopic';
import { SectionMain } from 'src/app/_models/SectionMain';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';
import { EditorComponent } from '../editor/editor.component';

@Component({
  selector: 'app-add-topic-modal',
  templateUrl: './add-topic-modal.component.html',
  styleUrls: ['./add-topic-modal.component.scss']
})
export class AddTopicModalComponent implements OnInit {
  @ViewChild('editor', {static: true}) editorComponent: EditorComponent; 

  constructor(public bsModalRef: BsModalRef,
     private userService: AuthService,
     private fb: FormBuilder,
     private router: Router,
     private forumService: ForumService) {
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
   }

  newTopicForm: FormGroup;
  sections: SectionMain[];
  @Input() selectedSection: number = 0;
  user: User;
  isPinned: boolean = false;
  title: string = '';

  ngOnInit() {
    this.initControls();
    this.newTopicForm = this.fb.group({
      title: ['', Validators.required],
      section: ['', Validators.required]
    })
  }
  initControls() {
    this.forumService.getDropDownSections(this.user.classId).subscribe((sections: SectionMain[]) => {
      this.sections = sections;
      if(sections.length > 0 && this.selectedSection == 0) {
        this.selectedSection = sections[0].id;
      }
    });
    console.log(this.editorComponent);
  }

  get isFormsValid() {
    return this.newTopicForm.valid && this.editorComponent.editorForm.valid;
  }
  
  addTopic() {      
      let newTopic: NewTopic = {
        title: this.title,
        authorId: this.user.userId,
        content: this.editorComponent.content,
        sectionId: this.selectedSection,
        isPinned: this.isPinned
      };

      this.forumService.addTopic(newTopic).subscribe((topicId : number) => {
          this.router.navigateByUrl('/app/forums/thread/' + topicId);
          this.bsModalRef.hide();
      })
  }
}
