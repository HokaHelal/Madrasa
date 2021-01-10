import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { take } from 'rxjs/operators';
import { NewTopic } from 'src/app/_models/NewTopic';
import { SectionMain } from 'src/app/_models/SectionMain';
import { TopicMain } from 'src/app/_models/TopicMain';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';

@Component({
  selector: 'app-add-topic-modal',
  templateUrl: './add-topic-modal.component.html',
  styleUrls: ['./add-topic-modal.component.scss']
})
export class AddTopicModalComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef,
     private userService: AuthService,
     private router: Router,
     private forumService: ForumService) {
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
   }

  sections: SectionMain[];
  @Input() selectedSection: number = -1;
  user: User;
  isPinned: boolean = false;
  title: string = '';

  ngOnInit() {
    this.initControls();
  }

  initControls() {
    this.forumService.getDropDownSections(this.user.classId).subscribe((sections: SectionMain[]) => {
      this.sections = sections;
      if(sections.length > 0 && this.selectedSection == -1) {
        this.selectedSection = sections[0].id;
      }
    });
  }

  addTopic(editorContent: string) {      
      let newTopic: NewTopic = {
        title: this.title,
        authorId: this.user.userId,
        content: editorContent,
        sectionId: this.selectedSection,
        isPinned: this.isPinned
      };

      console.log(newTopic);
      this.forumService.addTopic(newTopic).subscribe((topicId : number) => {
          this.router.navigateByUrl('/app/forums/thread/' + topicId);
          this.bsModalRef.hide();
      })
  }
}
