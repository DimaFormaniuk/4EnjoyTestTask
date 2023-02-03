using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class UITMP_Text : UIText
    {
        [SerializeField] private TMP_Text _text;

        public override string text
        {
            get => _text.text;
            set => _text.text = value;
        }
    }
}