import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AuthService,
    private router: Router,
     ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
      console.log(this.accountService.currentUser$);
    return this.accountService.currentUser$.pipe(
      map(user => {
        console.log(user);
        if(user) return true;
        this.router.navigateByUrl('/login');                
      })
    );
  }
  
}
