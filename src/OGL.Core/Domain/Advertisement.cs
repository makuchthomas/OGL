using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Core.Domain
{
    public class Advertisement
    {
        public Guid AdvertisementId { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public Guid UserId { get; protected set; }
        public Guid CategoryId { get; protected set; }

        protected Advertisement() { }

        public Advertisement(Guid advertisementId, string title, string content, Guid userId, Guid categoryId)
        {
            AdvertisementId = advertisementId;
            UserId = userId;
            CategoryId = categoryId;
            SetContent(content);
            SetTitle(title);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title field cannot be empty.",
                    nameof(title));
            }
            if (title.Length > 100)
            {
                throw new ArgumentException("Title can not have more than 100 characters",
                    nameof(title));
            }
            Title = title;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Content field cannot be empty.",
                    nameof(content));
            }
            if (content.Length > 1000)
            {
                throw new ArgumentException("Title can not have more than 1000 characters",
                    nameof(content));
            }
            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Advertisement Create(Guid advertisementId, string title, string content, Guid userId, Guid categoryId)
            => new Advertisement(Guid.NewGuid(), title, content, userId, categoryId);

    }
}

