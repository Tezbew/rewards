using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;
using Rewards.Unity.UI.Panel.Menu.Information.LootBoxList.Entry;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.LootBoxList
{
    public class LootBoxListDefault : LootBoxListBase
    {
        [SerializeField]
        private LootBoxEntryBase _template;

        private readonly List<LootBoxEntryBase> _entries = new();

        public override event Action<LootBoxVersion> Selected;

        public override void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes)
        {
            foreach (var box in lootBoxes)
            {
                var boxEntry = Instantiate(_template, transform);
                boxEntry.Initialize(box);
                boxEntry.Selected += BoxSelectedEventHandler;
                _entries.Add(boxEntry);
            }
        }

        public override void Show()
        {
            SetActive(isActive: true);
        }

        public override void Hide()
        {
            SetActive(isActive: false);
        }

        public override void Dispose()
        {
            foreach (var entry in _entries)
            {
                entry.Selected -= BoxSelectedEventHandler;
                entry.Dispose();
            }
        }

        private void BoxSelectedEventHandler(LootBoxVersion box)
        {
            Selected?.Invoke(box);
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}