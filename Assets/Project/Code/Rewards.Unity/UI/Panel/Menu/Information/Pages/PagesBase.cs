using System;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.Pages
{
    public abstract class PagesBase : MonoBehaviour, IDisposable
    {
        public abstract event Action<int> ToggleActivated;
        public abstract void Initialize();
        public abstract void Dispose();
    }
}