using card_manager_ui.Services;
using card_manager_ui.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Windows;
using System.Xml.Linq;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace PasswordBoxMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<RegisterViewModel>();
                    services.AddSingleton<DeleteViewModel>();
                    services.AddSingleton<SearchViewModel>();

                    services.AddTransient<IDataService, DataHttpClient>();

                    var connectionString = ConfigurationManager.ConnectionStrings["microservice"];
                    services.AddHttpClient<IDataService, DataHttpClient>((client, sp) =>
                    {
                        return new DataHttpClient(connectionString.ConnectionString, client);
                    }).SetHandlerLifetime(TimeSpan.FromMinutes(2));


                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            MainWindow = AppHost.Services.GetService<MainWindow>();
            MainWindow.DataContext = AppHost.Services.GetService<SearchViewModel>();

            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}
