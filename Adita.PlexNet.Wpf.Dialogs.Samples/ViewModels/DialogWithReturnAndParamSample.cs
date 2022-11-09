using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class DialogWithReturnAndParamSample : Dialog<string, string>
    {
        [ObservableProperty]
        private string _parameter = string.Empty;
        [ObservableProperty]
        private string _return = string.Empty;

        public DialogWithReturnAndParamSample()
        {
            Title = nameof(DialogWithReturnAndParamSample);
        }

        [RelayCommand]
        private void OnSubmit()
        {
            Submit(_return);
        }
        [RelayCommand]
        private void OnCancel()
        {
            Cancel();
        }

        public override void Initialize(string parameter)
        {
            Parameter = parameter;
        }
    }
}
