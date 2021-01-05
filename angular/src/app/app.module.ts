import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginComponent } from './auth/login/login.component';
import { ForgetPasswordComponent } from './auth/forget-password/forget-password.component';
import { NavComponent } from './theme/nav/nav.component';
import { SidebarComponent } from './theme/sidebar/sidebar.component';
import { ControlSidebarComponent } from './theme/control-sidebar/control-sidebar.component';
import { ContentHeaderComponent } from './theme/content/content-header/content-header.component';
import { ContentFooterComponent } from './theme/content/content-footer/content-footer.component';
import { ContentMainComponent } from './theme/content/content-main/content-main.component';
import { ForumMainComponent } from './forum/forum-main/forum-main.component';
import { ClassRoomComponent } from './class-room/class-room.component';
import { ClassMatesComponent } from './class-mates/class-mates.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [			
    AppComponent,
    LoginComponent,
    ForgetPasswordComponent,
    NavComponent,
    SidebarComponent,
    ControlSidebarComponent,
    ContentHeaderComponent,
    ContentMainComponent,
    ContentFooterComponent,
    ForumMainComponent,
      ClassRoomComponent,
      ClassMatesComponent,
      DashboardComponent
   ],
  imports: [
    BrowserModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
   // {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
