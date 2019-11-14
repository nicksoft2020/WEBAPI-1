import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppComponent } from './user-account.component';

describe('UserAccountComponent', () => {
    let component: AppComponent;
    let fixture: ComponentFixture<AppComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [AppComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
