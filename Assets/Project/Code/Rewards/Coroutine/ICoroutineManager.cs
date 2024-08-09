using System.Collections;

namespace Rewards.Coroutine
{
    public interface ICoroutineManager
    {
        ulong GenerateNextID();
        void StartCoroutine(ulong id, IEnumerator enumerator);
        void StopCoroutine(ulong id);
    }
}