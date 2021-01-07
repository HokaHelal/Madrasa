import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { NewPost } from 'src/app/_models/NewPost';
import { Post } from 'src/app/_models/Post';
import { Topic } from 'src/app/_models/Topic';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { LikeModalComponent } from '../like-modal/like-modal.component';
import { NewLike } from 'src/app/_models/newLike';
import { Like } from 'src/app/_models/Like';

@Component({
  selector: 'app-topic-detail',
  templateUrl: './topic-detail.component.html',
  styleUrls: ['./topic-detail.component.scss']
})
export class TopicDetailComponent implements OnInit {
  topic: Topic;
  user: User;
  isLiked: boolean;
  previewReply = '';
  editorContent = '';
  editForm: FormGroup;
  editorStyle = {
    height: '300px',
    backgorundColor: '#ffffff'
  }

  modules = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
      ['blockquote', 'code-block'],
  
      [{ 'header': 1 }, { 'header': 2 }],               // custom button values
      [{ 'list': 'ordered'}, { 'list': 'bullet' }],
      [{ 'script': 'sub'}, { 'script': 'super' }],      // superscript/subscript
      [{ 'indent': '-1'}, { 'indent': '+1' }],          // outdent/indent
      [{ 'direction': 'rtl' }],                         // text direction
  
      [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
      [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
  
      [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
      [{ 'font': [] }],
      [{ 'align': [] }],
  
      ['clean'],                                         // remove formatting button
  
      ['link', 'image', 'video']                         // link and image, video
    ]
  };
  bsModalRef: BsModalRef;

  constructor(private userService: AuthService,
    private forumService: ForumService,
    private modalService: BsModalService,
     private route: ActivatedRoute) {
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
   }
   
   onChange(event){
     console.log(event);
   }
  ngOnInit() {
    this.editForm = new FormGroup({
      editor: new FormControl('')
   });
    this.route.data.subscribe(data => {
      this.topic = data.topic;
      let usrlike = this.topic.likes.find(x => x.id == this.user.userId);
      if(usrlike) this.isLiked = true;
      else this.isLiked = false;
    });
  }

  onSubmit() {
    const reply = this.editForm.get('editor').value;
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

      this.editForm.get('editor').setValue('');
      this.previewReply = '';
    })
  }

  onPreview() {
    this.previewReply = this.editForm.get('editor').value;
  }

  openModal() {
    let topicLikes = this.topic.likes;
    const config = {
      class: 'modal-dialog-centered',
      initialState: { topicLikes }
    };
    this.bsModalRef = this.modalService.show(LikeModalComponent, config);    
  }

toggleLike() {
   let newLike: NewLike = {
     isTopic: true,
     threadId: this.topic.id,
     userId: this.user.userId
   }
   this.forumService.ToggleLike(newLike).subscribe((isLiked) => {
     const like: Like = {
       id: this.user.userId,
       name: this.user.name,
       photoUrl: this.user.photoUrl
     }
     
     this.isLiked = isLiked;

     if(isLiked) 
       this.topic.likes.push(like);
    else
        this.topic.likes = this.topic.likes.filter(obj => obj.id !== like.id);
   })
}
}

