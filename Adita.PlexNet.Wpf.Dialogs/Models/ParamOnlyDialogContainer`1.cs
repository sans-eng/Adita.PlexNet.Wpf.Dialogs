using Adita.PlexNet.Core.Dialogs;
using System;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog container that has paramater and no return value.
    /// </summary>
    /// <typeparam name="TParam">The type used for the parameter.</typeparam>
    public sealed class ParamOnlyDialogContainer<TParam> : DialogContainerBase, IParamOnlyDialogContainer<TParam>
    {
        #region Private fields
        private IParamOnlyDialog<TParam>? _contentContext;
        private TParam? _parameter;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="ParamOnlyDialogContainer{TParam}"/>.
        /// </summary>
        public ParamOnlyDialogContainer()
        {
            Loaded += OnLoaded;
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Opens a dialog using specified <paramref name="param" /> and return the result after dialog is closed.
        /// </summary>
        /// <param name="param">A parameter to be used for initializing the dialog.</param>
        /// <returns>A <see cref="DialogResult" /> as a result of the dialog.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Context has not initialized.</exception>
        public DialogResult ShowDialog(TParam param)
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
            where TContent : class, IParamOnlyDialog<TParam>
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
        private void OnContentRequestClosing(object? sender, DialogRequestClosingEventArgs e)
        {
            if (sender is IParamOnlyDialog<TParam> dialog)
            {
                dialog.RequestClosing -= OnContentRequestClosing;
            }
            CloseDialog(e.DialogResult.Action);
        }
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_parameter != null && _contentContext != null)
            {
                await _contentContext.InitializeAsync(_parameter);
            }
        }
        #endregion Event handlers
    }
}
