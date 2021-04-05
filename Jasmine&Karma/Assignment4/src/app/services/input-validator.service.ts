import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class InputValidatorService {
  constructor() {}

  validateEmail(email: any) {
    const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regularExpression.test(String(email).toLowerCase());
  }

  validatePassword(password: any) {
    const regularExpression = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
    return regularExpression.test(String(password));
  }

  validatePhone(phone: any) {
    const regularExpression = /^((\\+91-?)|0)?[0-9]{10}$/;
    return regularExpression.test(String(phone));
  }
}
