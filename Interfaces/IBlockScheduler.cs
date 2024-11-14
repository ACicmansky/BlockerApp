namespace BlockerApp.Interfaces
{
    public interface IBlockScheduler
    {
        void ScheduleBlockingTask(TimeSpan repeatInterval);
    }
} 