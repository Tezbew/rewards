using System.Collections.Generic;
using Rewards.Exceptions;
using Rewards.LootBox.Loot;

namespace Rewards.LootBox.LootSelector.TotalRange
{
    public class TotalRangeDefault : ITotalRange
    {
        private readonly List<Range> _ranges = new(capacity: 10);

        public void Add(Range range)
        {
            _ranges.Add(range);
        }

        public ILoot Evaluate(float probability)
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var currentRange in _ranges)
            {
                if (probability >= currentRange.Start && probability < currentRange.Finish)
                {
                    return currentRange.Loot;
                }
            }

            throw new ElementNotFountException($"Can't find loot for the given probability {probability}");
        }
    }
}