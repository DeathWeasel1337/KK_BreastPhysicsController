using UnityEngine;

namespace BreastPhysicsController.UI.Parts
{
    public class SliderTextRef
    {
        private readonly string _text;
        private readonly float _sliderWidth;
        private readonly float _textWidth;
        private readonly float _height;
        private float _maxValue, _minValue;
        private float _oldValue;
        private string _textBuff;

        public SliderTextRef(string text, float minValue, float maxValue, float sliderWidth, float textWidth, float height = 0)
        {
            _text = text;
            _sliderWidth = sliderWidth;
            _textWidth = textWidth;
            _height = height;

            _maxValue = maxValue;
            _minValue = minValue;

            _oldValue = 0;
            _textBuff = _oldValue.ToString();
        }

        public void SetLimit(float min, float max)
        {
            _minValue = min;
            _maxValue = max;
        }

        public bool Draw(ref float value)
        {
            //detect changed value by other method.
            if (_oldValue != value) //if changed,textfield must be matched value.
            {
                _textBuff = value.ToString();
            }

            bool changed = false;

            GUILayout.BeginVertical();

            GUILayout.Label(_text);

            GUILayout.BeginHorizontal();

            float newValue = GUILayout.HorizontalSlider(value, _minValue, _maxValue, GUILayout.Width(_sliderWidth));

            if (value != newValue)
            {
                changed = true;
                value = newValue;
            }

            if (changed)
            {
                _textBuff = GUILayout.TextField(value.ToString(), GUILayout.Width(_textWidth));
            }
            else
            {
                GUI.SetNextControlName("TextField");
                _textBuff = GUILayout.TextField(_textBuff, GUILayout.Width(_textWidth));
                if (isPossibleParseFloat(_textBuff) && float.Parse(_textBuff) != value)
                {
                    changed = true;
                    value = Mathf.Clamp(float.Parse(_textBuff), _minValue, _maxValue);
                    _textBuff = value.ToString();
                }
                else if (GUI.GetNameOfFocusedControl() != "TextField")
                {
                    _textBuff = value.ToString();
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            _oldValue = value; //for detection changed value by other method.

            return changed;
        }

        private bool isPossibleParseFloat(string text)
        {
            float buff;
            if (float.TryParse(text, out buff)) return true;
            return false;
        }
    }
}
