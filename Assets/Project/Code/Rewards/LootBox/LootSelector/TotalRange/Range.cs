using Rewards.LootBox.Loot;

namespace Rewards.LootBox.LootSelector.TotalRange
{
    public struct Range
    {
        public float Start { get; }
        public float Finish { get; }
        public ILoot Loot { get; }

        public Range(float start, float finish, ILoot loot)
        {
            Start = start;
            Finish = finish;
            Loot = loot;
        }
    }
}