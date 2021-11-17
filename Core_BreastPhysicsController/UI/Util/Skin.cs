using UnityEngine;

namespace BreastPhysicsController.UI.Util
{
    public static class Skin
    {
        public static GUISkin defaultSkin;

        static Skin()
        {
            defaultSkin = GetDefaultSkin();
        }

        private static GUISkin GetDefaultSkin()
        {
            return GUIUtility.GetDefaultSkin();
        }
    }
}
