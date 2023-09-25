
namespace MAUI.ViewModel
{
    public partial class AddSubscriptionTypeViewModel : ObservableObject
    {
        private readonly ISubscriptionTypeService subscriptionTypeService;

        public AddSubscriptionTypeViewModel(ISubscriptionTypeService subscriptionTypeService )
        {
            SubscriptionType = new();
            this.subscriptionTypeService = subscriptionTypeService;
        }
        [ObservableProperty]
        SubscriptionType subscriptionType;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        short price;

        [ObservableProperty]
        short duration;

        [RelayCommand]
        async Task AddSubscriptionType()
        {
            SubscriptionType.SubscriptionTypeName = Name;
            SubscriptionType.Duration = Duration;
            SubscriptionType.Price = Price;
            bool res=await subscriptionTypeService.AddItem(SubscriptionType, "subscriptiontypes");
            if (res)
            {
                await Shell.Current.GoToAsync("..");
                ToastDisplay.Display("Subscription Type Created");
            }
            else
                await Shell.Current.DisplayAlert("Alert", "Something went wrong!", "OK");
        }


    }

}
