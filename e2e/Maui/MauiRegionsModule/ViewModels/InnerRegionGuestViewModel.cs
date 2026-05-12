using MauiRegionsModule.Views;
using Prism.Mvvm;
using Prism.Navigation.Regions;

namespace MauiRegionsModule.ViewModels;

public class InnerRegionGuestViewModel : BindableBase, IRegionAware
{
    public bool IsNavigationTarget(NavigationContext navigationContext) =>
        navigationContext.NavigatedName() == nameof(InnerRegionGuestView);

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
    }
}
