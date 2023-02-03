using System;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;

namespace Game.Services
{
    public class LifeService : ILifeService
    {
        public event Action UpdateCountLife;
        public int CountLife { get; private set; }
        public bool IsMaxLife => CountLife == Constants.MaxLife;

        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LifeService(IPersistentProgressService progressService,ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;

            CountLife = _progressService.Progress.LifeData.Count;
        }

        public void RefillLives()
        {
            CountLife = Constants.MaxLife;

            UpdateCountLife?.Invoke();
            
            Save();
        }

        public void UseLife()
        {
            if (CountLife == 0)
                return;

            CountLife--;
            
            UpdateCountLife?.Invoke();
            
            Save();
        }

        public void AddLife()
        {
            if (CountLife == Constants.MaxLife)
                return;

            CountLife++;
            
            UpdateCountLife?.Invoke();
            
            Save();
        }

        private void Save()
        {
            _progressService.Progress.LifeData.Count = CountLife;
            
            _saveLoadService.SaveProgress();
        }
    }
}