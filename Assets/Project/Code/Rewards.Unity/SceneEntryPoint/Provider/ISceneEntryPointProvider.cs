using UnityEngine;

namespace Rewards.Unity.SceneEntryPoint.Provider
{
    public interface ISceneEntryPointProvider
    {
        TEntryPoint Find<TEntryPoint>() where TEntryPoint : Component;
    }
}