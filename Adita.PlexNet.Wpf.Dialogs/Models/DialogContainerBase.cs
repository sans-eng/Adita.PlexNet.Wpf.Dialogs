using Adita.PlexNet.Core.Dialogs;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a base class for dialog container.
    /// </summary>
    public abstract class DialogContainerBase : Window
    {
        #region Protected methods
        /// <summary>
        /// Closes the dialog using specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">An <see cref="DialogAction"/> to close the dialog.</param>
        protected void CloseDialog(DialogAction action)
        {
            switch (action)
            {
                case DialogAction.None:
                    DialogResult = false;
                    break;
                case DialogAction.Accept:
                    DialogResult = true;
                    break;
                case DialogAction.Refuse:
                    DialogResult = false;
                    break;
                case DialogAction.Submit:
                    DialogResult = true;
                    break;
                case DialogAction.Cancel:
                case DialogAction.Ignore:
                case DialogAction.Abort:
                    DialogResult = false;
                    break;
            }
        }
        #endregion Protected methods
    }
}
