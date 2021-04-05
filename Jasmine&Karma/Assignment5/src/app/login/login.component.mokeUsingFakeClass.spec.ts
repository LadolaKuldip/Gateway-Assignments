import { InputValidatorService } from '../services/input-validator.service';
import { LoginComponent } from './login.component';

class MockAuthService {
  authenticated = false;

  isAuthenticated() {
    return this.authenticated;
  }
}

describe('LoginComponent with fake Class', () => {
  let component: LoginComponent;
  let service: MockAuthService;
  let inputValidator: InputValidatorService;
  beforeEach(() => {
    service = new MockAuthService();
    inputValidator = new InputValidatorService();
    component = new LoginComponent(service, inputValidator);
  });

  it('needsLogin returns true when the user has not been authenticated', () => {
    service.authenticated = false;
    expect(component.needsLogin()).toBeTruthy();
  });

  it('needsLogin returns false when the user has been authenticated', () => {
    service.authenticated = true;
    expect(component.needsLogin()).toBeFalsy();
  });
});
