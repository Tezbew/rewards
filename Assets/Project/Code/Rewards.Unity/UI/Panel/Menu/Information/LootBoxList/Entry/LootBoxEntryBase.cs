using System;
using Rewards.LootBox.Version;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.LootBoxList.Entry
{
    public abstract class LootBoxEntryBase : MonoBehaviour, IDisposable
    {
        public abstract event Action<LootBoxVersion> Selected;
        public abstract void Initialize(LootBoxVersion box);
        public abstract void Dispose();
    }
}