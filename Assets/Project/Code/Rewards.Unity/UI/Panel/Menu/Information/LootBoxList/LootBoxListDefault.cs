using System.Collections.Generic;
using Rewards.Unity.UI.Panel.Menu.Information.LootBoxList.Entry;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.LootBoxList
{
    public class LootBoxListDefault : LootBoxListBase
    {
        [SerializeField]
        private LootBoxEntryBase _template;

        private readonly List<LootBoxEntryBase> _entries = new();

        public override void Initialize()
        {
        }

        public override void Show()
        {
        }

        public override void Hide()
        {
        }
    }
}