using Rewards.Container;
using Rewards.UI.Management.Opener;
using Rewards.Unity.UI.Panel.Menu;
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
            var opener = _container.Resolve<IPanelOpener>();
            var menu = opener.Open<MenuBase>();
            menu.Initialize();
        }
        
        private void LogInfo(string message)
        {
            Debug.Log($"[{nameof(LootBoxSceneEntryPoint)}] {message}");
        }
    }
}