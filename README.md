# MAUI-PlatformView
create a View that uses a native platform view such as Android.Widget.TextView, supports Windows, Android, IOS, and MACCATALYST,     class MyView : PlatformView&lt;...> ( public MyClass() : base(() => new ... ()  /* android provides static 'Context' for you to pass,  new ... (Context) */) {} } // page.Content = new MyView()
