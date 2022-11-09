using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class AsyncParamOnlyDialogSample : ParamOnlyDialog<string>
    {
        [ObservableProperty]
        private string _param = string.Empty;

        public AsyncParamOnlyDialogSample()
        {
            Title = nameof(AsyncParamOnlyDialogSample);
        }

        public override async Task InitializeAsync(string parameter)
        {
            await Task.Delay(3000);
            Param = parameter;
        }
    }
}
