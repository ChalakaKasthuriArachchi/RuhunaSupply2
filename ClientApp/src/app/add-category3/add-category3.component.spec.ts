import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCategory3Component } from './add-category3.component';

describe('AddCategory3Component', () => {
  let component: AddCategory3Component;
  let fixture: ComponentFixture<AddCategory3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCategory3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCategory3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
