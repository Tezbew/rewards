using Rewards.LootBox.Bag;
using Rewards.Resource;

namespace Rewards.LootBox.Loot
{
    public class LootResource : ILoot
    {
        private readonly ResourceType _resource;
        private readonly int _count;

        public LootResource(ResourceType resource, int count)
        {
            _resource = resource;
            _count = count;
        }

        public void Put(ILootBag bag)
        {
            bag.AddResource(_resource, _count);
        }
    }
}