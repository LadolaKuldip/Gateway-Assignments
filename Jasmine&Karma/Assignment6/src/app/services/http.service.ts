import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { Company } from '../models/company.model';
import { HttpHeaders, HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class HttpService {
  private api = 'http://localhost:3000';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  company!: Company;
  constructor(private httpClient: HttpClient) {}

  create(company: Company): Observable<Company> {
    return this.httpClient.post<Company>(
      this.api + '/company',
      JSON.stringify(company),
      this.httpOptions
    );
  }

  getAllComapnies(): Observable<Company[]> {
    return this.httpClient.get<Company[]>(this.api + '/company');
  }

  update(company: Company): Observable<Company> {
    return this.httpClient.put<Company>(
      this.api + '/company/' + company.id,
      JSON.stringify(company),
      this.httpOptions
    );
  }

  delete(id: number) {
    return this.httpClient.delete<Company>(
      this.api + '/company/' + id,
      this.httpOptions
    );
  }

  getById(id: number) {
    return this.httpClient.get<Company>(
      this.api + '/company/' + id,
      this.httpOptions
    );
  }
  
  companyDetails(companyDetails: Company) {
    debugger;
    this.company = companyDetails;
  }

  getCompany() {
    return this.company;
  }

}
