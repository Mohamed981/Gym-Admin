
namespace MAUI.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IUserService userService;

        public MainViewModel(IUserService userService)
        {
            Users = new();
            this.userService = userService;
        }

        [ObservableProperty]
        ObservableCollection<User> users;

        [ObservableProperty]
        User selectedUser;

        [RelayCommand]
        async Task GetUsers()
        {
            List<User> users = await userService.GetItems("users");

            Users = new ObservableCollection<User>(users);
        }

        [RelayCommand]
        async Task NavigateToUser(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}?id={SelectedUser.UserID}");
            Users.Clear();
        }

        [RelayCommand]
        async Task AddUser() 
            {
            await Shell.Current.GoToAsync($"{nameof(AddUserPage)}");
            Users.Clear();
        }

        [RelayCommand]
        async Task AddSubscriptionType()
        {
            await Shell.Current.GoToAsync($"{nameof(AddSubscriptionTypePage)}");
            Users.Clear();
        }
    }
}
