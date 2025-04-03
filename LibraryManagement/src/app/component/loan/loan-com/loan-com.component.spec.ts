import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanComComponent } from './loan-com.component';

describe('LoanComComponent', () => {
  let component: LoanComComponent;
  let fixture: ComponentFixture<LoanComComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoanComComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoanComComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
