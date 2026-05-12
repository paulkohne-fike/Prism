using MauiRegionsModule;
using MauiRegionsModule.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;

namespace MauiRegionsModule.ViewModels;

/// <summary>View model for the nested regions playground page (GitHub #3332).</summary>
public class NestedRegionPageViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;

    public NestedRegionPageViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        NavigateNestedDemoCommand = new DelegateCommand(OnNavigateNestedDemo);
    }

    /// <summary>Navigates the outer region; the outer guest navigates the inner region when it loads (same pattern as community nested-region samples).</summary>
    public DelegateCommand NavigateNestedDemoCommand { get; }

    private void OnNavigateNestedDemo() =>
        _regionManager.RequestNavigate(NestedRegionNames.OuterRegion, nameof(OuterRegionGuestView));
}
