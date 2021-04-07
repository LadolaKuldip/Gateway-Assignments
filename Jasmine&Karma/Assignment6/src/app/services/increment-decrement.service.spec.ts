import { fakeAsync, TestBed, tick } from '@angular/core/testing';

import { IncrementDecrementService } from './increment-decrement.service';

describe('IncrementDecrementService', () => {
  let service: IncrementDecrementService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({});
    service = TestBed.inject(IncrementDecrementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should increment in template after 5 seconds', fakeAsync(() => {
    expect(service.value).toEqual(0); // value should be 0 initially

    service.increment();

    tick(2000);
    expect(service.value).toEqual(0); // value should still be 0 after 2 seconds

    tick(3000);
    expect(service.value).toEqual(1); // 3 seconds later, our value should now be 1
  }));
});
