using Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;

namespace Adita.PlexNet.Wpf.Dialogs.Samples.Views
{
    /// <summary>
    /// Interaction logic for DialogSamplePage.xaml
    /// </summary>
    public partial class DialogSamplePage : UserControl
    {
        public DialogSamplePage()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = App.Current.ServiceProvider.GetRequiredService<DialogSampleViewModel>();
            }
        }
    }
}
