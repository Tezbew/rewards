using System.Collections.Generic;
using Rewards.LootBox.Loot;

namespace Rewards.LootBox.Model
{
    public interface ILootBoxModel
    {
        IReadOnlyList<ILoot> Reward { get; }
    }
}