import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CounterComponent } from './counter.component';

describe('CounterComponent (isolated test)', () => {
  it('should instantiate', () => {
    const component: CounterComponent = new CounterComponent();
    expect(component).toBeDefined();
  });

  it('should start with a counter at `0`', () => {
    const component: CounterComponent = new CounterComponent();
    expect(component.counter).toEqual(0);
  });

  it('should be able to increment the counter (+1)', () => {
    const component: CounterComponent = new CounterComponent();
    component.counter = 5;

    component.increment();

    expect(component.counter).toEqual(6);
  });

  it('should be able to decrement the counter (-1)', () => {
    const component: CounterComponent = new CounterComponent();
    component.counter = 5;

    component.decrement();

    expect(component.counter).toEqual(4);
  });
});