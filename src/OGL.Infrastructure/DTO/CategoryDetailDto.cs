using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.DTO
{
    public class CategoryDetailDto : CategoryDto
    {
        public IEnumerable<AdvertisementDto> Advertisements { get; set; }
    }
}
