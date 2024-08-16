using System;

namespace Rewards.SceneLoader
{
    public interface ISceneLoader : IDisposable
    {
        void LoadSceneAsync(string sceneName, Action<bool> finished);
        void LoadActiveSceneAsync(string sceneName, Action<bool> finished);
        void UnloadSceneAsync(string sceneName, Action<bool> finished);
    }
}