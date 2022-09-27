export class User {
    username: string;
    password: string;

    constructor() {
        this.username = "panos30fyllou"
        this.password = "";
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