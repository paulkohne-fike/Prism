using HelloWorld.Views;
using Playground.Module;
using Uno.UI;

namespace HelloWorld;

public partial class App : PrismApplication
{
    public App()
    {
        InitializeComponent();
    }

    protected override UIElement CreateShell()
    {
        return Container.Resolve<Shell>();
    }

    protected override void ConfigureHost(IHostBuilder builder)
    {
        builder
#if DEBUG
            .UseEnvironment(Environments.Development)
#endif
            .UseLogging(configure: (context, logBuilder) =>
            {
                logBuilder.SetMinimumLevel(
                    context.HostingEnvironment.IsDevelopment() ?
                        LogLevel.Information :
                        LogLevel.Warning);
            }, enableUnoLogging: true)
            .UseSerilog(consoleLoggingEnabled: true, fileLoggingEnabled: true)
            .UseSerialization()
            .ConfigureServices((context, services) =>
            {
            });
    }

    protected override void ConfigureWindow(Window window)
    {
#if DEBUG
        window.UseStudio();
#endif
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<PlaygroundModule>();
    }
}
