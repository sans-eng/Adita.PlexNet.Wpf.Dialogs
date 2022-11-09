using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Wpf.Dialogs;
using Adita.PlexNet.Wpf.Dialogs.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Adita.PlexNet.Wpf.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides <see cref="IServiceCollection"/> extensions for dialog.
    /// </summary>
    public static class DialogServiceCollectionExtensions
    {
        #region Public methods
        /// <summary>
        /// Adds dialog environment to specified <paramref name="services"/> using specified <paramref name="builderAction"/> to register dialogs.
        /// </summary>
        /// <param name="services">An <see cref="IServiceCollection"/> to add the dialog environment to.</param>
        /// <param name="builderAction">An action to register dialogs.</param>
        /// <returns>An <see cref="IServiceCollection"/> to chain the operations.</returns>
        public static IServiceCollection AddDialogs(this IServiceCollection services, Action<DialogBuilder> builderAction)
        {
            DialogBuilder builder = new(services);
            builder.AddDialogHostProvider<DialogHostProvider>()
            .AddDialogViewProvider<DialogViewProvider>()
            .AddMessageService()
            .ConfigureDialogOptions(configure =>
            {
                configure.ContainerStandardType = typeof(DialogContainer);
                configure.ContainerWithReturnType = typeof(DialogContainer<>);
                configure.ContainerWithReturnAndParamType = typeof(DialogContainer<,>);
                configure.ContainerOnlyParamType = typeof(ParamOnlyDialogContainer<>);
                configure.HostType = typeof(Window);
                configure.ViewType = typeof(DataTemplate);
                configure.MessageViewType = typeof(MessageView);
            });

            builderAction.Invoke(builder);

            return builder.Build().Services;
        }
        #endregion Public methods
    }
}
