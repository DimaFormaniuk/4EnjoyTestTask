using System.Collections;
using Infrastructure.Services;
using Infrastructure.Services.DailyBonus;
using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIDailyBonusPanel : MonoBehaviour
    {
        private const string ShowAnimation = "ShowPanel";
        private const string HideAnimation = "HidePanel";
    
        [SerializeField] private Animation _animation;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _collectButton;
        
        private IDailyBonusService _service;

        private void Awake()
        {
            _service = AllServices.Container.Single<IDailyBonusService>();

            Refresh();
        }
    
        public void Show()
        {
            _animation.Play(ShowAnimation);
        }

        public void Hide()
        {
            _animation.Play(HideAnimation);
        }

        private void OnEnable()
        {
            _collectButton.onClick.AddListener(OnClickCollect);
        }

        private void OnDisable()
        {
            _collectButton.onClick.RemoveListener(OnClickCollect);
        }

        private void OnClickCollect()
        {
            Hide();
            
            _service.BonusCollected();
            
            StartCoroutine(WaitAnimationEnd());
        }

        private void Refresh()
        {
            _text.text = $"{_service.CalculateBonus()}";
        }

        private IEnumerator WaitAnimationEnd()
        {
            yield return new WaitForSeconds(1f);
            
            while (_animation.isPlaying)
            {
                yield return new WaitForSeconds(1f);
            }
            
            Destroy(this.gameObject);
        }
    }
}
