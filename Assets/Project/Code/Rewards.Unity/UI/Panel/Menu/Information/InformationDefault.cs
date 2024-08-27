using Rewards.Unity.UI.Panel.Menu.Information.LootBoxList;
using Rewards.Unity.UI.Panel.Menu.Information.ResourcesList;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards.Unity.UI.Panel.Menu.Information
{
    public class InformationDefault : InformationBase
    {
        [SerializeField]
        private ToggleGroup _toggleGroup;

        [SerializeField]
        private LootBoxListBase _lootBoxList;

        [SerializeField]
        private ResourcesListBase _resourcesList;

        public override void Initialize()
        {
            _lootBoxList.Initialize();
            _resourcesList.Initialize();
        }
    }
}