namespace MauiRegionsModule.Views;

/// <summary>
/// Outer region guest with an inner <see cref="ContentView"/> region (GitHub #3332).
/// When this view receives a non-zero size, the inner host is invalidated so layout runs without page-level code-behind.
/// </summary>
public partial class OuterRegionGuestView : ContentView
{
    public OuterRegionGuestView()
    {
        InitializeComponent();
        SizeChanged += OnSizeChanged;
    }

    void OnSizeChanged(object? sender, EventArgs e)
    {
        if (Width <= 0 || Height <= 0)
            return;

        InnerRegionHostView.InvalidateMeasure();
    }
}
