using System;

namespace Data
{
    [Serializable]
    public class TimerData
    {
        public long Tick;
        
        public TimerData()
        {
            Tick = 0;
        }
    }
}