using Rewards.Item;
using Rewards.LootBox.Bag;

namespace Rewards.LootBox.Loot
{
    public class LootItem : ILoot
    {
        private readonly ItemType _item;

        public LootItem(ItemType item)
        {
            _item = item;
        }

        public void Put(ILootBag bag)
        {
            bag.AddItem(_item);
        }
    }
}