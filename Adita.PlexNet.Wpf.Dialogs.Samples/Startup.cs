using Adita.PlexNet.Wpf.Dialogs.Samples.ViewModels;
using Adita.PlexNet.Wpf.Extensions.DependencyInjection;
using Adita.PlexNet.Wpf.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Adita.PlexNet.Wpf.Dialogs.Samples
{
    public static class Startup
    {
        [STAThread]
        public static void Main()
        {
            ApplicationBuilder<App> builder = new ApplicationBuilder<App>();
            builder.Services.AddDialogs(dialogBuilder =>
            {
                dialogBuilder.RegisterDialog<DialogSample>()
                .RegisterDialog<DialogWithReturnSample>()
                .RegisterDialog<DialogWithReturnAndParamSample>();
            })
                .AddSingleton<MainViewModel>()
                .AddSingleton<DialogSampleViewModel>();

            App app = builder.Build();
            app.InitializeComponent();
            app.Run();
        }
    }
}
