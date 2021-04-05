export class User {
    email !: string;
    password !: string
    constructor(public Email: string,
      public Password: string) {
          this.email = Email;
          this.password = Password;
    }
}