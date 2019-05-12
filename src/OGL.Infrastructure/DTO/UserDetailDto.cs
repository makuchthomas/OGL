using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.DTO
{
    public class UserDetailDto : UserDto
    {
        public IEnumerable<AdvertisementDto> Advertisements { get; set; }
    }
}
