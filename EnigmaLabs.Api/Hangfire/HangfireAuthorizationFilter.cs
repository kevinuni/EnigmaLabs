using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Enigma.Api.Hangfire;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return httpContext.User.Identity.IsAuthenticated;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
