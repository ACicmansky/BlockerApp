namespace BlockerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            #if ANDROID
            var intent = new Intent(Android.App.Application.Context, typeof(NetworkBlockerService));
            Android.App.Application.Context.StartService(intent);
            #endif
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            
            return new Window(new AppShell());
        }
    }
}