using System.Collections.Generic;
using Rewards.LootBox.Loot;

namespace Rewards.LootBox.Model
{
    public class LootBoxModel : ILootBoxModel
    {
        public LootBoxModel(IReadOnlyList<ILoot> reward)
        {
            Reward = reward;
        }

        public IReadOnlyList<ILoot> Reward { get; }
    }
}