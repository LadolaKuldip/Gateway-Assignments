import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckNumberComponent } from './check-number.component';

describe('CheckNumberComponent', () => {
  let component: CheckNumberComponent;
  let fixture: ComponentFixture<CheckNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CheckNumberComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should return negative if input < 0', () => {

    const counterResult = component.ckeckNumber(-1);

    expect(counterResult).toBe("negative");

  });

  it('should return positive if input > 0', () => {

    const counterResult = component.ckeckNumber(1);

    expect(counterResult).toBe("positive");

  });

  it('should return zero if input === 0', () => {

    const counterResult = component.ckeckNumber(0);

    expect(counterResult).toBe("zero");

  });
});
