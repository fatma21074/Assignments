using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;
using Task12.Models;

namespace Task12.Authorization
{
    public class TaskAuthorizationHandler
 : AuthorizationHandler<OperationAuthorizationRequirement, TaskItem>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            TaskItem resource)
        {
            var userId = context.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (resource.UserId.ToString() == userId
                || context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
