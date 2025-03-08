using CLIMFinders.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CLIMFinders.Web.ServiceExtension
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizeAttribute(params string[] roles) : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            // If user is not authenticated, return 401 Unauthorized
            if (!user.Identity?.IsAuthenticated ?? true)
            {
                context.Result = new RedirectToPageResult("/Login");
                return;
            }

            // Check for Active Subscription
            var subscriptionClaim = user.FindFirst(CustomClaimTypes.ActiveSubscription);
            if (subscriptionClaim == null || subscriptionClaim.Value != "True")
            {
                context.Result = new RedirectToPageResult("/SubscriptionRenew");
                return;
            }

            // Check for required roles
            if (roles.Any() && !roles.Any(role => user.IsInRole(role)))
            {
                context.Result = new RedirectToPageResult("/Unauthorized");
                return;
            }
        }
    }
}
