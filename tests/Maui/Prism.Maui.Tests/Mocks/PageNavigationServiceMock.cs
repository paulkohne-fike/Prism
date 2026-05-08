#nullable enable
using Microsoft.Maui.Controls;
using Prism.Events;
using Prism.Maui.Tests.Navigation;
using Prism.Navigation;

namespace Prism.Maui.Tests.Mocks;

public sealed class PageNavigationServiceMock : PageNavigationService, IPageAware
{
    public PageNavigationServiceMock(PageNavigationContainerMock container, ApplicationMock app, PageNavigationEventRecorder? recorder = null)
        : base(container, new TestWindowManager(app.Window), new EventAggregator(), new MutablePageAccessor())
    {
        _ = recorder;
    }

    Page IPageAware.Page
    {
        get => ((MutablePageAccessor)_pageAccessor).Page;
        set => ((MutablePageAccessor)_pageAccessor).Page = value;
    }
}
