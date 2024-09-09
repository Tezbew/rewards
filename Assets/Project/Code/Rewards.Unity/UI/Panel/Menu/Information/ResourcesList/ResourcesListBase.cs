using System;
using Rewards.Storage.Profile.Controller;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ResourcesList
{
    public abstract class ResourcesListBase : MonoBehaviour, IListInformationList, IDisposable
    {
        public abstract void Initialize(IProfileController profile);
        public abstract void Show();
        public abstract void Hide();
        public abstract void Dispose();
        public abstract void UpdateValues(IProfileController profile);
    }
}