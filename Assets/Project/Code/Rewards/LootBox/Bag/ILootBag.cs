using Rewards.Item;
using Rewards.Resource;

namespace Rewards.LootBox.Bag
{
    public interface ILootBag
    {
        void AddResource(ResourceType resource, int count);
        void AddItem(ItemType item);
    }
}