using System;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information
{
    public abstract class InformationBase : MonoBehaviour, IDisposable
    {
        public abstract void Initialize();
        public abstract void Dispose();
    }
}