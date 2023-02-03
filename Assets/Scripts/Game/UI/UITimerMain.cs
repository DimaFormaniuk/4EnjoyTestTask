namespace Game.UI
{
    public class UITimerMain : UITimer
    {
        private const string FullValueText = "Full";
        
        protected override void MaxLife()
        {
            Refresh();
        }

        private void Refresh()
        {
            _text.text = FullValueText;
        }
    }
}