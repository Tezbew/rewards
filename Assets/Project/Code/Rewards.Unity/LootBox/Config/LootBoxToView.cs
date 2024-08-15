using System;
using Rewards.LootBox.Version;
using Rewards.Unity.LootBox.View;

namespace Rewards.Unity.LootBox.Config
{
    [Serializable]
    public class LootBoxToView
    {
        public LootBoxVersion Version;
        public LootBoxViewBase View;
    }
}