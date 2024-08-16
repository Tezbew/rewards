using JetBrains.Annotations;
using Rewards.Coroutine;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace Rewards.Unity.SceneLoader
{
    [UsedImplicitly]
    public class PlayerSceneLoader : SceneLoaderBase
    {
        public PlayerSceneLoader(ICoroutineManager coroutineManager) : base(coroutineManager)
        {
        }

        protected override AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode mode)
        {
            return SceneManager.LoadSceneAsync(sceneName, mode);
        }
    }
}