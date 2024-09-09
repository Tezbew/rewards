using Rewards.LootBox.Model;
using Rewards.LootBox.Version;

namespace Rewards.LootBox.Factory
{
    public interface ILootBoxFactory
    {
        ILootBoxModel Create(LootBoxVersion version);
    }
}