using Microsoft.Extensions.Logging;
using ToDo.Shared.Wrappers;



namespace ToDo.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddScoped<TodoApi>();

        // Update the BaseAddress to use HTTP and ensure the correct IP/port is used
        builder.Services.AddHttpClient<TodoApi>(client =>
        {
            client.BaseAddress = new Uri("http://10.0.2.2:5560"); // Ensure HTTP is used
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
