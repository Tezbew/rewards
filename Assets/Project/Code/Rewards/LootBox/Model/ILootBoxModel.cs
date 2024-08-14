using Rewards.LootBox.Loot;

namespace Rewards.LootBox.Model
{
    public interface ILootBoxModel
    {
        public bool IsOpened { get; }
        public ILoot Loot { get; }
        public ILoot Open();
    }
}