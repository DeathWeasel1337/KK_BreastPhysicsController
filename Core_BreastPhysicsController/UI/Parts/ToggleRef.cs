using BreastPhysicsController.UI.Util;
using UnityEngine;

namespace BreastPhysicsController.UI.Parts
{
    public class ToggleRef
    {
        private readonly string _text;

        public ToggleRef(string text)
        {
            _text = text;
        }

        public bool Draw(ref bool value, GUIStyle style = null)
        {
            if (style == null) style = new GUIStyle(Skin.defaultSkin.toggle);

            bool changed = false;

            bool newValue = GUILayout.Toggle(value, _text, style);
            if (newValue != value)
            {
                changed = true;
                value = newValue;
            }
            return changed;
        }
    }
}
