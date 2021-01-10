import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Section } from 'src/app/_models/Section';
import { TopicMain } from 'src/app/_models/TopicMain';
import { AddTopicModalComponent } from '../add-topic-modal/add-topic-modal.component';

@Component({
  selector: 'app-section-page',
  templateUrl: './section-page.component.html',
  styleUrls: ['./section-page.component.scss']
})
export class SectionPageComponent implements OnInit {

  pinnedThreads: TopicMain[];
  unpinnedThreads: TopicMain[];
  sectionName: string;
  sectionId: number;
  isEmpty = false;
  bsModalRef: BsModalRef;

  constructor(private route: ActivatedRoute,
    private modalService: BsModalService,
    ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      let section = data.section as Section;
      this.sectionName = section.name;
      this.sectionId = section.id;
      this.pinnedThreads = section.topics.filter(x => x.isPinned);
      this.unpinnedThreads = section.topics.filter(x => !x.isPinned);
      
      if(section.topics?.length == 0) this.isEmpty = true;
    });
  }

  openNewThreadModal() {
    const config = {
      class: 'modal-dialog-centered modal-lg',
      initialState: {
          selectedSection: this.sectionId
      }
    };
    this.bsModalRef = this.modalService.show(AddTopicModalComponent, config);
  }
}
