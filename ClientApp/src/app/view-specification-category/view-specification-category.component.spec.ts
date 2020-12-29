import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSpecificationCategoryComponent } from './view-specification-category.component';

describe('ViewSpecificationCategoryComponent', () => {
  let component: ViewSpecificationCategoryComponent;
  let fixture: ComponentFixture<ViewSpecificationCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ViewSpecificationCategoryComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSpecificationCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
