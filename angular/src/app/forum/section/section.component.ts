import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Forum } from 'src/app/_models/Forum';
import { TopicMain } from 'src/app/_models/TopicMain';
import { AddTopicModalComponent } from '../add-topic-modal/add-topic-modal.component';

@Component({
  selector: 'app-section',
  templateUrl: './section.component.html',
  styleUrls: ['./section.component.scss']
})
export class SectionComponent implements OnInit {
  @Input() class = '';
  @Input() id: number;
  @Input() title: string;
  @Input() topics: TopicMain[];
  bsModalRef: BsModalRef;

  constructor(private modalService: BsModalService) { }

  ngOnInit() {   
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
