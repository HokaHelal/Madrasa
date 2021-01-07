import { Component, Input, OnInit } from '@angular/core';
import { Forum } from 'src/app/_models/Forum';

@Component({
  selector: 'app-section',
  templateUrl: './section.component.html',
  styleUrls: ['./section.component.scss']
})
export class SectionComponent implements OnInit {
  @Input() isHighlighted = false;
  @Input() forumSection: Forum;

  constructor() { }

  ngOnInit() {
  }

}
