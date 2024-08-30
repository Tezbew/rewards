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

        public override void Initialize(ItemInfo info)
        {
            _itemField.text = info.Item.ToString();
            _ownedField.text = info.Owned ? "Owned" : "Missing";
        }
    }
}