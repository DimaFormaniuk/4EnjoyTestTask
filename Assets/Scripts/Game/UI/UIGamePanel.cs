using Game.Services;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIGamePanel : MonoBehaviour
    {
        private const string ShowAnimation = "ShowPanel";
        private const string HideAnimation = "HidePanel";
        
        [SerializeField] private Animation _animation;
        
        [Header("Buttons")]
        [SerializeField] private Button _useLifeButton;
        [SerializeField] private Button _refillLivesButton;

        private ILifeService _lifeService;

        private void Awake()
        {
            _lifeService = AllServices.Container.Single<ILifeService>();

            Refresh();
        }

        private void OnEnable()
        {
            _lifeService.UpdateCountLife += OnUpdateCountLive;
            _useLifeButton.onClick.AddListener(OnClickUseLife);
            _refillLivesButton.onClick.AddListener(OnClickRefillLives);
        }

        private void OnDisable()
        {
            _lifeService.UpdateCountLife -= OnUpdateCountLive;
            _useLifeButton.onClick.RemoveListener(OnClickUseLife);
            _refillLivesButton.onClick.RemoveListener(OnClickRefillLives);
        }

        public void Show()
        {
            _animation.Play(ShowAnimation);
        }

        public void Hide()
        {
            _animation.Play(HideAnimation);
        }

        private void OnUpdateCountLive()
        {
            Refresh();
        }

        private void Refresh()
        {
            _refillLivesButton.gameObject.SetActive(!_lifeService.IsMaxLife);
            _useLifeButton.gameObject.SetActive(_lifeService.CountLife != 0);
        }

        private void OnClickRefillLives()
        {
            _lifeService.RefillLives();
        }

        private void OnClickUseLife()
        {
            _lifeService.UseLife();
        }
    }
}