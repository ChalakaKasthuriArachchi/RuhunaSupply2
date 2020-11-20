import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecificationCategoryComponent } from './specification-category.component';

describe('SpecificationCategoryComponent', () => {
  let component: SpecificationCategoryComponent;
  let fixture: ComponentFixture<SpecificationCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecificationCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecificationCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
