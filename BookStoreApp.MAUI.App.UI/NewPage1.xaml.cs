namespace BookStoreApp.MAUI.App.UI;

public partial class NewPage1 : ContentPage
{
    int count = 0;

    public NewPage1()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        count++;

        lblCounter.Text = $"Click Count: {count}";
        SemanticScreenReader.Announce(lblCounter.Text);
    }
}