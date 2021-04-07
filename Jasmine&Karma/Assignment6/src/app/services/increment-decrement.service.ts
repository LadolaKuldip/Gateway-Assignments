import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IncrementDecrementService {
  value = 0;
  message !: string;
  constructor() { }

  increment() {
    setTimeout(() => {
      if (this.value < 15) {
        this.value += 1;
        this.message = '';
      } else {
        this.message = 'Maximum reached!';
      }
    }, 5000); // wait 5 seconds to increment the value
  }
}
