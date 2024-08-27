using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.LootBoxList
{
    public abstract class LootBoxListBase : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Show();
        public abstract void Hide();
    }
}