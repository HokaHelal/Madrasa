import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedComponent } from './shared.component';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { TimeagoModule } from 'ngx-timeago';
import { ModalModule } from 'ngx-bootstrap/modal';

import { LayoutModule } from 'angular-admin-lte';    //Loading layout module
import { BoxModule, BoxInfoModule, TabsModule } from 'angular-admin-lte';       //Box component

export var adminLteConf = {
  skin: 'blue',
  sidebarLeftMenu: [
    {label: 'Start', route: '/', iconClasses: 'fa fa-th'},
  ]
};

@NgModule({
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule,
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    TimeagoModule.forRoot(),
    ButtonsModule.forRoot(),
    LayoutModule.forRoot(adminLteConf),   //Provide the configuration to the layout module.
    ModalModule.forRoot(),
    BoxModule,
    BoxInfoModule
  ],
  declarations: [SharedComponent],
  exports: [
    BsDropdownModule,
    ToastrModule,
    TabsModule,
    BsDatepickerModule,
    PaginationModule,
    TimeagoModule,
    ButtonsModule,
    ModalModule,
    LayoutModule,
    BoxModule,
    BoxInfoModule
  ]
})
export class SharedModule { }
