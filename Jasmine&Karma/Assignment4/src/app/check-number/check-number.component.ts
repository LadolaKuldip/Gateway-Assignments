import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-check-number',
  templateUrl: './check-number.component.html',
  styleUrls: ['./check-number.component.css']
})
export class CheckNumberComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  ckeckNumber(num:any){
    if (num < 0) {
      return "negative"     
    } else if (num > 0) {
      return "positive"      
    }else{
      return "zero"
    }
  }
}
