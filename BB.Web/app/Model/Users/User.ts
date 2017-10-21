import r = require("./Role");
import Role = r.Role;

export class User {
    public Username: string;
    public Roles: Role[];
    public Email: string;
    public UserID: number;

    constructor(username: string, roles: Role[], email: string, userID: number) {
        this.Username = username;
        this.Roles = roles;
        this.Email = email;
        this.UserID = userID;
    }
}
