import r = require("./Role");
import Role = r.Role;

export class User {
    public Username: string;
    public Roles: Role[];
    public Email: string;
    public UserID: number;
}
