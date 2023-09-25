
namespace MAUI.ViewModel
{
    public partial class AddUserViewModel : ObservableObject
    {
        private readonly INewUserService newUserService;
        private readonly ISubscriptionTypeService subscriptionTypeService;

        public AddUserViewModel(INewUserService newUserService ,ISubscriptionTypeService subscriptionTypeService)
        {
            NewUser = new();
            SubscriptionTypes = new();
            this.newUserService = newUserService;
            this.subscriptionTypeService = subscriptionTypeService;
        }
        [ObservableProperty]
        NewUser newUser;

        [ObservableProperty]
        ObservableCollection<SubscriptionType> subscriptionTypes;

        [ObservableProperty]
        SubscriptionType selectedSubscriptionType;

        [ObservableProperty]
        short age;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string phoneNumber;

        [ObservableProperty]
        short daysRemaining;

        [ObservableProperty]
        string isPaid;

        [RelayCommand]
        async Task AddUser()
        {
            NewUser.UserName = Name;
            NewUser.PhoneNumber = PhoneNumber;
            NewUser.Age = Age;
            NewUser.IsPaid = bool.Parse(IsPaid);
            NewUser.DaysRemaining = DaysRemaining;
            NewUser.SubscriptionTypeID = SelectedSubscriptionType.SubscriptionTypeID;
            bool res = await newUserService.AddItem(NewUser, "Users");
            if (res)
            {
                await Shell.Current.GoToAsync("..");
                ToastDisplay.Display("User Created");
            }
            else
                await Shell.Current.DisplayAlert("Alert", "Something went wrong!", "OK"); 
        }

        [RelayCommand]
        async Task GetSubscriptionTypes()
        {
            List<SubscriptionType> subscriptionTypes = await subscriptionTypeService.GetItems("subscriptiontypes");
            SubscriptionTypes = new ObservableCollection<SubscriptionType>(subscriptionTypes);       
            
        }
    }
}
