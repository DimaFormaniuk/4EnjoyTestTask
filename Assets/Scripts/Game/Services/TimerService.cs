using System;
using Data;
using Infrastructure;
using Infrastructure.Services.PersistentProgress;

namespace Game.Services
{
    public class TimerService : ITimerService
    {
        private const int TimerIntervalSeconds = 1;

        public event Action UpdateTimer;

        private readonly IPersistentProgressService _progressService;
        private readonly ILifeService _lifeService;
        private readonly CoroutineUpdate _coroutineUpdate;

        private long _tick;

        public TimerService(IPersistentProgressService progressService, ILifeService lifeService,
            ICoroutineRunner coroutineRunner)
        {
            _progressService = progressService;
            _lifeService = lifeService;

            _tick = _progressService.Progress.TimerData.Tick;
            _coroutineUpdate = new CoroutineUpdate(coroutineRunner, TimerIntervalSeconds);

            Subscribe();

            CheckTimer();
        }

        public string Time => _tick.ConvertToTime();

        private void CheckTimer()
        {
            if (_lifeService.IsMaxLife == false)
                StartTimer();
            else
                _tick = 0;
        }

        private void Subscribe()
        {
            _lifeService.UpdateCountLife += OnUpdateCountLive;
            _coroutineUpdate.Update += OnUpdateCoroutine;
        }

        private void Unsubscribe()
        {
            _lifeService.UpdateCountLife -= OnUpdateCountLive;
            _coroutineUpdate.Update -= OnUpdateCoroutine;
        }

        private void OnUpdateCountLive()
        {
            CheckTimer();
        }

        private void OnUpdateCoroutine()
        {
            _tick -= TimeSpan.TicksPerSecond;

            if (_tick <= 0)
            {
                StopTimer();

                _lifeService.AddLife();
            }

            Save();

            UpdateTimer?.Invoke();
        }

        private void StartTimer()
        {
            if (_tick == 0)
                _tick = Constants.TimerStartValue * TimeSpan.TicksPerSecond;
            
            _coroutineUpdate.StartTimer();
            UpdateTimer?.Invoke();
        }

        private void StopTimer()
        {
            _tick = 0;
            _coroutineUpdate.StopTimer();
        }

        private void Save()
        {
            _progressService.Progress.TimerData.Tick = _tick;
        }

        ~TimerService()
        {
            Unsubscribe();
        }
    }
}