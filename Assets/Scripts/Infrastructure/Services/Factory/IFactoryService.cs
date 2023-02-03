using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public interface IFactoryService : IService, ICleanup
    {
        void Registered(IRegistered registered);
        GameObject CreateUIRoot();
        GameObject CreateMenu();
        GameObject CreateDailyBonus();
        void ClearRoot();
    }
}