import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Like } from 'src/app/_models/Like';

@Component({
  selector: 'app-like-modal',
  templateUrl: './like-modal.component.html',
  styleUrls: ['./like-modal.component.scss']
})
export class LikeModalComponent implements OnInit {
  topicLikes: Like[] = [];

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

}
