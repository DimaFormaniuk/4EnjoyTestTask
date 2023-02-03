using System;
using Infrastructure.Services;

namespace Game.Services
{
    public interface ILifeService : IService
    {
        event Action UpdateCountLife;
        int CountLife { get; }
        bool IsMaxLife { get; }
        void RefillLives();
        void UseLife();
        void AddLife();
    }
}