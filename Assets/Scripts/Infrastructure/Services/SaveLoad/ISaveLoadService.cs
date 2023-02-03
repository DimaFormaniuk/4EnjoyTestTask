using System.Collections.Generic;
using Data;
using Infrastructure.Services.Factory;

namespace Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService, IRegistered
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
        void InformProgressReaders();
        void Cleanup();
        void Register(ISavedProgressReader progressReader);
    }
}