using System.Linq;
using Rewards.Container;
using Rewards.LootBox.Version;
using Rewards.Storage.Profile.Controller;
using Rewards.UI.Management.Opener;
using Rewards.Unity.LootBox.Config.SO;
using Rewards.Unity.UI.Panel.Menu;
using UnityEngine;

namespace Rewards.Unity.SceneEntryPoint
{
    public class LootBoxSceneEntryPoint : SceneEntryPointBase
    {
        private IContainer _container;

        public override void Enter(IContainer container)
        {
            LogInfo(message: "Entered");
            _container = container;
            var opener = _container.Resolve<IPanelOpener>();
            var menu = opener.Open<MenuBase>();

            var lootBoxConfig = _container.Resolve<LootBoxCollectionConfigSO>();
            var lootBoxes = lootBoxConfig.Boxes
                                         .Select(b => b.Version)
                                         .ToArray();
            var profile = _container.Resolve<IProfileController>();
            menu.Initialize(lootBoxes, profile);
            menu.Selected += BoxSelectedEventHandler;
        }

        private void BoxSelectedEventHandler(LootBoxVersion box)
        {
            LogInfo($"Box selected {box.ToString()}");
        }

        private void LogInfo(string message)
        {
            Debug.Log($"[{nameof(LootBoxSceneEntryPoint)}] {message}");
        }
    }
}