import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficesDetailsComponent } from './offices-details.component';

describe('OfficesDetailsComponent', () => {
  let component: OfficesDetailsComponent;
  let fixture: ComponentFixture<OfficesDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfficesDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
