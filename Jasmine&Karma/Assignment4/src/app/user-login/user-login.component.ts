import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../Entities/User';
import { UserloginService } from '../services/userlogin.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css'],
})
export class UserLoginComponent implements OnInit {
  @Output() loggedIn = new EventEmitter<User>();
  form!: FormGroup;

  constructor(private fb: FormBuilder, private userService : UserloginService) {}

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.pattern('[^ @]*@[^ @]*')]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  login() {
    
    if (this.form.valid) {
      debugger;
      console.log(this.form.value);
      debugger;
      this.loggedIn.emit(
        new User(this.form.value.email, this.form.value.password)
      );
      this.userService.addUser(new User(this.form.value.email, this.form.value.password));
    }
  }
}
