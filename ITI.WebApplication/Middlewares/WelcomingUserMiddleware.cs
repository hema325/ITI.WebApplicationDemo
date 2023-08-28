namespace ITI.WebApplication.Middlewares
{
    public class WelcomingUserMiddleware : IMiddleware
    {
        private const string HeaderName = "Welcoming";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Request.Cookies.TryGetValue(HeaderName, out var value);
            
            if (!Convert.ToBoolean(value))
            {
                context.Response.Cookies.Append(HeaderName, true.ToString(), new CookieOptions { Expires = DateTime.UtcNow.AddYears(1) });

                await context.Response.WriteAsync(@"<h1>Welcome stranger</h1>
                                                    <p>thank's for visiting us </p>
                                                    <a href=""\home\index"">Click here to continue</a>");
            }
            
            await next(context);
        }
    }
}
