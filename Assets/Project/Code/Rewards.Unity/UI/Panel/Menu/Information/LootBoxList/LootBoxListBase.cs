using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.LootBoxList
{
    public abstract class LootBoxListBase : MonoBehaviour, IDisposable
    {
        public abstract void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes);
        public abstract void Show();
        public abstract void Hide();
        public abstract void Dispose();
    }
}