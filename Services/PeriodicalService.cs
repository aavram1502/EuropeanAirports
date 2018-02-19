using System;
using System.Threading.Tasks;

namespace Services
{
    public class PeriodicalService : IPeriodicalService
    {
        public async Task RunPeriodically(Action action, TimeSpan interval)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    action();
                    await Task.Delay(interval);
                }
            });
        }
    }
}
