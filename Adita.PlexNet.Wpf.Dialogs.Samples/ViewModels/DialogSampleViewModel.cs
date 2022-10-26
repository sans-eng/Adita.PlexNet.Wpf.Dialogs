using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class DialogSampleViewModel
    {
        #region Private fields
        private readonly IDialogService _dialogService;
        [ObservableProperty]
        private string _dialogValue1 = string.Empty;
        [ObservableProperty]
        private string _dialogValue2 = string.Empty;
        [ObservableProperty]
        private string _parameter = string.Empty;
        #endregion Private fields

        public DialogSampleViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        [RelayCommand]
        private void ShowDialog()
        {
            _dialogService.ShowDialog<DialogSample>();
        }

        [RelayCommand]
        private void ShowDialogWithReturn()
        {
            DialogResult<string> result = _dialogService.ShowDialog<DialogWithReturnSample, string>();
            if (result.Action == DialogAction.Submit)
            {
                DialogValue1 = result.Value!;
            }
        }

        [RelayCommand]
        private void ShowDialogWithReturnAndParam()
        {
            DialogResult<string> result = _dialogService.ShowDialog<DialogWithReturnAndParamSample, string, string>(Parameter);
            if (result.Action == DialogAction.Submit)
            {
                DialogValue2 = result.Value!;
            }
        }
    }
}
