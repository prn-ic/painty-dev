namespace EventBus.Entities.Users
{
    public class AuthCreateModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? RoleName { get; set; }
    }
}
