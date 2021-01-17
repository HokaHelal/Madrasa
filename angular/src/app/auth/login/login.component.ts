import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AuthService
    , private router: Router) { }

  ngOnInit() {
  }

  loginAs(username: string) {
      this.model = { username: username, password: 'Password'};
      this.login();
  }
  login() {
    this.accountService.login(this.model).subscribe( res => {
      this.router.navigateByUrl('/app/forums');
  });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/login');
  }
}
