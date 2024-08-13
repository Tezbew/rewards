using System;
using System.Collections.Generic;

namespace Rewards.LootBox.Config
{
    [Serializable]
    public class RewardListConfig
    {
        public List<RewardItemConfig> Items;
        public List<RewardResourceConfig> Resources;
    }
}