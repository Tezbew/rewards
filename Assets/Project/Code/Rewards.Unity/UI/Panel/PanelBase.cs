using Rewards.UI.Panel;
using UnityEngine;

namespace Rewards.Unity.UI.Panel
{
    public abstract class PanelBase : MonoBehaviour, IPanel
    {
        public abstract void Dispose();
    }
}