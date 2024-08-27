using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ResourcesList
{
    public abstract class ResourcesListBase : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Show();
        public abstract void Hide();
    }
}