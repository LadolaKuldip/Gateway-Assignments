import { Branch } from './branch.model';

export class Company {
    id !: number;
    email !: string;
    name !: string;
    totalEmployees !: number;
    address !: string;
    isActive !: boolean;
    totalBranch !: number;
    branch !: Branch[];
}