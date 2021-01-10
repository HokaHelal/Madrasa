import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { take } from 'rxjs/operators';
import { Forum } from 'src/app/_models/Forum';
import { TopicMain } from 'src/app/_models/TopicMain';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';
import { AddTopicModalComponent } from '../add-topic-modal/add-topic-modal.component';

@Component({
  selector: 'app-forum-main',
  templateUrl: './forum-main.component.html',
  styleUrls: ['./forum-main.component.scss']
})
export class ForumMainComponent implements OnInit {

  user: User;
  forumSections: Forum[];
  latestTopics: TopicMain[];
  bsModalRef: BsModalRef;

  constructor(private accountService: AuthService, 
    private modalService: BsModalService,
    private route: ActivatedRoute) { 
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.forumSections = data.forumData;
      this.latestTopics = data.latestTopics;
    });
  }

  openModal(sectionId: number){
    const config = {
      class: 'modal-dialog-centered modal-lg',
      initialState: {
          selectedSection: sectionId
      }
    };
    this.bsModalRef = this.modalService.show(AddTopicModalComponent, config);
  }
}
