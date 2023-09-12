namespace BookStoreApp.MAUI.App.UI;

public class TestPage : ContentPage
{
    int count = 0;
    Label lblCounter = new();

    public TestPage()
    {
        var scrollView = new ScrollView();
        var stackLayout = new StackLayout();

        scrollView.Content = stackLayout;

        lblCounter = new Label
        {
            Text = "Count : 0",
            FontSize = 22,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };

        stackLayout.Children.Add(lblCounter);

        var btnCounter = new Button
        {
            Text = "Click to count",
            HorizontalOptions = LayoutOptions.Center
        };

        btnCounter.Clicked += OnCounterClickEvent;

        stackLayout.Children.Add(btnCounter);

        Content = new ScrollView
        {
            Content = stackLayout
        };
    }

    private void OnCounterClickEvent(object sender, EventArgs e)
    {
        count ++;

        lblCounter.Text = $"Click Count: {count}";
        SemanticScreenReader.Announce(lblCounter.Text);
    }
}