namespace Communication.DomainLayer.Entities
{
    public class UserRole : EntityBase
    {
        public string? Name { get; set; }
        private UserRole() { }
        public UserRole(string name) => Name = name;
    }
}
