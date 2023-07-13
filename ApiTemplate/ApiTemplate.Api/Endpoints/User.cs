namespace ApiTemplate.Api.Endpoints
{
    public static partial class User
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("user",
                () =>
                {

                })
                .AllowAnonymous();
        }
    }
}
