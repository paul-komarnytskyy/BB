import u = require("./User");
import User = u.User;
import g = require("../Enum/Gender");
import Gender = g.Gender;
import a = require("../Address/Address");
import Address = a.Address;
export class UserDetails
{
    public UserID: number;
    public FirstName: string;
    public MiddleName: string;
    public LastName: string;
    public Gender: Gender;
    public Birthday: Date;
    public PhoneNumber: string;
    public Address: Address;
    public User: User;
}