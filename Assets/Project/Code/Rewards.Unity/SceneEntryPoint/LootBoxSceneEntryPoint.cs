using Rewards.Container;
using UnityEngine;

namespace Rewards.Unity.SceneEntryPoint
{
    public class LootBoxSceneEntryPoint : SceneEntryPointBase
    {
        private IContainer _container;

        public override void Enter(IContainer container)
        {
            LogInfo("Entered");
            _container = container;
        }
        
        private void LogInfo(string message)
        {
            Debug.Log($"[{nameof(LootBoxSceneEntryPoint)}] {message}");
        }
    }
}