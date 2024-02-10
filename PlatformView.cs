public class PlatformView <P> : View
    where P :
#if WINDOWS
    Microsoft.UI.Xaml.FrameworkElement
#elif ANDROID
    Android.Views.View
#elif IOS || MACCATALYST
    UIKit.UIView
#endif
{

#if ANDROID
    public static Android.Content.Context Context => Android.App.Application.Context;
#endif

    public P NativeView => (P) Handler!.PlatformView!;

    class PM : PropertyMapper {}

    public PlatformView(Func<P> creator) {
        Handler = new PlatformViewHandler(creator, new PM());
    }

    class PlatformViewHandler : Microsoft.Maui.Handlers.ViewHandler<View, P> {
        Func<P> creator;
        public PlatformViewHandler(Func<P> creator, IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper) {
            this.creator = creator;
        }

        // called in SetVirtualView which is called by the setting the handler
        protected override P CreatePlatformView() => creator();
    }
}
