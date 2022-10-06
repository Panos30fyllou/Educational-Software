import { UserRole } from "./role";

export class RegisterRequest{
    username: string;
    password: string;
    role: UserRole;
    name: string;
    surname: string;
    email: string;

    constructor() {
        this.username = ""
        this.password = "";
        this.role = UserRole.Student;
        this.name = ""
        this.surname = ""
        this.email = ""
    }
}