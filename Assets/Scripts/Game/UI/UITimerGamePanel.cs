using UnityEngine;

namespace Game.UI
{
    public class UITimerGamePanel : UITimer
    {
        [SerializeField] private GameObject _parentTimer;
        protected override void MaxLife()
        {
            _parentTimer.SetActive(false);
        }

        protected override void RefreshTimerText()
        {
            base.RefreshTimerText();
            
            _parentTimer.SetActive(true);
        }
    }
}