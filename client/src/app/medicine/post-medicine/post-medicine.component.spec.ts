import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostMedicineComponent } from './post-medicine.component';

describe('PostMedicineComponent', () => {
  let component: PostMedicineComponent;
  let fixture: ComponentFixture<PostMedicineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostMedicineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostMedicineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
