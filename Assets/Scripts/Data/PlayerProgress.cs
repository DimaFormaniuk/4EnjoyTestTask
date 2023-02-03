using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public LifeData LifeData;
        public TimerData TimerData;
        public DailyBonusData DailyBonusData;
        
        public PlayerProgress()
        {
            LifeData = new LifeData();
            TimerData = new TimerData();
            DailyBonusData = new DailyBonusData();
        }
    }
}