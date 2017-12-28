import s = require("../Enum/Status");
import Status = s.Status;
import o = require("../Orders/Order");
import Order = o.Order;

export class StatusUpdate {
    public OrderId: string;
    public Status: Status;
    public Date: Date;
    public Order: Order;
}