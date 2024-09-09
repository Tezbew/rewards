using Rewards.Item;
using TMPro;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ItemsList.Entry.ItemEntry
{
    public class ItemEntryDefault : ItemEntryBase
    {
        [SerializeField]
        private TMP_Text _itemField;

        [SerializeField]
        private TMP_Text _ownedField;

        private ItemType _item;

        public override ItemType Item
        {
            get => _item;
            protected set
            {
                _item = value;
                _itemField.text = _item.ToString();
            }
        }

        public override void Initialize(ItemInfo info)
        {
            Item = info.Item;
            SetOwned(info.Owned);
        }

        public override void SetOwned(bool isOwned)
        {
            _ownedField.text = isOwned ? "Owned" : "Missing";
        }
    }
}