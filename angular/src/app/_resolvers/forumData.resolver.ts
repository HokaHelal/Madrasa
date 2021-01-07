import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { User } from '../_models/user';
import { Forum } from '../_models/Forum';
import { Observable, of } from 'rxjs';
import { catchError, take } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';
import { ForumService } from '../_services/forum.service';

@Injectable()
export class ForumDataResolver implements Resolve<Forum[]> {
  constructor(private userService: AuthService, 
    private forumService: ForumService,
    private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Forum[]> {
    let user : User;
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => user = usr);

    return this.forumService.getMainForum(user.classId).pipe(
      catchError(error => {
        this.router.navigate(['/lists']);
        return of(null);
      })
    );  
  }
}
