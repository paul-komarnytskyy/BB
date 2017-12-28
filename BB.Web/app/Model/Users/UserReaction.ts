import u = require("./User");
import User = u.User;
import r = require("../Products/Rating");
import Rating = r.Rating;
import rc = require("../Enum/Reaction");
import Reaction = rc.Reaction;
import c = require("../Comment/Comment");
import Comment = c.Comment;

export class UserReaction
{
    public UserReactionId: string;
    public UserID: number;
    public CommentId?: string;
    public RatingId?: string;
    public Reaction: Reaction;
    public User: User;
    public Comment: Comment;
    public Rating: Rating;
}