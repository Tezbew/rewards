using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;
using Rewards.Storage.Profile.Controller;
using Rewards.Unity.UI.Panel.Menu.Information.ItemsList;
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

        [SerializeField]
        private ItemsListBase _itemsList;

        private readonly List<IListInformationList> _lists = new();

        public override event Action<LootBoxVersion> Selected;

        public override void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes, IProfileController profile)
        {
            _lootBoxList.Initialize(lootBoxes);
            _lootBoxList.Selected += BoxSelectedEventHandler;
            _resourcesList.Initialize(profile);
            _itemsList.Initialize(profile);

            _lists.Add(_lootBoxList);
            _lists.Add(_resourcesList);
            _lists.Add(_itemsList);

            _pages.ToggleActivated += ToggleActivatedEventHandler;
            _pages.Initialize();
        }

        public override void Dispose()
        {
            _pages.ToggleActivated -= ToggleActivatedEventHandler;
            _pages.Dispose();
            _lootBoxList.Selected -= BoxSelectedEventHandler;
            _lootBoxList.Dispose();
            _resourcesList.Dispose();
            _itemsList.Dispose();
        }

        public override void UpdateValues(IProfileController profile)
        {
            _resourcesList.UpdateValues(profile);
            _itemsList.UpdateValues(profile);
        }

        private void BoxSelectedEventHandler(LootBoxVersion box)
        {
            Selected?.Invoke(box);
        }

        private void ToggleActivatedEventHandler(int index)
        {
            for (var i = 0; i < _lists.Count; i++)
            {
                var page = _lists[i];
                if (i == index)
                {
                    page.Show();
                }
                else
                {
                    page.Hide();
                }
            }
        }
    }
}