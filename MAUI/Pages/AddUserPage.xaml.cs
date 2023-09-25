
namespace MAUI;

public partial class AddUserPage : ContentPage
{
	public AddUserPage(AddUserViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}