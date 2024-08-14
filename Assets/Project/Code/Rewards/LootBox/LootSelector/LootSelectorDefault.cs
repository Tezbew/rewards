using System;
using Rewards.Item;
using Rewards.LootBox.Config;
using Rewards.LootBox.Loot;
using Rewards.LootBox.LootSelector.TotalRange;
using Rewards.Resource;
using Range = Rewards.LootBox.LootSelector.TotalRange.Range;

namespace Rewards.LootBox.LootSelector
{
    public class LootSelectorDefault : ILootSelector
    {
        private readonly Random _random = new();

        public ILoot Select(RewardListConfig rewardsConfig)
        {
            ITotalRange totalRange = new TotalRangeDefault();

            var lowBound = 0f;
            var items = rewardsConfig.Items;
            foreach (var currentConfig in items)
            {
                var upperBound = lowBound + currentConfig.Probability;

                var range = CreateRange(lowBound, upperBound, currentConfig.Item);
                totalRange.Add(range);

                lowBound = upperBound;
            }

            var resources = rewardsConfig.Resources;
            foreach (var currentConfig in resources)
            {
                var upperBound = lowBound + currentConfig.Probability;

                var range = CreateRange(lowBound, upperBound, currentConfig.Resource, currentConfig.Count);
                totalRange.Add(range);

                lowBound = upperBound;
            }

            var randomValue = (float)_random.NextDouble() * 100;
            var loot = totalRange.Evaluate(randomValue);

            return loot;
        }

        private static Range CreateRange(float lowBound, float upperBound, ItemType item)
        {
            var loot = new LootItem(item);
            var range = CreateRange(lowBound, upperBound, loot);

            return range;
        }

        private static Range CreateRange(float lowBound, float upperBound, ResourceType resource, int count)
        {
            var loot = new LootResource(resource, count);
            var range = CreateRange(lowBound, upperBound, loot);

            return range;
        }

        private static Range CreateRange(float lowBound, float upperBound, ILoot loot)
        {
            return new Range(lowBound, upperBound, loot);
        }
    }
}