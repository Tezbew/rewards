using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;
using Rewards.Storage.Profile.Controller;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information
{
    public abstract class InformationBase : MonoBehaviour, IDisposable
    {
        public abstract event Action<LootBoxVersion> Selected;
        public abstract void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes, IProfileController profile);
        public abstract void Dispose();
        public abstract void UpdateValues(IProfileController profile);
    }
}