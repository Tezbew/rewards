using System.Linq;
using Rewards.Container;
using Rewards.LootBox.Factory;
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
        private ILootBoxFactory _lootBoxFactory;
        private IPanelOpener _opener;
        private MenuBase _menu;
        private IContainer _container;

        public override void Enter(IContainer container)
        {
            LogInfo(message: "Entered");
            _container = container;

            _lootBoxFactory = _container.Resolve<ILootBoxFactory>();

            _opener = _container.Resolve<IPanelOpener>();
            _menu = _opener.Open<MenuBase>();


            var lootBoxConfig = _container.Resolve<LootBoxCollectionConfigSO>();
            var lootBoxes = lootBoxConfig.Boxes
                                         .Select(b => b.Version)
                                         .ToArray();
            var profile = _container.Resolve<IProfileController>();
            _menu.Initialize(lootBoxes, profile);
            _menu.Selected += BoxSelectedEventHandler;
        }

        private void BoxSelectedEventHandler(LootBoxVersion box)
        {
            LogInfo($"Box selected {box.ToString()}");
            _lootBoxFactory.Create(box);
            _menu.Dispose();
            _menu = null;
        }

        private void LogInfo(string message)
        {
            Debug.Log($"[{nameof(LootBoxSceneEntryPoint)}] {message}");
        }
    }
}