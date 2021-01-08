import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { Forum } from 'src/app/_models/Forum';
import { TopicMain } from 'src/app/_models/TopicMain';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';

@Component({
  selector: 'app-forum-main',
  templateUrl: './forum-main.component.html',
  styleUrls: ['./forum-main.component.scss']
})
export class ForumMainComponent implements OnInit {

  user: User;
  forumSections: Forum[];
  latestTopics: TopicMain[];
  constructor(private accountService: AuthService, private route: ActivatedRoute) { 
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.forumSections = data.forumData;
      this.latestTopics = data.latestTopics;
    });
  }
}
