using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;

namespace Rewards.Unity.UI.Panel.Menu
{
    public abstract class MenuBase : PanelBase
    {
        public abstract event Action<LootBoxVersion> Selected;
        public abstract void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes);
    }
}