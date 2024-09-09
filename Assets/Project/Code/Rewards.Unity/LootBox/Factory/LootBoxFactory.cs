using Rewards.LootBox.Factory;
using Rewards.LootBox.Model;
using Rewards.LootBox.Version;
using Rewards.Unity.LootBox.Config.SO;
using UnityEngine;

namespace Rewards.Unity.LootBox.Factory
{
    public class LootBoxFactory : ILootBoxFactory
    {
        private readonly LootBoxCollectionConfigSO _config;

        public LootBoxFactory(LootBoxCollectionConfigSO config)
        {
            _config = config;
        }

        public ILootBoxModel Create(LootBoxVersion version)
        {
            var boxConfig = _config.FindConfig(version);
            var model = new LootBoxModel(boxConfig);

            var viewTemplate = _config.FindView(version);
            var view = Object.Instantiate(viewTemplate);
            view.Initialize(model);

            return model;
        }
    }
}