using Prism.Commands;
using Prism.Dialogs;

namespace MauiModule.ViewModels;

public class ViewDViewModel : ViewModelBase
{
    public ViewDViewModel(BaseServices baseServices)
        : base(baseServices)
    {
        ShowDialogAsyncThenGoBackCommand = new DelegateCommand(
            OnShowDialogAsyncThenGoBack,
            () => !string.IsNullOrEmpty(SelectedDialog))
            .ObservesProperty(() => SelectedDialog);
    }

    /// <summary>GitHub #3395 — same continuation as <c>await ShowDialogAsync</c> then <c>await GoBackAsync</c>.</summary>
    public DelegateCommand ShowDialogAsyncThenGoBackCommand { get; }

    private async void OnShowDialogAsyncThenGoBack()
    {
        var name = SelectedDialog;
        if (string.IsNullOrEmpty(name))
            return;

        Messages.Add($"#3395: await ShowDialogAsync({name})…");
        var dialogResult = await _dialogs.ShowDialogAsync(name);
        Messages.Add($"#3395: dialog finished (Result={dialogResult.Result}). Awaiting GoBackAsync…");
        var navResult = await _navigationService.GoBackAsync();
        Messages.Add($"#3395: GoBackAsync Success={navResult.Success}.");
    }
}
