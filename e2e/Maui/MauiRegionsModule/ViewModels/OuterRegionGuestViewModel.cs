using MauiRegionsModule;
using MauiRegionsModule.Views;
using Prism.Mvvm;
using Prism.Navigation.Regions;

namespace MauiRegionsModule.ViewModels;

/// <summary>
/// Outer region guest — navigates the inner region on arrival, matching the flow in the community sample
/// NestedRegionsNotInjectableOnAndroidIssue (R8MC).
/// </summary>
public class OuterRegionGuestViewModel : BindableBase, IRegionAware
{
    private readonly IRegionManager _regionManager;

    public OuterRegionGuestViewModel(IRegionManager regionManager) =>
        _regionManager = regionManager;

    public bool IsNavigationTarget(NavigationContext navigationContext) =>
        navigationContext.NavigatedName() == nameof(OuterRegionGuestView);

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public void OnNavigatedTo(NavigationContext navigationContext) =>
        _regionManager.RequestNavigate(NestedRegionNames.InnerRegion, nameof(InnerRegionGuestView));
}
