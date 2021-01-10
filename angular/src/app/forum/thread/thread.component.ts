import { ViewChild } from '@angular/core';
import { AfterContentInit, AfterViewChecked, AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { NewPost } from 'src/app/_models/NewPost';
import { Post } from 'src/app/_models/Post';
import { Topic } from 'src/app/_models/Topic';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';
import { EditorComponent } from '../editor/editor.component';

@Component({
  selector: 'app-thread',
  templateUrl: './thread.component.html',
  styleUrls: ['./thread.component.scss']
})
export class ThreadComponent implements OnInit, AfterViewInit {
  @ViewChild('editor', {static: true}) editorComponent: EditorComponent; 

  topic: Topic;
  user: User;

  constructor(private userService: AuthService,
    private forumService: ForumService,
     private route: ActivatedRoute) {
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
   }
  ngAfterViewInit(): void {
    this.route.fragment.subscribe(f => {
      const element = document.querySelector("#" + f);
      if(element) {
        const yOffset = -1; 
        let y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;
        if (f === 'editor')
           y = element.getBoundingClientRect().bottom + window.pageYOffset;

        window.scrollTo({top: y, behavior: 'smooth'});
        element.classList.add('highlight')
        setTimeout( () => { element.classList.remove('highlight')}, 2000);
 
      }     
    });
    }
   
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.topic = data.topic;
    });
    
  }

  onSubmit() {
    let newPostId = 0;
    let newPost: NewPost = {
      authorId: this.user.userId,
      content: this.editorComponent.content,
      topicId: this.topic.id
    };

    this.forumService.addPost(newPost).subscribe((postId: number) => {
      newPostId = postId;
      let post: Post = {
        authorName: this.user.name,
        authorPhoto: this.user.photoUrl,
        created: new Date(),
        likes: [],
        authorId: newPost.authorId,
        content: newPost.content,
        topicId: newPost.topicId,
        id: postId      
      }

      this.topic.posts.push(post);
      this.editorComponent.onClear();
    })
    
  }
}
