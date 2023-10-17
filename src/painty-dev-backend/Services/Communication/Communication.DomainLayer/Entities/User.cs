using Cryptography;
using Cryptography.Cryptors;
using Cryptography.Models;
using System.ComponentModel.DataAnnotations;

namespace Communication.DomainLayer.Entities
{
    public class User : EntityBase
    {
        [Required(ErrorMessage = "The name field is required to fill")]
        public string? Name { get; set; }
        private string? PasswordHash { get; set; }
        private string? PasswordSalt { get; set; }
        private UserRole? _role;
        public UserRole? Role => _role;
        private List<Image> _images = new List<Image>();
        public IReadOnlyCollection<Image> Images => _images;
        public List<Friendship> Friends { get; set; } = new List<Friendship>();

        private User() { }
        public User(string name, string password, UserRole role)
        {
            Cryptor cryptor = new Cryptor(new Sha256Algorithm());
            if (password.Length < 6) throw new ArgumentException("Password length must contains more that 6 symbols");
            Name = name;
            KeyPairModel model = (KeyPairModel)cryptor.Crypt(password);
            PasswordHash = model.Key;
            PasswordSalt = model.Value;
            _role = role;
        }

        public void AddImage(Image image) => _images.Add(image);

        public void RemoveImage(Image image) => _images.Remove(image);

        public void AddFriend(User user) => Friends.Add(new Friendship(this, user));

        public void ConfirmFriendship(Friendship friendship) => friendship.ApproveFriendsip();

        public bool Validate(string password)
        {
            Cryptor cryptor = new Cryptor(new Sha256Algorithm());
            return cryptor.Validate(password, new KeyPairModel { Key = PasswordHash, Value = PasswordSalt });
        }
    }
}
