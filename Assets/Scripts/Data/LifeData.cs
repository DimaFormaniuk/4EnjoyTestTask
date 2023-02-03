using System;

namespace Data
{
    [Serializable]
    public class LifeData
    {
        public int Count;

        public LifeData()
        {
            Count = Constants.MaxLife;
        }
    }
}