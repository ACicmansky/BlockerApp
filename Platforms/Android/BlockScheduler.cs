using AndroidX.Work;
using BlockerApp.Interfaces;

namespace BlockerApp.Platforms.Android
{
    public class BlockScheduler : IBlockScheduler
    {
        public void ScheduleBlockingTask(TimeSpan repeatInterval)
        {
            // Define constraints for the work request
            var constraints = new Constraints.Builder()
                .SetRequiredNetworkType(AndroidX.Work.NetworkType.Connected)
                .Build();

            // Create a periodic work request
            var blockWorkRequest = PeriodicWorkRequest.Builder
                .From<BlockWorker>(repeatInterval)
                .SetConstraints(constraints)
                .Build();

            // Enqueue the work request
            WorkManager
                .GetInstance(global::Android.App.Application.Context)
                .EnqueueUniquePeriodicWork(
                    "BlockWorker",
                    ExistingPeriodicWorkPolicy.Update,
                    blockWorkRequest
                );

            Console.WriteLine($"Scheduled blocking every {repeatInterval.TotalMinutes} minutes.");
        }
    }
}
