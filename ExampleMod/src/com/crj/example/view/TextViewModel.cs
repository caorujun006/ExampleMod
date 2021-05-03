using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.GauntletUI;
namespace ExampleMod.View
{
    public class TextViewModel : ViewModel
    {
        private TextObject _textObject;
        private string _text;
        private bool _isVisible;
        private HorizontalAlignment _horizontalAlignment;
       


        public TextObject TextObject
        {
            get => _textObject;
            set
            {
                _textObject = value;
                Text = _textObject.ToString();
            }
        }

        [DataSourceProperty]
        public string Text
        {
            get => _text;
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        [DataSourceProperty]
        public HorizontalAlignment HorizontalAlignment
        {
            get => _horizontalAlignment;
            set
            {
                if (_horizontalAlignment == value)
                    return;
                _horizontalAlignment = value;
                OnPropertyChanged(nameof(HorizontalAlignment));
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (_isVisible == value)
                    return;
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public TextViewModel(TextObject text, bool isVisible = true, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Right)
        {
            TextObject = text;
            IsVisible = isVisible;
            HorizontalAlignment = horizontalAlignment;
        }

        public override void RefreshValues()
        {
            
            base.RefreshValues();

            TextObject = TextObject;
        }
    }
}
