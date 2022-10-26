using Adita.PlexNet.Core.Dialogs;
using System;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog container.
    /// </summary>
    public sealed class DialogContainer : DialogContainerBase, IDialogContainer
    {
        #region Private fields
        private readonly IDialog _content;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogContainer"/> using specified <paramref name="content"/>.
        /// </summary>
        /// <param name="content">An <see cref="IDialog"/> for the content.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public DialogContainer(IDialog content)
        {
            _content = content ?? throw new ArgumentNullException(nameof(content));
            content.RequestClosing += OnContentRequestClosing;
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Opens a dialog and return the result after dialog is closed.
        /// </summary>
        /// <returns>A <see cref="DialogResult" /> as a result of the dialog.</returns>
        public new DialogResult ShowDialog()
        {
            base.ShowDialog();
            return _content.DialogResult;
        }
        #endregion Public methods

        #region Event handlers
        private void OnContentRequestClosing(IDialog sender, DialogRequestClosingEventArgs e)
        {
            sender.RequestClosing -= OnContentRequestClosing;
            CloseDialog(e.DialogResult.Action);
        }
        #endregion Event handlers
    }
}
