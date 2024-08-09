namespace Rewards.Unity.Coroutine.Manager
{
    public static class CoroutineIDGenerator
    {
        private static ulong _lastID;

        public static ulong Next()
        {
            return ++_lastID;
        }
    }
}