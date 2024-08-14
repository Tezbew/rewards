using Rewards.LootBox.Loot;

namespace Rewards.LootBox.LootSelector.TotalRange
{
    public interface ITotalRange
    {
        void Add(Range range);
        ILoot Evaluate(float probability);
    }
}