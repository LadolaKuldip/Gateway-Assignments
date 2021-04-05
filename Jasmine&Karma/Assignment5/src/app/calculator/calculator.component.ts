import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  param1 : number = 0;
  param2 : number = 0;
  result : number = 0;
  constructor() { }

  ngOnInit(): void {
  }
  add() {
    this.result = this.param1 + this.param2;
  }

  subtract() {
    this.result = this.param1- this.param2;
  }

  multiply() {
    this.result = this.param1* this.param2;
  }

  divide(){
    this.result = (this.param2 === 0) ? 0 : this.param1 / this.param2;
  }
}
