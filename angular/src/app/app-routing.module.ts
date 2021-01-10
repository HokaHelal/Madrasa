import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { ClassMatesComponent } from './class-mates/class-mates.component';
import { ClassRoomComponent } from './class-room/class-room.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ForumMainComponent } from './forum/forum-main/forum-main.component';
import { SectionPageComponent } from './forum/section-page/section-page.component';
import { SectionComponent } from './forum/section/section.component';
import { ThreadComponent } from './forum/thread/thread.component';
import { TopicDetailComponent } from './forum/topic-detail/topic-detail.component';
import { TopicComponent } from './forum/topic/topic.component';
import { ContentMainComponent } from './theme/content/content-main/content-main.component';
import { AuthGuard } from './_guards/auth.guard';
import { ForumDataResolver } from './_resolvers/forumData.resolver';
import { LatestTopicsResolver } from './_resolvers/latestTopics.resolver';
import { SectionResolver } from './_resolvers/section.resolver';
import { TopicResolver } from './_resolvers/Topic.resolver';

const routes: Routes = [
  
  { path: '', redirectTo: '/app/forums', pathMatch: 'full'  },
  { path: 'login', component: LoginComponent },
  { path: 'app', 
  runGuardsAndResolvers: 'always',
  canActivate: [AuthGuard],
  component: ContentMainComponent ,
  children: [
    { path: '',  component: DashboardComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'classroom', component: ClassRoomComponent },
    { path: 'classmates', component: ClassMatesComponent },
    { path: 'forums', component: ForumMainComponent,
      resolve: {forumData: ForumDataResolver, latestTopics: LatestTopicsResolver}},
    { path: 'forums/section/:id', component: SectionPageComponent, resolve: {section: SectionResolver} },
    { path: 'forums/thread/:id', component: ThreadComponent, resolve: {topic: TopicResolver}, pathMatch: 'full'  }    
  ]
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
