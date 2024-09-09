using Rewards.Exceptions;
using Rewards.LootBox.Config;
using Rewards.LootBox.Version;
using Rewards.Unity.CreateMenu;
using Rewards.Unity.LootBox.View;
using UnityEngine;

namespace Rewards.Unity.LootBox.Config.SO
{
    [CreateAssetMenu(menuName = CreateMenuItems.ROOT + "/" + TYPE_NAME, fileName = TYPE_NAME)]
    public class LootBoxCollectionConfigSO : ScriptableObject
    {
        [SerializeField]
        private LootBoxConfig[] _boxes;

        [SerializeField]
        private LootBoxToView[] _views;

        private const string TYPE_NAME = nameof(LootBoxCollectionConfigSO);

        public LootBoxConfig[] Boxes => _boxes;

        public LootBoxConfig FindConfig(LootBoxVersion version)
        {
            foreach (var current in _boxes)
            {
                if (current.Version != version)
                {
                    continue;
                }

                return current;
            }

            throw new ElementNotFountException($"Can't find config for {version}");
        }

        public LootBoxViewBase FindView(LootBoxVersion version)
        {
            foreach (var currentView in _views)
            {
                if (currentView.Version != version)
                {
                    continue;
                }

                return currentView.View;
            }

            throw new ElementNotFountException($"Can't find view for {version}");
        }
    }
}