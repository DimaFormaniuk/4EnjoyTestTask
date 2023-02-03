using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIUnityText : UIText
    {
        [SerializeField] private Text _text;

        public override string text
        {
            get => _text.text;
            set => _text.text = value;
        }
    }
}