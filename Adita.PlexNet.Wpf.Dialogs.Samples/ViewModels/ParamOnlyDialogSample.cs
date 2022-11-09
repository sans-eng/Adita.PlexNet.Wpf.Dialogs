using Adita.PlexNet.Core.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels
{
    [ObservableObject]
    public partial class ParamOnlyDialogSample : ParamOnlyDialog<string>
    {
        [ObservableProperty]
        private string _param = string.Empty;

        public ParamOnlyDialogSample()
        {
            Title = nameof(ParamOnlyDialogSample);
        }

        public override void Initialize(string parameter)
        {
            _param = parameter;
        }
    }
}
