using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.DTO
{
    public class AdvertisementDto
    {
        public Guid AdvertisementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
