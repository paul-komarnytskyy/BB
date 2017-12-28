export class RegistrationModel {
    public Password: string;
    public Username: string;
    public Email: string;

    constructor(email: string, username: string, password: string) {
        this.Email = email;
        this.Username = username;
        this.Password = password;
    }
}