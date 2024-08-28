using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;
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

        private readonly List<IListInformationList> _lists = new();

        public override event Action<LootBoxVersion> Selected;

        public override void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes)
        {
            _lootBoxList.Initialize(lootBoxes);
            _lootBoxList.Selected += BoxSelectedEventHandler;
            _resourcesList.Initialize();

            _lists.Add(_lootBoxList);
            _lists.Add(_resourcesList);

            _pages.Initialize();
            _pages.ToggleActivated += ToggleActivatedEventHandler;
        }

        public override void Dispose()
        {
            _pages.ToggleActivated -= ToggleActivatedEventHandler;
            _pages.Dispose();
            _lootBoxList.Selected -= BoxSelectedEventHandler;
            _lootBoxList.Dispose();
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