using Adita.PlexNet.Core.Dialogs;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog view provider.
    /// </summary>
    public class DialogViewProvider : IDialogViewProvider
    {
        #region Public methods
        /// <summary>
        /// Gets a dialog view which has type of <typeparamref name="TView" /> for specified <typeparamref name="TDialog" /> type.
        /// </summary>
        /// <typeparam name="TView">The type used for the dialog view.</typeparam>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A <typeparamref name="TView" /> as dialog view.</returns>
        public TView? GetView<TView, TDialog>() where TView : class
        {
            if (typeof(TView) == typeof(MessageView))
            {
                var view = new MessageView();
                return view as TView;
            }

            return DialogHost.GetDialogView<TDialog>() as TView;
        }
        #endregion Public methods
    }
}
