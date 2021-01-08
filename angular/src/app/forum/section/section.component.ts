import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Forum } from 'src/app/_models/Forum';
import { TopicMain } from 'src/app/_models/TopicMain';

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

  constructor() { }

  ngOnInit() {   
  }

}
