using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Wpf.Dialogs.Test.Models;
using Adita.PlexNet.Wpf.Test;
using System.Windows;
using System.Windows.Threading;

namespace Adita.PlexNet.Wpf.Dialogs.Test.Services
{
    [TestClass]
    public class DialogContainerFactoryTest
    {
        [STAThreadTestMethod]
        public void CanCreateContainer()
        {
            IDialogContainerFactory factory = new DialogContainerFactory();

            Window owner = Dispatcher.CurrentDispatcher.Invoke(() => owner = new());
            owner.Show();

            IDialogContainer container = factory.Create(new DialogDummy(), new DataTemplate(typeof(DialogDummy)),
                new Style(typeof(Window)), owner);

            Assert.IsNotNull(container);
        }

        [STAThreadTestMethod]
        public void CanCreateContainerWithReturn()
        {
            IDialogContainerFactory factory = new DialogContainerFactory();

            Window owner = Dispatcher.CurrentDispatcher.Invoke(() => owner = new());
            owner.Show();

            IDialogContainer<double?> container = factory.Create<DialogWithReturnDummy, double?>(new DialogWithReturnDummy(), new DataTemplate(typeof(DialogDummy)),
                new Style(typeof(Window)), owner);

            Assert.IsNotNull(container);
        }

        [STAThreadTestMethod]
        public void CanCreateContainerWithReturnAndParam()
        {
            IDialogContainerFactory factory = new DialogContainerFactory();

            Window owner = Dispatcher.CurrentDispatcher.Invoke(() => owner = new());
            owner.Show();

            IDialogContainer<double?, string> container = factory.Create<DialogWithReturnAndParamDummy, double?, string>(new DialogWithReturnAndParamDummy(), new DataTemplate(typeof(DialogDummy)),
                new Style(typeof(Window)), owner);

            Assert.IsNotNull(container);
        }
    }
}
