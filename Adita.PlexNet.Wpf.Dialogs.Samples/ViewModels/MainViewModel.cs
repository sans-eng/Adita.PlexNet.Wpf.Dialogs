using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class MainViewModel
    {
        private readonly IDialogService _dialogService;
        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        [RelayCommand]
        private void ShowDialog()
        {
            _dialogService.ShowDialog<DialogSample>();
        }
    }
}
