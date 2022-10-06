import { UserRole } from "./role";

export class User {
    userId: number;
    username: string;
    password: string;
    role: UserRole;

    constructor() {
        this.userId = 0;
        this.username = "panos30fyllou"
        this.password = "";
        this.role = UserRole.Student;
    }
}

export class Student extends User {
    firstName: string;
    lastName: string;
    email: string;

    constructor() {
        super();
        this.firstName = "Panos"
        this.lastName = "Triantafyllou"
        this.email = "panos30fyllou@gmail.com"
    }
}

export class Teacher extends User {
    firstName: string;
    lastName: string;
    email: string;

    constructor() {
        super();
        this.firstName = "Panos"
        this.lastName = "Triantafyllou"
        this.email = "panos30fyllou@gmail.com"
    }
}