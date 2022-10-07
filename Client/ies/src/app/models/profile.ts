import { UserRole } from "./role"

export class Profile {
    userId = 0;
    roleId = 0;
    username: string = ""
    role: UserRole = 1
    email: string = ""
    name: string = ""
    surname: string = ""
}