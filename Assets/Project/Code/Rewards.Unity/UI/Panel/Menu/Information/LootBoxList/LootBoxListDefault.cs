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

        public override void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes)
        {
            foreach (var box in lootBoxes)
            {
                var boxEntry = Instantiate(_template, transform);
                boxEntry.Initialize(box);
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
                entry.Dispose();
            }
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}