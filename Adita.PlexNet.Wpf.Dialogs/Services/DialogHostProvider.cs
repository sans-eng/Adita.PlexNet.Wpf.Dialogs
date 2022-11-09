using Adita.PlexNet.Core.Dialogs;
using System.Linq;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog host provider.
    /// </summary>
    public class DialogHostProvider : IDialogHostProvider
    {
        #region Public methods
        /// <summary>
        /// Gets a dialog host of specified <typeparamref name="THost" /> type for specified <typeparamref name="TDialog" /> type.
        /// </summary>
        /// <typeparam name="THost">The type used for the dialog host.</typeparam>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A <typeparamref name="THost" /> as dialog host.</returns>
        public THost? GetHost<THost, TDialog>() where THost : class
        {
            return Application.Current?.Windows?.OfType<Window>().FirstOrDefault(x => x.IsActive) as THost;
        }
        #endregion Public methods
    }
}
