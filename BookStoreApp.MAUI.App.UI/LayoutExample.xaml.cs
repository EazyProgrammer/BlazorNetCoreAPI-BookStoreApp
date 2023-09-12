namespace BookStoreApp.MAUI.App.UI;

public partial class LayoutExample : ContentPage
{
	public LayoutExample()
	{
		InitializeComponent();

		VStackLayout.Padding = DeviceInfo.Platform == DevicePlatform.iOS ? new Thickness(30, 10, 30, 10) : new Thickness(30, 30, 0, 30);

    }
}