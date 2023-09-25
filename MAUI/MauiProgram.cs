using Microsoft.Extensions.Logging;

namespace MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            //ConfigureService.RegisterServices(builder.Services);
            builder.Services.AddScoped<INewUserService, NewUserService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<ISubscriptionTypeService,SubscriptionTypeService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<UserDetailsPage>();
            builder.Services.AddTransient<AddUserPage>();
            builder.Services.AddTransient<AddSubscriptionTypePage>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<UserDetailsViewModel>();
            builder.Services.AddTransient<AddUserViewModel>();
            builder.Services.AddTransient<AddSubscriptionTypeViewModel>();

            return builder.Build();
        }
    }
}