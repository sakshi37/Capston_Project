import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllLoansComponent } from './all-loans.component';

describe('AllLoansComponent', () => {
  let component: AllLoansComponent;
  let fixture: ComponentFixture<AllLoansComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllLoansComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllLoansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
