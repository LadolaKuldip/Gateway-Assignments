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
  
    it('needsLogin returns true when the user has not been authenticated', () => {
      spy = spyOn(service, 'isAuthenticated').and.returnValue(false);
      expect(component.needsLogin()).toBeTruthy();
      expect(service.isAuthenticated).toHaveBeenCalled();
  
    });
  
    it('needsLogin returns false when the user has been authenticated', () => {
      spy = spyOn(service, 'isAuthenticated').and.returnValue(true);
      expect(component.needsLogin()).toBeFalsy();
      expect(service.isAuthenticated).toHaveBeenCalled();
    });
  });