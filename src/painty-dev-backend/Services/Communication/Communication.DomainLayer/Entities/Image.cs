namespace Communication.DomainLayer.Entities
{
    public class Image : EntityBase
    {
        public string? ImageUri { get; set; }
        public User? User { get; set; }
        private Image() { }
        public Image(string uri, User user) 
        {
            ImageUri = uri;
            User = user;
        }
    }
}
