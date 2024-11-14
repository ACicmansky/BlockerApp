using BlockerApp.Interfaces;

namespace BlockerApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnScheduleBlockingClicked(object sender, EventArgs e)
        {
            var scheduler = IPlatformApplication.Current.Services.GetService<IBlockScheduler>();
            scheduler.ScheduleBlockingTask(TimeSpan.FromMinutes(60));
            DisplayAlert("Scheduled", "Blocking has been scheduled every hour", "OK");
        }
    }
}
