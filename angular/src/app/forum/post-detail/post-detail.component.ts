import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { take } from 'rxjs/operators';
import { Like } from 'src/app/_models/Like';
import { NewLike } from 'src/app/_models/newLike';
import { Post } from 'src/app/_models/Post';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';
import { LikeModalComponent } from '../like-modal/like-modal.component';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {
@Input() postData: Post;

  user: User;
  isLiked: boolean;
  bsModalRef: BsModalRef;

  constructor(private userService: AuthService,
    private modalService: BsModalService,
    private forumService: ForumService
    ) {
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
   }

  ngOnInit() {
    let usrlike = this.postData.likes.find(x => x.id == this.user.userId);
    if(usrlike) this.isLiked = true;
    else this.isLiked = false;
  }

  openModal() {
    let topicLikes = this.postData.likes;
    const config = {
      class: 'modal-dialog-centered',
      initialState: { topicLikes }
    };
    this.bsModalRef = this.modalService.show(LikeModalComponent, config);    
  }

  toggleLike() {
    let newLike: NewLike = {
      isTopic: false,
      threadId: this.postData.id,
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
        this.postData.likes.push(like);
     else
         this.postData.likes = this.postData.likes.filter(obj => obj.id !== like.id);
    })
 }
}
