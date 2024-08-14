using Rewards.LootBox.Config;
using Rewards.LootBox.Loot;

namespace Rewards.LootBox.LootSelector
{
    public interface ILootSelector
    {
        ILoot Select(RewardListConfig rewardsConfig);
    }
}