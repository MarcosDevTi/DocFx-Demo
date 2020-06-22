﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace Env.Commun
{
    public class CustomAuthorization
    {
        public static bool ValiderClaimsUtilisateurs(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }

    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(ContrainteClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    public class ContrainteClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public ContrainteClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.ValiderClaimsUtilisateurs(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}