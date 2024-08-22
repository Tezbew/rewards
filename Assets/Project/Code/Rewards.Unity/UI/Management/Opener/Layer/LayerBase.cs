using Rewards.UI.Management.Layer;
using Rewards.UI.Panel;
using UnityEngine;

namespace Rewards.Unity.UI.Management.Opener.Layer
{
    public abstract class LayerBase : MonoBehaviour, ILayer
    {
        public abstract void Add(IPanel panel);
        public abstract void Dispose();
    }
}