﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
    }
}
