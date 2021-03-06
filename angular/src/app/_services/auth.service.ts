import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { User } from '../_models/user';
import { map } from 'rxjs/operators'
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  
constructor(private httpClient: HttpClient, private router: Router) { }

login(model: User) {
  return this.httpClient.post(environment.baseUrl + 'account/login', model).pipe(
    map((response: User) => {
      const user = response;
      if(user) {
        this.setCurrentUser(user);
      }
    })
  );
}

setCurrentUser(user: User) {
  user.roles = [];
  const roles = this.getDecodedToken(user.token).role;
  Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
  localStorage.setItem('user', JSON.stringify(user));
  this.currentUserSource.next(user);
}

logout() {
  localStorage.removeItem('user');
  this.notifyNoCurrentUser();
  this.router.navigateByUrl('/');
}

notifyNoCurrentUser() {
  this.currentUserSource.next(null);
}

getDecodedToken(token) {
  return JSON.parse(atob(token.split('.')[1]));
}
}
