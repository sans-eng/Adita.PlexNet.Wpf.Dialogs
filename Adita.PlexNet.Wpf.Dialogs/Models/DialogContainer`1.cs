using Adita.PlexNet.Core.Dialogs;
using System;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog container that has return value.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    public sealed class DialogContainer<TReturn> : DialogContainerBase, IDialogContainer<TReturn>
    {
        #region Private fields
        private IDialog<TReturn> _content;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogContainer"/> using specified <paramref name="content"/>.
        /// </summary>
        /// <param name="content">An <see cref="IDialog{TReturn}"/> for the content.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public DialogContainer(IDialog<TReturn> content)
        {
            _content = content ?? throw new ArgumentNullException(nameof(content));
            content.RequestClosing += OnContentRequestClosing;
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Opens a dialog and return the result after dialog is closed.
        /// </summary>
        /// <returns>A <see cref="DialogResult{T}" /> as a result of the dialog.</returns>
        public new DialogResult<TReturn> ShowDialog()
        {
            base.ShowDialog();
            return _content.DialogResult;
        }
        #endregion Public methods

        #region Event handlers
        private void OnContentRequestClosing(IDialog<TReturn> sender, DialogRequestClosingEventArgs<TReturn> e)
        {
            sender.RequestClosing -= OnContentRequestClosing;
            CloseDialog(e.DialogResult.Action);
        }
        #endregion Event handlers
    }
}
