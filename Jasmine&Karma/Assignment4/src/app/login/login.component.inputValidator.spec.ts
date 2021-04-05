import { AuthService } from '../services/auth.service';
import { InputValidatorService } from '../services/input-validator.service';
import { LoginComponent } from './login.component';

describe('LoginComponent with Spy', () => {
  let component: LoginComponent;
  let service: AuthService;
  let inputValidator: InputValidatorService;
  let spy: any;

  beforeEach(() => {
    service = new AuthService();
    inputValidator = new InputValidatorService();
    component = new LoginComponent(service, inputValidator);
  });

  it('validateEmailId returns true when the email address is valid', () => {
    spy = spyOn(inputValidator, 'validateEmail').and.returnValue(true);
    expect(component.validateEmailID('akshayraj@gmail.com')).toBeTruthy();
    expect(inputValidator.validateEmail).toHaveBeenCalled();
  });

  it('validatePassword returns true when the password is valid', () => {
    spy = spyOn(inputValidator, 'validatePassword').and.returnValue(true);
    expect(component.validatePassword('P@ssw0rd')).toBeTruthy();
    expect(inputValidator.validatePassword).toHaveBeenCalled();
  });

  it('validatePhone returns true when the phone number is valid', () => {
    spy = spyOn(inputValidator, 'validatePhone').and.returnValue(true);
    expect(component.validatePhone('9985741230')).toBeTruthy();
    expect(inputValidator.validatePhone).toHaveBeenCalled();
  });
});
