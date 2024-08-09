using System.Collections;
using System.Collections.Generic;
using Rewards.Coroutine;
using UnityEngine;
using UnityCoroutine = UnityEngine.Coroutine;

namespace Rewards.Unity.Coroutine.Manager
{
    public class CoroutineManager : MonoBehaviour, ICoroutineManager
    {
        private readonly Dictionary<ulong, UnityCoroutine> _coroutines;

        public ulong GenerateNextID()
        {
            return CoroutineIDGenerator.Next();
        }

        public void StartCoroutine(ulong id, IEnumerator enumerator)
        {
            var wrappedEnumerator = WrapEnumerator(id, enumerator);
            var coroutine = StartCoroutine(wrappedEnumerator);
            _coroutines.Add(id, coroutine);
        }

        public void StopCoroutine(ulong id)
        {
            RemoveCoroutine(id);
        }

        private IEnumerator WrapEnumerator(ulong id, IEnumerator enumerator)
        {
            yield return enumerator;

            RemoveCoroutine(id);
        }

        private void RemoveCoroutine(ulong id)
        {
            _coroutines.Remove(id);
        }
    }
}