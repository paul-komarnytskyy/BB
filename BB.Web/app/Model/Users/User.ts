import r = require("./Role");
import Role = r.Role;

export class User {
    public Username: string;
    public Roles: Role[];
    public Email: string;
    public UserID: number;
    public LoyaltyStatus: number;

    constructor(username: string, roles: Role[], email: string, userID: number, loyaltyStatus: number) {
        this.Username = username;
        this.Roles = roles;
        this.Email = email;
        this.UserID = userID;
        this.LoyaltyStatus = loyaltyStatus;
    }

    LoyaltyLevel() : string {
        switch (this.LoyaltyStatus) {
            case (0):
                return 'None';
            case (1):
                return 'Loyal';
            case (2):
                return 'VIP';
        }
    }
}
