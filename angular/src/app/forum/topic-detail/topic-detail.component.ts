import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { take } from 'rxjs/operators';
import { Like } from 'src/app/_models/Like';
import { NewLike } from 'src/app/_models/newLike';
import { Topic } from 'src/app/_models/Topic';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ForumService } from 'src/app/_services/forum.service';
import { LikeModalComponent } from '../like-modal/like-modal.component';


@Component({
  selector: 'app-topic-detail',
  templateUrl: './topic-detail.component.html',
  styleUrls: ['./topic-detail.component.scss']
})
export class TopicDetailComponent implements OnInit {
  @Input() topic: Topic;
  user: User;
  isLiked: boolean;
  bsModalRef: BsModalRef;
  
    constructor(private userService: AuthService,
    private forumService: ForumService,
    private modalService: BsModalService,
     private route: ActivatedRoute) {
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
   }


  ngOnInit() {
    let usrlike = this.topic.likes.find(x => x.id == this.user.userId);
    if(usrlike) this.isLiked = true;
    else this.isLiked = false;
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

