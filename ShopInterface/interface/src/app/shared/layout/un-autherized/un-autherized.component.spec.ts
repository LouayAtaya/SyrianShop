import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnAutherizedComponent } from './un-autherized.component';

describe('UnAutherizedComponent', () => {
  let component: UnAutherizedComponent;
  let fixture: ComponentFixture<UnAutherizedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnAutherizedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UnAutherizedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
