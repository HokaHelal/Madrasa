import { Component, Input, OnInit } from '@angular/core';
import { TopicMain } from 'src/app/_models/TopicMain';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.scss']
})
export class TopicComponent implements OnInit {
  @Input() topicsData : TopicMain[];
  constructor() { }

  ngOnInit() {
  }
  stop(event: Event) {
    event.stopPropagation();
  }
}
