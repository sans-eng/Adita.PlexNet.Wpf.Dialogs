using Adita.PlexNet.Core.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows;

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
        private IDialog<TReturn, TParam>? _contentContext;
        private TParam? _parameter;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogContainer{TReturn, TParam}"/>.
        /// </summary>
        public DialogContainer()
        {
            Loaded += OnLoaded;
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Opens a dialog using specified <paramref name="param" /> and return the result after dialog is closed.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="DialogResult{T}" /> as a result of the dialog.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Context has not initialized.</exception>
        public DialogResult<TReturn> ShowDialog(TParam param)
        {
            if (param == null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            if (_contentContext == null)
                throw new InvalidOperationException($"{nameof(_contentContext)} not set.");

            _parameter = param;
            _contentContext.Initialize(param);
            Title = _contentContext.Title;

            ShowDialog();
            return _contentContext.DialogResult;
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
            where TContent : class, IDialog<TReturn, TParam>
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
            if (sender is IDialog<TReturn, TParam> dialog)
            {
                dialog.RequestClosing -= OnContentRequestClosing;
            }
            CloseDialog(e.DialogResult.Action);
        }
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
           if(_parameter != null && _contentContext != null)
            {
               await _contentContext.InitializeAsync(_parameter);
            }
        }
        #endregion Event handlers
    }
}
