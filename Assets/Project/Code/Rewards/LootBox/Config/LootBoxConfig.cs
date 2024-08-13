using System;
using Rewards.LootBox.Version;

namespace Rewards.LootBox.Config
{
    [Serializable]
    public class LootBoxConfig
    {
        public LootBoxVersion Version;
        public RewardListConfig Rewards;
    }
}