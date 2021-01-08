import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError, take } from 'rxjs/operators';
import { ForumService } from '../_services/forum.service';
import { TopicMain } from '../_models/TopicMain';
import { Section } from '../_models/Section';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/user';

@Injectable()
export class SectionResolver implements Resolve<Section> {
  constructor(private forumService: ForumService,
    private userService: AuthService, 
    private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Section> {
    let user : User;
    this.userService.currentUser$.pipe(take(1)).subscribe(usr => user = usr);

    return this.forumService.getTopicsBySectionId(route.params.id, user.classId).pipe(
      catchError(error => {
        //this.router.navigate(['/lists']);
        return of(null);
      })
    );  
  }
}
