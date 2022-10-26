using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Wpf.Dialogs;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog container factory.
    /// </summary>
    public class DialogContainerFactory : IDialogContainerFactory
    {
        #region Public methods
        /// <summary>
        /// Creates a dialog container that contains specified <paramref name="dialog" /> with specified <paramref name="dialogTemplate" /> and <paramref name="containerStyle" />.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <param name="dialog">A dialog as the content of the container.</param>
        /// <param name="dialogTemplate">A <see cref="DataTemplate" /> to use for specified <paramref name="dialog" /> view.</param>
        /// <param name="containerStyle">A <see cref="Style" /> to be used for the container.</param>
        /// <param name="owner">The owner of the dialog.</param>
        /// <returns>An <see cref="IDialogContainer" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dialog"/>, <paramref name="dialogTemplate"/>, <paramref name="containerStyle"/>
        /// or <paramref name="owner"/> is <c>null</c>.</exception>
        public IDialogContainer Create<TDialog>(TDialog dialog, DataTemplate dialogTemplate, Style containerStyle, Window owner) where TDialog : class, IDialog
        {
            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogTemplate is null)
            {
                throw new ArgumentNullException(nameof(dialogTemplate));
            }

            if (containerStyle is null)
            {
                throw new ArgumentNullException(nameof(containerStyle));
            }

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            return new DialogContainer(dialog)
            {
                Owner = owner,
                Style = containerStyle,
                ContentTemplate = dialogTemplate,
                Content = dialog,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                SizeToContent = SizeToContent.WidthAndHeight
            };
        }

        /// <summary>
        /// Creates a dialog container that contains specified <paramref name="dialog" /> with specified <paramref name="dialogTemplate" /> and <paramref name="containerStyle" />.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <param name="dialog">A dialog as the content of the container.</param>
        /// <param name="dialogTemplate">A <see cref="DataTemplate" /> to use for specified <paramref name="dialog" />'s view.</param>
        /// <param name="containerStyle">A <see cref="Style" /> to be used for the container.</param>
        /// <param name="owner">The owner of the dialog.</param>
        /// <returns>An <see cref="IDialogContainer{TReturn}" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dialog"/>, <paramref name="dialogTemplate"/>, <paramref name="containerStyle"/>
        /// or <paramref name="owner"/> is <c>null</c>.</exception>
        public IDialogContainer<TReturn> Create<TDialog, TReturn>(TDialog dialog, DataTemplate dialogTemplate, Style containerStyle, Window owner) where TDialog : class, IDialog<TReturn>
        {
            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogTemplate is null)
            {
                throw new ArgumentNullException(nameof(dialogTemplate));
            }

            if (containerStyle is null)
            {
                throw new ArgumentNullException(nameof(containerStyle));
            }

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            return new DialogContainer<TReturn>(dialog)
            {
                Owner = owner,
                Style = containerStyle,
                ContentTemplate = dialogTemplate,
                Content = dialog,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                SizeToContent = SizeToContent.WidthAndHeight
            };
        }

        /// <summary>
        /// Creates a dialog container that contains specified <paramref name="dialog" /> with specified <paramref name="dialogTemplate" /> and <paramref name="containerStyle" />.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <typeparam name="TParam">The type used for the parameter.</typeparam>
        /// <param name="dialog">A dialog as the content of the container.</param>
        /// <param name="dialogTemplate">A <see cref="DataTemplate" /> to use for specified <paramref name="dialog" />'s view.</param>
        /// <param name="containerStyle">A <see cref="Style" /> to be used for the container.</param>
        /// <param name="owner">The owner of the dialog.</param>
        /// <returns>An <see cref="IDialogContainer{TReturn, TParam}" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dialog"/>, <paramref name="dialogTemplate"/>, <paramref name="containerStyle"/>
        /// or <paramref name="owner"/> is <c>null</c>.</exception>
        public IDialogContainer<TReturn, TParam> Create<TDialog, TReturn, TParam>(TDialog dialog, DataTemplate dialogTemplate, Style containerStyle, Window owner) where TDialog : class, IDialog<TReturn, TParam>
        {
            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogTemplate is null)
            {
                throw new ArgumentNullException(nameof(dialogTemplate));
            }

            if (containerStyle is null)
            {
                throw new ArgumentNullException(nameof(containerStyle));
            }

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            return new DialogContainer<TReturn, TParam>(dialog)
            {
                Owner = owner,
                Style = containerStyle,
                ContentTemplate = dialogTemplate,
                Content = dialog,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                SizeToContent = SizeToContent.WidthAndHeight
            };
        }

        /// <summary>
        /// Creates a dialog container that contains specified <paramref name="dialog"/> with specified <paramref name="dialogTemplate"/> and <paramref name="containerStyle"/> asynchronously.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <typeparam name="TParam">The type used for the parameter.</typeparam>
        /// <param name="dialog">A dialog as the content of the container.</param>
        /// <param name="dialogTemplate">A <see cref="DataTemplate"/> to use for specified <paramref name="dialog"/>'s view.</param>
        /// <param name="containerStyle">A <see cref="Style"/> to be used for the container.</param>
        /// <param name="owner">The owner of the dialog.</param>
        /// <param name="factoryContext">A <see cref="SynchronizationContext"/> to create the dialog container.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> that represents an aynchronous operation which contains a <see cref="IDialogContainer{TReturn, TParam}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dialog"/>, <paramref name="dialogTemplate"/>, <paramref name="containerStyle"/>
        /// or <paramref name="owner"/> is <c>null</c>.</exception>
        public async Task<IDialogContainer<TReturn, TParam>> CreateAsync<TDialog, TReturn, TParam>(TDialog dialog,
            DataTemplate dialogTemplate,
            Style containerStyle,
            Window owner,
            SynchronizationContext factoryContext,
            CancellationToken cancellationToken = default) where TDialog : class, IDialog<TReturn, TParam>
        {
            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (dialogTemplate is null)
            {
                throw new ArgumentNullException(nameof(dialogTemplate));
            }

            if (containerStyle is null)
            {
                throw new ArgumentNullException(nameof(containerStyle));
            }

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            cancellationToken.ThrowIfCancellationRequested();

            IDialogContainer<TReturn, TParam> container = default!;

            await Task.Run(() =>
            {
                factoryContext.Send(new SendOrPostCallback((_) =>
                {
                    container = new DialogContainer<TReturn, TParam>(dialog)
                    {
                        Owner = owner,
                        Style = containerStyle,
                        ContentTemplate = dialogTemplate,
                        Content = dialog,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner,
                        ResizeMode = ResizeMode.NoResize,
                        SizeToContent = SizeToContent.WidthAndHeight
                    };

                }), null);
            }, cancellationToken);

            return container;
        }
        #endregion Public methods
    }
}
