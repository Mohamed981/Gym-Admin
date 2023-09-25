namespace MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
            Routing.RegisterRoute(nameof(AddUserPage), typeof(AddUserPage));
            Routing.RegisterRoute(nameof(AddSubscriptionTypePage), typeof(AddSubscriptionTypePage));
        }
    }
}