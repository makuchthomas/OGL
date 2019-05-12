using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGL.Core.Domain
{
    public class User
    {
        private ISet<Advertisement> _advertisements = new HashSet<Advertisement>();


        public Guid UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }
        public string Username { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Advertisement> Advertisements
        {
            get { return _advertisements; }
            set { _advertisements = new HashSet<Advertisement>(value); }
        }

        protected User() { }

        public User(Guid userId, string email, string username, string password, string role, string salt, string hash)
        {
            UserId = userId;
            SetRole(role);
            SetEmail(email);
            SetUsername(username);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new Exception("Role can not be empty.");
            }
            if (Role == role)
            {
                return;
            }
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty.");
            }
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username can not be empty.");
            }
            Username = username;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddAdvertisement(Guid advertisementId, string title, string content, Guid userId, Guid categoryId)
        {
            var advertisement = Advertisements.SingleOrDefault(x => x.Title == title);
            if (advertisement != null)
            {
                throw new Exception($"Advertisement with name: '{advertisement}' already exists for user.");
            }

            _advertisements.Add(Advertisement.Create(Guid.NewGuid(), title, content, userId, categoryId));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteAdvertisement(string title)
        {
            var advertisement = Advertisements.SingleOrDefault(x => x.Title == title);
            if (advertisement == null)
            {
                throw new Exception($"Advertisement named: '{title}' was not found.");
            }
            _advertisements.Remove(advertisement);
            UpdatedAt = DateTime.UtcNow;
        }
        private Advertisement GetAdvertisement(string title)
            => _advertisements.SingleOrDefault(x => x.Title == title);
        /*public IEnumerable<Advertisement> GetAdvertisementsForUser(User user)
            => _advertisements.Where(x => x.UserId == user.UserId);*/

    }
}
