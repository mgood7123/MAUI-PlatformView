# MAUI-PlatformView
create a View that uses a native platform view such as Android.Widget.TextView, supports Windows, Android, IOS, and MACCATALYST

usage:

```cs
    public partial class App : Application {
        public App() {
            InitializeComponent();
            ContentPage contentPage = new();
            contentPage.Content = new Host() {
                Text = "Hello"
            };
            MainPage = contentPage;
        }
    }

#if WINDOWS
    public class Host : PlatformView<Microsoft.UI.Xaml.Controls.TextBlock> {
        public Host() : base(() => new Microsoft.UI.Xaml.Controls.TextBlock()) {}
#elif ANDROID
    public class Host : PlatformView<Android.Widget.TextView> {
        // Android:
        // PlatformView {
        //   public static Android.Content.Context Context => Android.App.Application.Context;
        //   ...
        // }
        //
        public Host() : base(() => new Android.Widget.TextView(Context)) {}
#elif IOS || MACCATALYST
    public class Host : PlatformView<UIKit.UILabel> {
        public Host() : base(() => new UIKit.UILabel()) {}
#endif
    public string? Text {
            get => NativeView.Text;
            set {
                NativeView.Text = value ?? "";
            }
        }
    }

}
```
