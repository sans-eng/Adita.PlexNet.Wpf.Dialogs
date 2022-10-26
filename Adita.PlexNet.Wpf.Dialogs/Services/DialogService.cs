using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Wpf.Dialogs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog service.
    /// </summary>
    public class DialogService : IDialogService
    {
        #region Private fields
        private readonly IDialogProvider _dialogProvider;
        private readonly IDialogContainerFactory _dialogContainerFactory;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogService"/> using specified <paramref name="dialogProvider"/>.
        /// </summary>
        /// <param name="dialogProvider">An <see cref="IDialogProvider"/> to retrieve the dialogs from.</param>
        /// <param name="factory">An <see cref="IDialogContainerFactory"/> to creates the container of a dialog.</param>
        public DialogService(IDialogProvider dialogProvider, IDialogContainerFactory factory)
        {
            _dialogProvider = dialogProvider;
            _dialogContainerFactory = factory;
        }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog" /> as dialog type and return the result.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <returns>A <see cref="DialogResult" /> of the dialog.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        public DialogResult ShowDialog<TDialog>() where TDialog : class, IDialog
        {
            IDialog? dialog = _dialogProvider.GetDialog<TDialog>();

            if (dialog == null)
            {
                throw new ArgumentException($"Specified {nameof(TDialog)} is not registered as dialog.");
            }

            DialogViewDescriptor? dialogView = DialogHost.GetDialogView<TDialog>();

            if (dialogView == null)
            {
                return new(DialogAction.None);
            }

            Window? owner = dialogView.GetOwner();

            if (owner?.IsActive != true)
            {
                return new(DialogAction.None);
            }

            IDialogContainer container = _dialogContainerFactory.Create(dialog, dialogView.ViewTemplate, dialogView.ContainerStyle, owner);

            return container.ShowDialog();
        }

        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog" /> as dialog type which has specified <typeparamref name="TReturn" /> of return type and return the result.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return type.</typeparam>
        /// <returns>A <see cref="DialogResult" /> of the dialog.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        public DialogResult<TReturn> ShowDialog<TDialog, TReturn>() where TDialog : class, IDialog<TReturn>
        {
            TDialog? dialog = (TDialog?)_dialogProvider.GetDialog<TDialog, TReturn>();

            if (dialog == null)
            {
                throw new ArgumentException($"Specified {nameof(TDialog)} is not registered as dialog.");
            }

            DialogViewDescriptor? dialogView = DialogHost.GetDialogView<TDialog>();

            if (dialogView == null)
            {
                return new(DialogAction.None);
            }

            Window? owner = dialogView.GetOwner();

            if (owner?.IsActive != true)
            {
                return new(DialogAction.None);
            }

            IDialogContainer<TReturn> container = _dialogContainerFactory.Create<TDialog, TReturn>(dialog, dialogView.ViewTemplate, dialogView.ContainerStyle, owner);

            return container.ShowDialog();
        }

        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog" /> as dialog type which has specified <typeparamref name="TReturn" /> of return type
        /// using specified <paramref name="parameter" /> and return the result.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return type.</typeparam>
        /// <typeparam name="TParam">The type used for the parameter type.</typeparam>
        /// <param name="parameter">The type used for the parameter type.</param>
        /// <exception cref="ArgumentException"><typeparamref name="TDialog"/> is not registered as dialog.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        public DialogResult<TReturn> ShowDialog<TDialog, TReturn, TParam>(TParam parameter) where TDialog : class, IDialog<TReturn, TParam>
        {
            TDialog? dialog = (TDialog?)_dialogProvider.GetDialog<TDialog, TReturn, TParam>();

            if (dialog == null)
            {
                throw new ArgumentException($"Specified {nameof(TDialog)} is not registered as dialog.");
            }

            if (EqualityComparer<TParam?>.Default.Equals(parameter, default))
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            DialogViewDescriptor? dialogView = DialogHost.GetDialogView<TDialog>();

            if (dialogView == null)
            {
                return new(DialogAction.None);
            }

            Window? owner = dialogView.GetOwner();

            if (owner?.IsActive != true)
            {
                return new(DialogAction.None);
            }

            IDialogContainer<TReturn, TParam> container = _dialogContainerFactory.Create<TDialog, TReturn, TParam>(dialog, dialogView.ViewTemplate, dialogView.ContainerStyle, owner);

            return container.ShowDialog(parameter);
        }

        /// <summary>
        /// Shows a dialog identified by <typeparamref name="TDialog" /> as dialog type which has specified <typeparamref name="TReturn" /> of return type
        /// using specified <paramref name="parameter" /> and return the result asynchronously.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return type.</typeparam>
        /// <typeparam name="TParam">The type used for the parameter type.</typeparam>
        /// <param name="parameter">The type used for the parameter type.</param>
        /// <param name="serviceContext">A <see cref="SynchronizationContext"/> to creates the dialog.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="Task" /> that represents an asynchronous operation which contains a <see cref="DialogResult" /> of the dialog.</returns>
        public async Task<DialogResult<TReturn>> ShowDialogAsync<TDialog, TReturn, TParam>(TParam parameter, SynchronizationContext serviceContext, CancellationToken cancellationToken = default) where TDialog : class, IDialog<TReturn, TParam>
        {
            TDialog? dialog = (TDialog?)_dialogProvider.GetDialog<TDialog, TReturn, TParam>();

            if (dialog == null)
            {
                throw new ArgumentException($"Specified {nameof(TDialog)} is not registered as dialog.");
            }

            if (EqualityComparer<TParam?>.Default.Equals(parameter, default))
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            DialogViewDescriptor? dialogView = DialogHost.GetDialogView<TDialog>();

            if (dialogView == null)
            {
                return new(DialogAction.None);
            }

            Window? owner = dialogView.GetOwner();

            if (owner?.IsActive != true)
            {
                return new(DialogAction.None);
            }

            IDialogContainer<TReturn, TParam> container =
               await _dialogContainerFactory.CreateAsync<TDialog, TReturn, TParam>(dialog, dialogView.ViewTemplate, dialogView.ContainerStyle, owner, serviceContext, cancellationToken);

            return await container.ShowDialogAsync(parameter);
        }

        #endregion Public methods
    }
}
