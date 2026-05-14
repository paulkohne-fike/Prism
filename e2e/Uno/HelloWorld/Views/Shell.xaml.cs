using Uno.Toolkit;

namespace HelloWorld.Views;

public sealed partial class Shell : Page, ILoadableShell
{
    private readonly CompositeLoadableSource _loadable;

    public Shell()
    {
        InitializeComponent();
        _loadable = new CompositeLoadableSource
        {
            IsExecuting = true
        };
        Splash.Source = _loadable;
    }

    public void FinishLoading()
    {
        _loadable.IsExecuting = false;
    }
}
