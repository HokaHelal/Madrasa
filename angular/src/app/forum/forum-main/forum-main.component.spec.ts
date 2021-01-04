/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ForumMainComponent } from './forum-main.component';

describe('ForumMainComponent', () => {
  let component: ForumMainComponent;
  let fixture: ComponentFixture<ForumMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ForumMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ForumMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
