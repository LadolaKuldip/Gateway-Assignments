import { fakeAsync, TestBed, tick } from '@angular/core/testing';

import { AsyncTestingService } from './async-testing.service';

describe('AsyncTestingService', () => {
  let service: AsyncTestingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AsyncTestingService);
  });

  it('AsyncTestingService should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return list of compnies using done method', (done) => {
    const result = service.getData().then((x) => {
      expect(x.length).toBe(5);
    });
    done();
  });

  it('should return list of compnies using async method', async () => {
    const result = await service.getData();
    expect(result.length).toBe(5);
  });

  it('should return list of compnies using fakeasync method', fakeAsync(() => {
    tick();
    expect(service.getData).toBeTruthy;
    service.getData().then((x) => {
      expect(x.length).toBe(5);
    });
  }));

  it('should return list of compnies using done method (Negative)', (done) => {
    const result = service.getData().then((x) => {
      expect(x.length).not.toBe(0);
    });
    done();
  });

  it('should return list of compnies using async method (nagative)', async () => {
    const result = await service.getData();
    expect(result.length).not.toBe(0);
  });

});
