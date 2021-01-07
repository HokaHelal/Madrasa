import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { User } from '../_models/user';
import { Forum } from '../_models/Forum';
import { Observable, of } from 'rxjs';
import { catchError, take } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';
import { ForumService } from '../_services/forum.service';
import { Topic } from '../_models/Topic';

@Injectable()
export class TopicResolver implements Resolve<Topic> {
  constructor(private forumService: ForumService,
    private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Topic> {

    return this.forumService.getTopicById(route.params.id).pipe(
      catchError(error => {
        //this.router.navigate(['/lists']);
        return of(null);
      })
    );  
  }
}
