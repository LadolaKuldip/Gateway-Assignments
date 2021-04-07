import { of } from 'rxjs';
import { Company } from '../models/company.model';

import { HttpService } from './http.service';

describe('HttpService', () => {
  let service: HttpService;
  let httpClientSpy: {
    get: jasmine.Spy;
    post: jasmine.Spy;
    put: jasmine.Spy;
    delete: jasmine.Spy;
  };
  let company: any;

  beforeEach(() => {
    // TestBed.configureTestingModule({});
    // service = TestBed.inject(HttpService);
    httpClientSpy = jasmine.createSpyObj('HttpClient', [
      'get',
      'post',
      'put',
      'delete',
    ]);
    service = new HttpService(<any>httpClientSpy);
    company = new Company(
      1,
      'gateway@gmail.com',
      'Gateway',
      1000,
      'Ahemdabad',
      true,
      3
    );
  });

  it('HttpService should be created', () => {
    expect(service).toBeTruthy();
  });

  it(`getAllComapnies() function should get list of compnies`, (done) => {
    httpClientSpy.get.and.returnValue(of([company]));
    service.getAllComapnies().subscribe((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it(`getById() function should get compny by it's Id`, (done) => {
    httpClientSpy.get.and.returnValue(of([company]));
    service.getById(1).subscribe((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it('create() function should create company', (done) => {
    httpClientSpy.post.and.returnValue(of([{}]));
    service.create(company).subscribe((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it(`update() function should update company`, (done) => {
    httpClientSpy.put.and.returnValue(of([company]));
    service.update(company).subscribe((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it(`delete() function should delete company`, (done) => {
    httpClientSpy.delete.and.returnValue(of([{}]));
    service.delete(1).subscribe((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });
  
});
