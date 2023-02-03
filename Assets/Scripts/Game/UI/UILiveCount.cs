using Game.Services;
using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class UILiveCount : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private ILifeService _lifeService;

        private void Awake()
        {
           _lifeService = AllServices.Container.Single<ILifeService>();

           Refresh();
        }

        private void OnEnable()
        {
            _lifeService.UpdateCountLife += OnUpdateCountLive;
        }

        private void OnDisable()
        {
            _lifeService.UpdateCountLife -= OnUpdateCountLive;
        }

        private void OnUpdateCountLive()
        {
            Refresh();
        }
        
        private void Refresh()
        {
            _text.text = $"{_lifeService.CountLife}";
        }
    }
}
