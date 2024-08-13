using System;
using Rewards.Item;

namespace Rewards.LootBox.Config
{
    [Serializable]
    public class RewardItemConfig
    {
        public ItemType Item;
        public float Probability;
    }
}