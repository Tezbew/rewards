using Rewards.Unity.UI.Panel.Menu.Information.LootBoxList;
using Rewards.Unity.UI.Panel.Menu.Information.Pages;
using Rewards.Unity.UI.Panel.Menu.Information.ResourcesList;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information
{
    public class InformationDefault : InformationBase
    {
        [SerializeField]
        private PagesBase _pages;

        [SerializeField]
        private LootBoxListBase _lootBoxList;

        [SerializeField]
        private ResourcesListBase _resourcesList;

        public override void Initialize()
        {
            _lootBoxList.Initialize();
            _resourcesList.Initialize();
            _pages.Initialize();
            _pages.ToggleActivated += ToggleActivatedEventHandler;
        }

        public override void Dispose()
        {
            _pages.ToggleActivated -= ToggleActivatedEventHandler;
            _pages.Dispose();
        }

        private void ToggleActivatedEventHandler(int index)
        {
            if (index == 0)
            {
                _lootBoxList.Show();
                _resourcesList.Hide();
            }
            else
            {
                _lootBoxList.Hide();
                _resourcesList.Show();
            }
        }
    }
}