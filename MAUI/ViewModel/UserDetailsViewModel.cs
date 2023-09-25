
namespace MAUI.ViewModel
{
    [QueryProperty("Id", "id")]
    public partial class UserDetailsViewModel : ObservableObject
    {
        private readonly IUserService userService;
        private readonly ISubscriptionTypeService subTypeService;

        public UserDetailsViewModel(IUserService userService, ISubscriptionTypeService subTypeService)
        {
            User = new();
            SelectedSubType = new();
            this.userService = userService;
            this.subTypeService = subTypeService;
        }
        [ObservableProperty]
        ObservableCollection<SubscriptionType> subTypes;

        [ObservableProperty]
        SubscriptionType selectedSubType;

        [ObservableProperty]
        User user;

        [ObservableProperty]
        string id;

        [ObservableProperty]
        string isPaid;

        [RelayCommand]
        async Task GetUser()
        {
            User = await userService.GetItem("users", Id);
            List<SubscriptionType> subTypes = await subTypeService.GetItems("subscriptiontypes");
            this.SubTypes=new ObservableCollection<SubscriptionType>(subTypes);

            IsPaid=User.IsPaid.ToString();
        }

        [RelayCommand]
        async Task UpdateUser()
        {
            if(SelectedSubType is not null)
                User.SubscriptionTypeID = SelectedSubType.SubscriptionTypeID;
            bool res = await userService.UpdateItem(User,Id,"users");
            if (res)
            {
                await Shell.Current.GoToAsync("..");
                ToastDisplay.Display("User Updated");
                SelectedSubType = null;
            }
            else
                await Shell.Current.DisplayAlert("Alert", "Something went wrong!", "OK"); 
        }
    }
}
