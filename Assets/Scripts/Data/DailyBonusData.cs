using System;

namespace Data
{
    [Serializable]
    public class DailyBonusData
    {
        public DateTime DateTime;

        public DailyBonusData()
        {
            DateTime = DateTime.Now.AddDays(-1);
        }
    }
}