using System;
using Infrastructure.Services;

namespace Game.Services
{
    public interface ITimerService : IService
    {
        event Action UpdateTimer;
        string Time { get; }
    }
}