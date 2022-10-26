using Adita.PlexNet.Core.Dialogs;
using System;
using System.Threading.Tasks;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog container that returns a value and has parameter.
    /// </summary>
    /// <typeparam name="TReturn">The type used for the return value.</typeparam>
    /// <typeparam name="TParam">The type used for the parameter.</typeparam>
    public sealed class DialogContainer<TReturn, TParam> : DialogContainerBase, IDialogContainer<TReturn, TParam>
    {
        #region Private fields
        private IDialog<TReturn, TParam> _content;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogContainer"/> using specified <paramref name="content"/>.
        /// </summary>
        /// <param name="content">An <see cref="IDialog{TReturn}"/> for the content.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public DialogContainer(IDialog<TReturn, TParam> content)
        {
            _content = content ?? throw new ArgumentNullException(nameof(content));
            content.RequestClosing += OnContentRequestClosing;
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Opens a dialog using specified <paramref name="param" /> and return the result after dialog is closed.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="DialogResult{T}" /> as a result of the dialog.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        public DialogResult<TReturn> ShowDialog(TParam param)
        {
            if (param == null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            _content.Initialize(param);

            ShowDialog();
            return _content.DialogResult;
        }

        /// <summary>
        /// Opens a dialog using specified <paramref name="param" /> and return the result after dialog is closed asynchronously.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="Task" /> that represents an asynchronous operation which contans a <see cref="DialogResult{T}" /> as a result of the dialog.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        public async Task<DialogResult<TReturn>> ShowDialogAsync(TParam param)
        {
            if (param == null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            await _content.InitializeAsync(param);

            Dispatcher.Invoke(() => ShowDialog());
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
