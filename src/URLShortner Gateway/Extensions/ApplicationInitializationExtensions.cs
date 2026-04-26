namespace URLShortner_Gateway.Extensions;

public static class ApplicationInitializationExtensions
{
    public static async Task<WebApplication> AddApplicationAsync(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        return app;
    }
}
