using Rewards.Item;

namespace Rewards.Unity.UI.Panel.Menu.Information
{
    public readonly struct ItemInfo
    {
        public readonly ItemType Item;
        public readonly bool Owned;

        public ItemInfo(ItemType item, bool owned)
        {
            Item = item;
            Owned = owned;
        }
    }
}