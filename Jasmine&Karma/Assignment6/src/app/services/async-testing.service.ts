import { Injectable } from '@angular/core';
import { Company } from '../models/company.model';

@Injectable({
  providedIn: 'root'
})
export class AsyncTestingService {

  constructor() { }getData(): Promise<Company[]>{
    let data:Company[] = [];
    data.push(new Company(1, 'gatewaydigital@gmail.com', 'Gateway Digital', 500, 'Ahemdabad', true, 5));
    data.push(new Company(2,  'autofacets@gmail.com', 'Autofacets', 400, 'Ahemdabad', true, 4));
    data.push(new Company(3, 'dilx@gmail.com', 'DiLX', 300, 'Ahemdabad', true, 3));
    data.push(new Company(4, 'gsecure.labs@gmail.com', 'G`Secure Labs', 200, 'Ahemdabad', true, 2));
    data.push(new Company(5, 'autodap@gmail.com', 'AutoDAP', 100, 'Ahemdabad', true, 1));

    return new Promise<Company[]>(
      (resolve, reject) => {
        resolve(data);
      }
    )
  }
}
