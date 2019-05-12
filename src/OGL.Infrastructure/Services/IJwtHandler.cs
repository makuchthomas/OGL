using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto Createtoken(string email, string role);
    }
}
