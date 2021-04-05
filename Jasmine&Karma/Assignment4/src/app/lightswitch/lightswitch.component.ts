import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lightswitch',
  templateUrl: './lightswitch.component.html',
  styleUrls: ['./lightswitch.component.css']
})
export class LightswitchComponent implements OnInit {
  isOn = false;
  constructor() { }

  ngOnInit(): void {
  }
  
  clicked() { this.isOn = !this.isOn; }
  get message() { return `The light is ${this.isOn ? 'On' : 'Off'}`; }
}
