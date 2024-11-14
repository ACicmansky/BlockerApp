using Android.AccessibilityServices;
using Android.App;
using Android.Views.Accessibility;
using Android.Widget;

namespace BlockerApp.Platforms.Android
{
    [Service(Label = "AppBlockerService", Permission = "android.permission.BIND_ACCESSIBILITY_SERVICE")]
    public class AppBlockerService : AccessibilityService
    {
        private readonly HashSet<string> _blockedApps = ["com.youtube.android", "com.twitter.android"];

        public override void OnAccessibilityEvent(AccessibilityEvent? e)
        {
            if (e?.EventType == EventTypes.WindowStateChanged)
            {
                var packageName = e?.PackageName?.ToString();
                if (packageName != null && _blockedApps.Contains(packageName))
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    Toast.MakeText(this, $"Blocked {packageName}", ToastLength.Short).Show();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    PerformGlobalAction(GlobalAction.Back); // Go back to home screen
                }
            }
        }

        public override void OnInterrupt() { }
    }
}
