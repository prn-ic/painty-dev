namespace Communication.DomainLayer.Entities
{
    public class Friendship : EntityBase
    {
        public User? RequestFrom { get; set; }
        public User? RequestTo { get; set; }
        public bool Approved { get; set; }
        private Friendship() { }
        public Friendship(User requestFrom, User requestTo)
        {
            RequestFrom = requestFrom;
            RequestTo = requestTo;
            Approved = false;
        }

        public void ApproveFriendsip() => Approved = true;
    }
}
