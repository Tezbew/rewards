using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rewards.Coroutine;
using Rewards.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rewards.Unity.SceneLoader
{
    public delegate IEnumerator AsyncLoadFunction(string sceneName, ulong coroutineTag);

    public abstract class SceneLoaderBase : ISceneLoader
    {
        private readonly ICoroutineManager _coroutineManager;
        private readonly Dictionary<ulong, Action<bool>> _activeLoads;

        protected SceneLoaderBase(ICoroutineManager coroutineManager)
        {
            _coroutineManager = coroutineManager;
            _activeLoads = new Dictionary<ulong, Action<bool>>();
        }

        public void LoadSceneAsync(string sceneName, Action<bool> finished)
        {
            LogInfo($"{nameof(LoadSceneAsync)}: {sceneName}");
            RunLoadAsync(sceneName, finished, GetLoadInactiveSceneCoroutine);
        }

        public void LoadActiveSceneAsync(string sceneName, Action<bool> finished)
        {
            LogInfo($"{nameof(LoadActiveSceneAsync)}: {sceneName}");
            RunLoadAsync(sceneName, finished, LoadSceneAdditiveRoutine);
        }

        public void UnloadSceneAsync(string sceneName, Action<bool> finished)
        {
            LogInfo($"{nameof(UnloadSceneAsync)}: {sceneName}");
            RunLoadAsync(sceneName, finished, UnloadSceneRoutine);
        }

        public void Dispose()
        {
            LogInfo(nameof(Dispose));
            for (var i = _activeLoads.Count - 1; i >= 0; i--)
            {
                var (coroutineTag, _) = _activeLoads.ElementAt(i);
                _coroutineManager.StopCoroutine(coroutineTag);
            }
        }

        protected abstract AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode mode);

        private void RunLoadAsync(string sceneName, Action<bool> finished, AsyncLoadFunction loadFunction)
        {
            var coroutineTag = _coroutineManager.GenerateNextID();
            _activeLoads.Add(coroutineTag, finished);
            var coroutine = loadFunction(sceneName, coroutineTag);
            _coroutineManager.StartCoroutine(coroutineTag, coroutine);
        }

        private IEnumerator GetLoadInactiveSceneCoroutine(string sceneName, ulong coroutineTag)
        {
            var awaiter = LoadSceneAdditiveAsync(sceneName);

            while (awaiter.isDone == false)
            {
                yield return default;
            }

            FinishLoadCoroutine(sceneName, coroutineTag, awaiter.isDone);
        }

        private IEnumerator LoadSceneAdditiveRoutine(string sceneName, ulong coroutineTag)
        {
            var awaiter = LoadSceneAdditiveAsync(sceneName);

            while (awaiter.isDone == false)
            {
                yield return default;
            }

            SetActiveScene(sceneName);
            FinishLoadCoroutine(sceneName, coroutineTag, awaiter.isDone);
        }

        private IEnumerator UnloadSceneRoutine(string sceneName, ulong coroutineTag)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            var awaiter = SceneManager.UnloadSceneAsync(scene)!;

            while (awaiter.isDone == false)
            {
                yield return default;
            }

            FinishLoadCoroutine(sceneName, coroutineTag, awaiter.isDone);
        }

        private AsyncOperation LoadSceneAdditiveAsync(string sceneName)
        {
            return LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private void FinishLoadCoroutine(string sceneName, ulong coroutineTag, bool result)
        {
            LogInfo($"Finishing load coroutine. Scene: {sceneName}, Result: {result}");

            _activeLoads[coroutineTag].Invoke(result);
            _activeLoads.Remove(coroutineTag);
        }

        private void SetActiveScene(string sceneName)
        {
            LogInfo($"Setting active scene: {sceneName}");
            var scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(scene);
        }

        private void LogInfo(string message)
        {
            Debug.Log($"[{GetType().Name}] {message}");
        }
    }
}