import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LightswitchComponent } from './lightswitch/lightswitch.component';
import { CounterComponent } from './counter/counter.component';
import { CalculatorComponent } from './calculator/calculator.component';
import { CheckNumberComponent } from './check-number/check-number.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    LightswitchComponent,
    CounterComponent,
    CalculatorComponent,
    CheckNumberComponent,
    UserLoginComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
