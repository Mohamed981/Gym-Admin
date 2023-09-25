
namespace MAUI;

public partial class UserDetailsPage : ContentPage
{
	public UserDetailsPage(UserDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}