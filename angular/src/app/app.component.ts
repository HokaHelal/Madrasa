import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Madrasa';
  constructor(private authService: AuthService) {}
  
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    if(user) {
      this.authService.setCurrentUser(user);
    }
    else {
      this.authService.notifyNoCurrentUser();
    }
  }

}
