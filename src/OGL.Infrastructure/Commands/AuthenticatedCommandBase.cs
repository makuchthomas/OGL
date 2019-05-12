﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Commands
{
    public class AuthenticatedCommandBase : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
    }
}
