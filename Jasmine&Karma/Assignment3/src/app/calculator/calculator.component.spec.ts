import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculatorComponent } from './calculator.component';

describe('CalculatorComponent', () => { 
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ CalculatorComponent ],
      providers: [
        
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should do addition', () => {
    component.param1 = 5;
    component.param2 = 7;

    component.add();

    expect(component.result).toBe(12);
  });

  it('should do subtraction', () => {
    component.param1 = 9;
    component.param2 = 7;

    component.subtract();

    expect(component.result).toBe(2);
  });

  it('should do multiplication', () => {
    component.param1 = 5;
    component.param2 = 7;

    component.multiply();

    expect(component.result).toBe(35);
  });

  it('should do division', () => {
    component.param1 = 6;
    component.param2 = 2;

    component.divide();

    expect(component.result).toBe(3);
  });
});