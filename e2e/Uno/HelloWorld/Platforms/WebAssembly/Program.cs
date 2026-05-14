using Uno.UI.Hosting;

namespace HelloWorld;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = UnoPlatformHostBuilder.Create()
            .App(() => new global::HelloWorld.App())
            .UseWebAssembly()
            .Build();

        await host.RunAsync();
    }
}