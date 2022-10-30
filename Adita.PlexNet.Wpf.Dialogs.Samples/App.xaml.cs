using Adita.PlexNet.Core.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs.Samples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IApplication
    {
        public IServiceProvider ServiceProvider { get; private set; } = default!;

        public IConfiguration Configuration { get; private set; } = default!;

        public static new App Current => (App)Application.Current;

        public void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
