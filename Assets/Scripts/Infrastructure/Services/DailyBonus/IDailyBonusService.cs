namespace Infrastructure.Services.DailyBonus
{
    public interface IDailyBonusService : IService
    {
        bool CheckHaveBonus();
        long CalculateBonus();
        void BonusCollected();
    }
}