import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCategory2Component } from './add-category2.component';

describe('AddCategory2Component', () => {
  let component: AddCategory2Component;
  let fixture: ComponentFixture<AddCategory2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCategory2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCategory2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
