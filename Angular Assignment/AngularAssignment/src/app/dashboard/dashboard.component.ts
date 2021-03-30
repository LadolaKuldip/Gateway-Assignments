import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CompanyServiceService } from '../company-service.service';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  companies: any = [];
  addCompanyForm !: FormGroup;
  
  constructor(private httpClient: HttpClient, private companyServiceService : CompanyServiceService,private router:Router) { }

  ngOnInit(): void {
   
    this.httpClient.get("http://localhost:3000/company").subscribe(data =>{
      console.log(data);
      this.companies = data;  
    })
  }

  loadCompanyToEdit(id : number)
  {
    this.companyServiceService.getById(id).subscribe(company => {
      this.companyServiceService.companyDetails(company);
      debugger;
      this.router.navigate(['/edit-company']);
    })
  }

  deleteCompany(id : number)
  {
    debugger;
    
      this.companyServiceService.delete(id).subscribe(res => {
        setTimeout("location.reload(true);", 100);
        console.log(res);
      });
    
  }
}
