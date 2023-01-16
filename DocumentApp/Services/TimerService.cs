namespace DocumentApp.Services
{
    public class TimerService
    {
        public static TimeSpan currentTimerValue;
        public bool isStopWatchRunning = false;
        public string displayText = "";
        public TimeSpan timeLeft = new TimeSpan(0, 0, 10);

        public void AddMinute()
        {
            timeLeft = timeLeft.Add(new TimeSpan(0, 1, 0));
        }

        public async Task StartTimer()
        {
            while (timeLeft > new TimeSpan())
            {
                await Task.Delay(1000);
                timeLeft = timeLeft.Subtract(new TimeSpan(0, 0, 1));
            }
            await ShowTimeExpired();
        }

        public Task ShowTimeExpired()
        {
            displayText = "time expired";
            return Task.CompletedTask;
        }
    }
}
