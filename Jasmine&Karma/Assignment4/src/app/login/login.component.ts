import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { InputValidatorService } from '../services/input-validator.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService, private inputValidator: InputValidatorService) {
  }
  ngOnInit(): void {
  }

  needsLogin() {
    return !this.auth.isAuthenticated();
  }

  validateEmailID(email: any) {
    return this.inputValidator.validateEmail(email);
  }

  validatePassword(password: any){
    return this.inputValidator.validatePassword(password);
  }

  validatePhone(phone: any){
    return this.inputValidator.validatePhone(phone);
  }
}
