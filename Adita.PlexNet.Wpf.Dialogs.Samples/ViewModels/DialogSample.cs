using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class DialogSample : Dialog
    {
        [ObservableProperty]
        private string _data = "This is a dialog with no return and no parameter.";

        [RelayCommand]
        private void OnOk()
        {
            Accept();
        }
    }
}
