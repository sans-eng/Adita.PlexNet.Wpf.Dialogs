using Adita.PlexNet.Core.Dialogs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog container that has return value.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    public sealed class DialogContainer<TReturn> : DialogContainerBase, IDialogContainer<TReturn>
    {
        #region Private fields
        private IDialog<TReturn>? _contentContext;
        #endregion Private fields

        #region Public methods
        /// <summary>
        /// Opens a dialog and return the result after dialog is closed.
        /// </summary>
        /// <returns>A <see cref="DialogResult{T}" /> as a result of the dialog.</returns>
        /// <exception cref="InvalidOperationException">Context has not initialized.</exception>
        public new DialogResult<TReturn> ShowDialog()
        {
            Title = _contentContext?.Title;

            base.ShowDialog();
            return _contentContext != null
                ? _contentContext.DialogResult
                : throw new InvalidOperationException($"{nameof(_contentContext)} not set.");
        }

        /// <summary>
        /// Sets the host of type <typeparamref name="THost" /> to the dialog.
        /// </summary>
        /// <typeparam name="THost">The type used for the dialog.</typeparam>
        /// <param name="host">The host to set to.</param>
        public void SetHost<THost>(THost? host) where THost : class
        {
            Owner = host as Window;
        }

        /// <summary>
        /// Sets the content of the dialog using specified <paramref name="content" /> and its <paramref name="contentView" />.
        /// </summary>
        /// <typeparam name="TContent">The type used for the content.</typeparam>
        /// <typeparam name="TContentView">The type used for the view.</typeparam>
        /// <param name="content">The content to set.</param>
        /// <param name="contentView">The content view to set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> or <paramref name="contentView"/> is <c>null</c>.</exception>
        public void SetContent<TContent, TContentView>(TContent content, TContentView contentView)
            where TContent : class, IDialog<TReturn>
            where TContentView : class
        {
            if (contentView is null)
            {
                throw new ArgumentNullException(nameof(contentView));
            }

            _contentContext = content ?? throw new ArgumentNullException(nameof(content));
            content.RequestClosing += OnContentRequestClosing;

            if (contentView is DataTemplate dataTemplate)
            {
                Content = content;
                ContentTemplate = dataTemplate;
            }
            else
            {
                Content = contentView;
            }
        }
        #endregion Public methods

        #region Event handlers
        private void OnContentRequestClosing(object? sender, DialogRequestClosingEventArgs<TReturn> e)
        {
            if (sender is IDialog<TReturn> dialog)
            {
                dialog.RequestClosing -= OnContentRequestClosing;
            }
            CloseDialog(e.DialogResult.Action);
        }
        #endregion Event handlers
    }
}
