using System;
using Rewards.LootBox.Config;
using Rewards.LootBox.Loot;
using Rewards.LootBox.LootSelector;

namespace Rewards.LootBox.Model
{
    public class LootBoxModel : ILootBoxModel
    {
        private readonly LootBoxConfig _config;
        private readonly ILootSelector _selector;

        public LootBoxModel(LootBoxConfig config)
        {
            _config = config;
        }

        public ILoot Loot { get; private set; }

        public bool IsOpened => Loot != null;

        public ILoot Open()
        {
            if (IsOpened == false)
            {
                throw new InvalidOperationException(message: "Can't open chest. It is already opened!");
            }

            Loot = _selector.Select(_config.Rewards);

            return Loot;
        }
    }
}