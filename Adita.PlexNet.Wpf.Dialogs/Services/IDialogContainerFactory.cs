using Adita.PlexNet.Core.Dialogs;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Provides a mechanism for creating a dialog container.
    /// </summary>
    public interface IDialogContainerFactory
    {
        #region Methods
        /// <summary>
        /// Creates a dialog container that contains specified <paramref name="dialog"/> with specified <paramref name="dialogTemplate"/> and <paramref name="containerStyle"/>.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <param name="dialog">A dialog as the content of the container.</param>
        /// <param name="dialogTemplate">A <see cref="DataTemplate"/> to use for specified <paramref name="dialog"/> view.</param>
        /// <param name="containerStyle">A <see cref="Style"/> to be used for the container.</param>
        /// <param name="owner">The owner of the dialog.</param>
        /// <returns>A <see cref="IDialogContainer"/>.</returns>
        IDialogContainer Create<TDialog>(TDialog dialog, DataTemplate dialogTemplate, Style containerStyle, Window owner) where TDialog : class, IDialog;
        /// <summary>
        /// Creates a dialog container that contains specified <paramref name="dialog"/> with specified <paramref name="dialogTemplate"/> and <paramref name="containerStyle"/>.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <param name="dialog">A dialog as the content of the container.</param>
        /// <param name="dialogTemplate">A <see cref="DataTemplate"/> to use for specified <paramref name="dialog"/>'s view.</param>
        /// <param name="containerStyle">A <see cref="Style"/> to be used for the container.</param>
        /// <param name="owner">The owner of the dialog.</param>
        /// <returns>An <see cref="IDialogContainer{TReturn}"/>.</returns>
        IDialogContainer<TReturn> Create<TDialog, TReturn>(TDialog dialog, DataTemplate dialogTemplate, Style containerStyle, Window owner) where TDialog : class, IDialog<TReturn>;
        /// <summary>
        /// Creates a dialog container that contains specified <paramref name="dialog"/> with specified <paramref name="dialogTemplate"/> and <paramref name="containerStyle"/>.
        /// </summary>
        /// <typeparam name="TDialog">The type used for the dialog.</typeparam>
        /// <typeparam name="TReturn">The type used for the return value.</typeparam>
        /// <typeparam name="TParam">The type used for the parameter.</typeparam>
        /// <param name="dialog">A dialog as the content of the container.</param>
        /// <param name="dialogTemplate">A <see cref="DataTemplate"/> to use for specified <paramref name="dialog"/>'s view.</param>
        /// <param name="containerStyle">A <see cref="Style"/> to be used for the container.</param>
        /// <param name="owner">The owner of the dialog.</param>
        /// <returns>An <see cref="IDialogContainer{TReturn, TParam}"/>.</returns>
        IDialogContainer<TReturn, TParam> Create<TDialog, TReturn, TParam>(TDialog dialog, DataTemplate dialogTemplate, Style containerStyle, Window owner) where TDialog : class, IDialog<TReturn, TParam>;
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
        Task<IDialogContainer<TReturn, TParam>> CreateAsync<TDialog, TReturn, TParam>(TDialog dialog,
            DataTemplate dialogTemplate,
            Style containerStyle,
            Window owner,
            SynchronizationContext factoryContext,
            CancellationToken cancellationToken = default) where TDialog : class, IDialog<TReturn, TParam>;

        #endregion Methods
    }
}
