import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './_modules/shared/shared.module';
import { NavComponent } from './nav/nav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ControlSidebarComponent } from './control-sidebar/control-sidebar.component';
import { ContentFooterComponent } from './content/content-footer/content-footer.component';
import { ContentHeaderComponent } from './content/content-header/content-header.component';

@NgModule({
  declarations: [						
    AppComponent,
      NavComponent,
      DashboardComponent,
      SidebarComponent,
      ControlSidebarComponent,
      ContentFooterComponent,
      ContentHeaderComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
