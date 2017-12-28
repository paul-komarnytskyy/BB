import ud = require("../Users/UserDetails");
import UserDetails = ud.UserDetails;

export class Address {
    public UserID: number;
    public City: string;
    public Country: string;
    public Street: string;
    public HouseNumber: string;
    public PostalCode: number;
    public UserDetails: UserDetails;
}