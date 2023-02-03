using Game.Services;
using Infrastructure.Services;
using UnityEngine;

namespace Game.UI
{
    public abstract class UITimer : MonoBehaviour
    {
        [SerializeField] protected UIText _text;

        private ILifeService _lifeService;
        private ITimerService _timerService;

        private void Awake()
        {
            _lifeService = AllServices.Container.Single<ILifeService>();
            _timerService = AllServices.Container.Single<ITimerService>();

            Refresh();
        }

        private void OnEnable()
        {
            _lifeService.UpdateCountLife += OnUpdateCountLive;
            _timerService.UpdateTimer += OnUpdateTimer;
        }

        private void OnDisable()
        {
            _lifeService.UpdateCountLife -= OnUpdateCountLive;
            _timerService.UpdateTimer -= OnUpdateTimer;
        }

        private void OnUpdateCountLive()
        {
            Refresh();
        }

        private void OnUpdateTimer()
        {
            Refresh();
        }

        private void Refresh()
        {
            if (_lifeService.IsMaxLife)
                MaxLife();
            else
                RefreshTimerText();
        }

        protected abstract void MaxLife();

        protected virtual void RefreshTimerText()
        {
            _text.text = _timerService.Time;
        }
    }
}