
namespace MAUI;

public partial class AddSubscriptionTypePage : ContentPage
{
	public AddSubscriptionTypePage(AddSubscriptionTypeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}