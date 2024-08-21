using System;
using Rewards.UI.Management.Layer;
using Rewards.Unity.UI.Panel;

namespace Rewards.Unity.UI.Management.Config
{
    [Serializable]
    public class PanelConfig
    {
        public string Name;
        public LayerType LayerType;
        public PanelBase Template;
    }
}