using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information
{
    public abstract class InformationBase : MonoBehaviour, IDisposable
    {
        public virtual event Action<LootBoxVersion> Selected;
        public abstract void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes);
        public abstract void Dispose();
    }
}