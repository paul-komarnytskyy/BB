import u = require("../Users/User");
import User = u.User;
import oi = require("./OrderItem");
import OrderItem = oi.OrderItem;
import su = require("../Status/StatusUpdate");
import StatusUpdate = su.StatusUpdate;

export class Order
{
    public OrderId: string;
    public UserId: number;
    public User: User;
    public OrderItems: OrderItem[];
    public StatusUpdate: StatusUpdate[];

}