using System.Collections.Generic;
using Rewards.LootBox.Version;

namespace Rewards.Unity.UI.Panel.Menu
{
    public abstract class MenuBase : PanelBase
    {
        public abstract void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes);
    }
}