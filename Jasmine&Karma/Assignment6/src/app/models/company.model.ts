export class Company {
  id!: number;
  email!: string;
  name!: string;
  totalEmployees!: number;
  address!: string;
  isActive!: boolean;
  totalBranch!: number;

  constructor(
    id: number,
    email: string,
    name: string,
    totalEmployees: number,
    address: string,
    isActive: boolean,
    totalBranch: number
  ) {
    this.id = id;
    this.email = email;
    this.name = name;
    this.totalEmployees = totalEmployees;
    this.address = address;
    this.isActive = isActive;
    this.totalBranch = totalBranch;
  }
}
