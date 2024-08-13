using System;
using Rewards.Resource;

namespace Rewards.LootBox.Config
{
    [Serializable]
    public class RewardResourceConfig
    {
        public ResourceType Resource;
        public int Count;
        public float Probability;
    }
}