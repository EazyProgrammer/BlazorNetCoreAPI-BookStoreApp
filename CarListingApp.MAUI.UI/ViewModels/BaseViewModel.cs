using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListingApp.MAUI.UI.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        private bool isLoading;

        public bool IsNotLoading => !IsLoading;
    }
}
