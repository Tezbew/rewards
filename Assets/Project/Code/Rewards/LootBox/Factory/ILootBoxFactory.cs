using Rewards.LootBox.Model;

namespace Rewards.LootBox.Factory
{
    public interface ILootBoxFactory
    {
        ILootBoxModel Create();
    }
}