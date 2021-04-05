import { Injectable } from '@angular/core';
import { User } from '../Entities/User';

@Injectable({
  providedIn: 'root'
})
export class UserloginService {
  users : any = [];
  constructor() { }

  addUser(user : User){  
    if(this.users.push(user)){
      return true;
    }  
    else{
      return false;
    }
    //console.log(this.users.value);
  }
}
