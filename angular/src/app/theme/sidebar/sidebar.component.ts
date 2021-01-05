import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  user: User;

  constructor(private accountService: AuthService, private toastr: ToastrService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(usr => this.user = usr);
  }
  ngOnInit() {
  }

}
