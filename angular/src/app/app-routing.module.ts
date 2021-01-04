import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { ClassMatesComponent } from './class-mates/class-mates.component';
import { ClassRoomComponent } from './class-room/class-room.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ForumMainComponent } from './forum/forum-main/forum-main.component';
import { ContentMainComponent } from './theme/content/content-main/content-main.component';

const routes: Routes = [
  
  { path: '', redirectTo: '/app', pathMatch: 'full'  },
  { path: 'login', component: LoginComponent },
  { path: 'app', 
  runGuardsAndResolvers: 'always',
  component: ContentMainComponent ,
  children: [
    { path: '', component: DashboardComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'classroom', component: ClassRoomComponent },
    { path: 'classmates', component: ClassMatesComponent },
    { path: 'forums', component: ForumMainComponent },
  ]
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
