using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class DialogWithReturnSample : Dialog<string>
    {
        [ObservableProperty]
        private string _data = string.Empty;

        public DialogWithReturnSample()
        {
            Title = nameof(DialogWithReturnSample);
        }

        [RelayCommand]
        private void OnSubmit()
        {
            Submit(_data);
        }
        [RelayCommand]
        private void OnCancel()
        {
            Cancel();
        }
    }
}
