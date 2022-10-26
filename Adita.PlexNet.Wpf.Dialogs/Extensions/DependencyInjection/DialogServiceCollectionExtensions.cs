using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Wpf.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Adita.PlexNet.Wpf.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides <see cref="IServiceCollection"/> extensions for dialog.
    /// </summary>
    public static class DialogServiceCollectionExtensions
    {
        /// <summary>
        /// Adds dialog environment to specified <paramref name="services"/> using specified <paramref name="builderAction"/> to register dialogs.
        /// </summary>
        /// <param name="services">An <see cref="IServiceCollection"/> to add the dialog environment to.</param>
        /// <param name="builderAction">An action to register dialogs.</param>
        /// <returns>An <see cref="IServiceCollection"/> to chain the operations.</returns>
        public static IServiceCollection AddDialogs(this IServiceCollection services, Action<IDialogBuilder> builderAction)
        {
            services.AddScoped<IDialogProvider, DialogProvider>()
                    .AddScoped<IDialogService, DialogService>()
                    .AddScoped<IDialogContainerFactory, DialogContainerFactory>();

            builderAction.Invoke(new DialogBuilder(services));

            return services;
        }
    }
}
