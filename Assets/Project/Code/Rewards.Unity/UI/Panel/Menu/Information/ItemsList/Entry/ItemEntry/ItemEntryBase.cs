using Rewards.Item;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ItemsList.Entry.ItemEntry
{
    public abstract class ItemEntryBase : MonoBehaviour
    {
        public abstract ItemType Item { get; protected set; }
        public abstract void Initialize(ItemInfo info);
        public abstract void SetOwned(bool isOwned);
    }
}