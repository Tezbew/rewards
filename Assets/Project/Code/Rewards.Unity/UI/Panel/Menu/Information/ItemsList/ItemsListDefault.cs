using System;
using System.Collections.Generic;
using System.Linq;
using Rewards.Item;
using Rewards.Storage.Profile.Controller;
using Rewards.Unity.UI.Panel.Menu.Information.ItemsList.Entry.ItemEntry;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ItemsList
{
    public class ItemsListDefault : ItemsListBase
    {
        [SerializeField]
        private ItemEntryBase _template;

        private readonly List<ItemEntryBase> _entries = new();

        public override void Initialize(IProfileController profile)
        {
            CreateEntries(profile);
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
            for (var i = _entries.Count - 1; i >= 0; i--)
            {
                var current = _entries[i];
                Destroy(current.gameObject);
                _entries.RemoveAt(i);
            }
        }

        private void CreateEntries(IProfileController profile)
        {
            var allItems = (ItemType[])Enum.GetValues(typeof(ItemType));
            var sortedItems = allItems.Select(i => new ItemInfo(i, profile.ContainsItem(i)))
                                      .ToList();
            sortedItems.Sort((e1, e2) => -e1.Owned.CompareTo(e2.Owned));
            foreach (var currentInfo in sortedItems)
            {
                var instance = Instantiate(_template, transform);
                instance.Initialize(currentInfo);
                _entries.Add(instance);
            }
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}