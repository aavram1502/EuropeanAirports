using System;
using System.Threading.Tasks;

namespace Services
{
    public interface IPeriodicalService
    {
        Task RunPeriodically(Action action, TimeSpan interval);
    }
}