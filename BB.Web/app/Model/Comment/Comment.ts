import u = require("../Users/User");
import User = u.User;
import p = require("../Products/Product");
import Product = p.Product;
import ur = require("../Users/UserReaction");
import UserReaction = ur.UserReaction;

export class Comment {
    public CommentId: string;
    public Text: string;
    public DataPosted: Date;
    public ParentCommentId?: string;
    public UserID: number;
    public ProductId?: number;
    public User: User;
    public ParentComment: Comment;
    public Product: Product;
    public UserReactions:UserReaction[];
    public ChildComments: Comment[]; 

}