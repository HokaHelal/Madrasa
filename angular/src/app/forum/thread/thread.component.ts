import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { NewPost } from 'src/app/_models/NewPost';
import { Post } from 'src/app/_models/Post';
import { Topic } from 'src/app/_models/Topic';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';

@Component({
  selector: 'app-thread',
  templateUrl: './thread.component.html',
  styleUrls: ['./thread.component.scss']
})
export class ThreadComponent implements OnInit {
  topic: Topic;
  user: User;
  
  constructor(private userService: AuthService,
    private forumService: ForumService,
     private route: ActivatedRoute) {
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
   }
   
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.topic = data.topic;
    });
  }

  onSubmit(reply: string) {
    let newPost: NewPost = {
      authorId: this.user.userId,
      content: reply,
      topicId: this.topic.id
    };

    this.forumService.addPost(newPost).subscribe((postId: number) => {
      let post: Post = {
        authorName: this.user.name,
        authorPhoto: this.user.photoUrl,
        created: new Date(),
        likes: [],
        authorId: newPost.authorId,
        content: reply,
        topicId: newPost.topicId,
        id: postId      
      }

      this.topic.posts.push(post);
    })
  }
}
