namespace DocumentApp.Services
{
    public class TimerService
    {
        public string displayText = "";
        public TimeSpan timeLeft = new TimeSpan(0, 0, 10);
        public delegate void RefreshActionDelegate();
        public RefreshActionDelegate RefreshAction;
        public bool isStarted;

        public void AddMinute()
        {
            timeLeft = timeLeft.Add(new TimeSpan(0, 1, 0));
        }

        public async Task StartTimer()
        {
            isStarted = true;
            displayText = "";

            while (timeLeft > new TimeSpan(0, 0, 0))
            {
                await Task.Delay(1000);
                timeLeft = timeLeft.Subtract(new TimeSpan(0, 0, 1));
                RefreshAction();
            }
            await ShowTimeExpired();
        }

        public Task ShowTimeExpired()
        {
            displayText = "time expired";
            isStarted= false;
            return Task.CompletedTask;
        }
    }
}
