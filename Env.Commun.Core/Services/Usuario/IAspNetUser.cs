﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Env.Commun.Core
{
    public interface IAspNetUser
    {
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }
}