using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class DialogSampleViewModel
    {
        #region Private fields
        private readonly IDialogService<DialogSample> _dialogService1;
        private readonly IDialogService<DialogWithReturnSample, string> _dialogService2;
        private readonly IDialogService<DialogWithReturnAndParamSample, string, string> _dialogService3;
        private readonly IParamOnlyDialogService<ParamOnlyDialogSample, string> _dialogService4;
        private readonly IParamOnlyDialogService<AsyncParamOnlyDialogSample, string> _dialogService5;
        private readonly IMessageDialogService _messageService;

        [ObservableProperty]
        private string _dialogValue1 = string.Empty;
        [ObservableProperty]
        private string _dialogValue2 = string.Empty;
        [ObservableProperty]
        private string _parameter = string.Empty;
        #endregion Private fields

        public DialogSampleViewModel(IDialogService<DialogSample> dialogService1,
            IDialogService<DialogWithReturnSample, string> dialogService2,
            IDialogService<DialogWithReturnAndParamSample, string, string> dialogService3,
            IMessageDialogService messageService,
            IParamOnlyDialogService<ParamOnlyDialogSample, string> dialogService4,
            IParamOnlyDialogService<AsyncParamOnlyDialogSample, string> dialogService5)
        {
            _dialogService1 = dialogService1;
            _dialogService2 = dialogService2;
            _dialogService3 = dialogService3;
            _messageService = messageService;
            _dialogService4 = dialogService4;
            _dialogService5 = dialogService5;
        }

        [RelayCommand]
        private void ShowMessage()
        {
          DialogResult result =  _messageService.ShowDialog("Information", "Information message!.",
                "This is message dialog, you can change the style and template by overriding it on application scope resource.",
                "This is the details", "This is the footer", MessageType.Information, MessageAction.YesNoCancel);
        }

        [RelayCommand]
        private void ShowDialog()
        {
            _dialogService1.ShowDialog();
        }

        [RelayCommand]
        private void ShowDialogWithReturn()
        {
            DialogResult<string> result = _dialogService2.ShowDialog();
            if (result.Action == DialogActionResult.Submit)
            {
                DialogValue1 = result.Value!;
            }
        }

        [RelayCommand]
        private void ShowDialogWithReturnAndParam()
        {
            DialogResult<string> result = _dialogService3.ShowDialog(Parameter);
            if (result.Action == DialogActionResult.Submit)
            {
                DialogValue2 = result.Value!;
            }
        }

        [RelayCommand]
        private void ShowParamOnly()
        {
            var result = _dialogService4.ShowDialog(_parameter);
        }

        [RelayCommand]
        private void ShowParamOnlyAsynchronous()
        {
            if (SynchronizationContext.Current == null)
            {
                throw new InvalidOperationException();
            }

            var result = _dialogService5.ShowDialog(_parameter);
        }
    }
}
