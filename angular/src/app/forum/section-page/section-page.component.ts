import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Section } from 'src/app/_models/Section';
import { TopicMain } from 'src/app/_models/TopicMain';

@Component({
  selector: 'app-section-page',
  templateUrl: './section-page.component.html',
  styleUrls: ['./section-page.component.scss']
})
export class SectionPageComponent implements OnInit {

  pinnedThreads: TopicMain[];
  unpinnedThreads: TopicMain[];
  sectionName: string;
  isEmpty = false;
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      let section = data.section as Section;
      this.sectionName = section.name;
      this.pinnedThreads = section.topics.filter(x => x.isPinned);
      this.unpinnedThreads = section.topics.filter(x => !x.isPinned);
      
      if(section.topics?.length == 0) this.isEmpty = true;
    });
  }

  openNewThreadModal() {
    
  }
}
