using CLIMFinders.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace CLIMFinders.Web.ServiceExtension
{
    public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {
            var user = context.User;

            if (!user.Identity?.IsAuthenticated ?? true)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Check roles
            if (requirement.Roles.Length > 0 && !requirement.Roles.Any(role => user.IsInRole(role)))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Check active subscription
            var subscriptionClaim = user.FindFirst(CustomClaimTypes.ActiveSubscription);
            if (subscriptionClaim == null || subscriptionClaim.Value != "Active")
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }

    public class CustomAuthorizationRequirement(params string[] roles) : IAuthorizationRequirement
    {
        public string[] Roles { get; } = roles;
    }
}
