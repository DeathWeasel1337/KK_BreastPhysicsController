namespace BreastPhysicsController.UI.Util
{
    public static class WindowID
    {
        private static int _nextId = 10000;

        public static int GetNewID()
        {
            return _nextId++;
        }
    }
}
