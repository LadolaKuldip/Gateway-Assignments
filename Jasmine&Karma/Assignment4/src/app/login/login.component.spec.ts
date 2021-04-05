import { AuthService } from '../services/auth.service';
import { InputValidatorService } from '../services/input-validator.service';

import { LoginComponent } from './login.component';

describe('LoginComponent with Real Service', () => {
  let component: LoginComponent;
  let service: AuthService;
  let inputValidator: InputValidatorService;
  beforeEach(() => {
    service = new AuthService();
    inputValidator = new InputValidatorService();
    component = new LoginComponent(service,inputValidator);
  });

  afterEach(() => {
    localStorage.removeItem('token');
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('needsLogin returns true when the user has not been authenticated', () => {
    expect(component.needsLogin()).toBeTruthy();
  });

  it('needsLogin returns false when the user has been authenticated', () => {
    localStorage.setItem('token', '12345');
    expect(component.needsLogin()).toBeFalsy();
  });
});
