export class UserShort {
    public Username: string;
    public UserID: number;
    public DiscountId: number;

    constructor(userID: number, discountId: number, username: string) {
        this.Username = username;
        this.DiscountId = discountId;
        this.UserID = userID;
    }
}