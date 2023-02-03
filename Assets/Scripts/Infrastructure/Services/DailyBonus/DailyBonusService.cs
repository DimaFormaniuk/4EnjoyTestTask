using System;
using System.Collections.Generic;
using Data;
using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.Services.DailyBonus
{
    public class DailyBonusService : IDailyBonusService
    {
        private IPersistentProgressService _progressService;

        private List<int> _firstMonthOfSeason = new List<int>(4) { 12, 3, 6, 9 };
        private List<long> _bonuses = new List<long>(100) { 2, 3 };

        public DailyBonusService(IPersistentProgressService progressService)
        {
            _progressService = progressService;

            CalculateBonuses();
        }

        public bool CheckHaveBonus() =>
            _progressService.Progress.DailyBonusData.DateTime.RoundToDay() < DateTime.Now.RoundToDay();

        public void BonusCollected() =>
            _progressService.Progress.DailyBonusData.DateTime = DateTime.Now.RoundToDay();

        private void CalculateBonuses()
        {
            for (int i = 2; i < 100; i++)
            {
                float f = _bonuses[i - 1] * 0.6f;
                _bonuses.Add(_bonuses[i - 2] + (long)f);
            }

            //Debug.Log($"{string.Join(" ; ", _bonuses)}");
        }

        public long CalculateBonus()
        {
            DateTime date = DateTime.Now.RoundToDay();

            int countDay = date.Day;

            while (IsFirstMonth(date) == false)
            {
                date = date.AddMonths(-1);
                if (IsFirstMonth(date) == false)
                    countDay += DateTime.DaysInMonth(date.Year, date.Month);
            }
            
            return _bonuses[countDay];
        }

        private bool IsFirstMonth(DateTime date) =>
            _firstMonthOfSeason.Contains(date.Month);
    }
}