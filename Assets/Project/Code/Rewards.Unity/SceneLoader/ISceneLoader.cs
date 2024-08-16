using System;
using UnityEngine.SceneManagement;

namespace Rewards.Unity.SceneLoader
{
    public interface ISceneLoader : IDisposable
    {
        void LoadSceneAsync(string sceneName, LoadSceneMode loadMode, Action<bool> finished);
        void LoadActiveSceneAsync(string sceneName, LoadSceneMode loadMode, Action<bool> finished);
        void UnloadSceneAsync(string sceneName, Action<bool> finished);
    }
}